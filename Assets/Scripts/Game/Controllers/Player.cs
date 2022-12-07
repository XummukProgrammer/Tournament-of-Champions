using UnityEngine;

public class Player
{
    private Game _game;
    private Weapon _weapon = new Weapon();

    public void Init(Game game, string weaponId, int weaponDamage, int weaponAmmo, float weaponReloadDelay)
    {
        _game = game;
        _weapon.Init(weaponId, weaponDamage, weaponAmmo, weaponReloadDelay);
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
        var targetController = _game.GetTargetInMouseArea();
        if (targetController != null)
        {
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
