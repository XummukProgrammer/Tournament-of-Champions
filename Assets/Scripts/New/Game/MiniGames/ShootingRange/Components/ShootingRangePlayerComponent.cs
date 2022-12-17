using UnityEngine;

public class ShootingRangePlayerComponent : GameComponent
{
    [SerializeField] private WeaponAsset _weaponAsset;

    private Weapon _weapon = new Weapon();
    private ScoreAttribute _scoreAttribute = new ScoreAttribute();
    private CursorBehaviour _cursorBehaviour;

    private Vector3 _cursorPosition;
    private Vector3 _accuracyOffset;

    public Vector3 CursorPosition => _cursorPosition;
    public ScoreAttribute ScoreAttribute => _scoreAttribute;
    public Weapon Weapon => _weapon;

    protected override void OnInit()
    {
        _weapon.Init(_weaponAsset.Id, _weaponAsset.Damage, _weaponAsset.Ammo, _weaponAsset.ReloadDelay, _weaponAsset.AccuracyBehaviour, _weaponAsset.AccuracyChangeDelay);
        _weapon.AccuracyChanged += OnWeaponAccuracyChanged;
        _cursorBehaviour = MiniGame.EntryPoint.CursorBehaviour;

        OnWeaponAccuracyChanged(_weapon.CurrentAccuracyOffset);
    }

    public override void OnUpdate()
    {
        _weapon.Update();
        UpdateCursorPosition();

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (_weapon.TryShot())
        {
            var miniGame = MiniGame as ShootingRangeMiniGame;

            var (targetController, targetZoneBehaviour) = miniGame.GetTargetInMouseArea(CursorPosition);

            if (targetController != null && targetZoneBehaviour != null)
            {
                targetController.Hit(_weapon.Damage);

                int scoreWithZone = targetController.GetScoreWithZone(targetZoneBehaviour.ZoneId);
                _scoreAttribute.GiveValue(scoreWithZone);

                if (targetController.IsDied())
                {
                    miniGame.LevelComponent.DestroyTarget(targetController);
                }
            }
        }
    }

    private void OnWeaponAccuracyChanged(Vector2 accuracyOffset)
    {
        _accuracyOffset = accuracyOffset;
        UpdateCursorPosition();
    }

    private void UpdateCursorPosition()
    {
        _cursorPosition = MiniGame.EntryPoint.GetMousePosition() + new Vector3(_accuracyOffset.x, _accuracyOffset.y, 0);
        _cursorBehaviour.SetPosition(_cursorPosition);
    }
}
