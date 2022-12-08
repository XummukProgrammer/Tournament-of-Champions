using UnityEngine;

public class Player
{
    private Game _game;
    private Weapon _weapon = new Weapon();
    private ScoreAttribute _scoreAttribute = new ScoreAttribute();

    private Vector3 _cursorPosition;

    public Vector3 CursorPosition => _cursorPosition;

    public void Init(Game game, 
        string weaponId, int weaponDamage, int weaponAmmo, float weaponReloadDelay, Vector2[] weaponAccuracyOffsets, float weaponAccuracyChangeDelay,
        WeaponBehaviour weaponBehaviour, ScoreNumberBehaviour scoreNumberBehaviour)
    {
        _game = game;
        _weapon.Init(weaponId, weaponDamage, weaponAmmo, weaponReloadDelay, weaponAccuracyOffsets, weaponAccuracyChangeDelay);
        _weapon.AccuracyChanged += OnWeaponAccuracyChanged;

        weaponBehaviour.Init(_weapon);
        scoreNumberBehaviour.Init(_scoreAttribute);

        OnWeaponAccuracyChanged(_weapon.CurrentAccuracyOffset);
    }

    public void Update()
    {
        _weapon.Update();
        
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (_weapon.TryShot())
        {
            var (targetController, targetZoneBehaviour) = _game.GetTargetInMouseArea(CursorPosition);

            if (targetController != null && targetZoneBehaviour != null)
            {
                targetController.Hit(_weapon.Damage);

                int scoreWithZone = targetController.GetScoreWithZone(targetZoneBehaviour.ZoneId);
                _scoreAttribute.GiveValue(scoreWithZone);

                if (targetController.IsDied())
                {
                    _game.DestroyTarget(targetController);
                }
            }
        }
    }

    private void OnWeaponAccuracyChanged(Vector2 accuracyOffset)
    {
        _cursorPosition = _game.GetMousePosition() + new Vector3(accuracyOffset.x, accuracyOffset.y, 0);
    }
}
