using UnityEngine;

public class Player
{
    private Game _game;
    private Weapon _weapon = new Weapon();
    private ScoreAttribute _scoreAttribute = new ScoreAttribute();

    public void Init(Game game, string weaponId, int weaponDamage, int weaponAmmo, float weaponReloadDelay, WeaponBehaviour weaponBehaviour, ScoreNumberBehaviour scoreNumberBehaviour)
    {
        _game = game;
        _weapon.Init(weaponId, weaponDamage, weaponAmmo, weaponReloadDelay);
        
        weaponBehaviour.Init(_weapon);
        scoreNumberBehaviour.Init(_scoreAttribute);
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
        var (targetController, targetZoneBehaviour) = _game.GetTargetInMouseArea();
        if (targetController != null && targetZoneBehaviour != null)
        {
            int scoreWithZone = targetController.GetScoreWithZone(targetZoneBehaviour.ZoneId);
            _scoreAttribute.GiveValue(scoreWithZone);

            if (_weapon.TryShot(targetController))
            {
                if (targetController.IsDied())
                {
                    _game.DestroyTarget(targetController);
                }
            }
        }
    }
}
