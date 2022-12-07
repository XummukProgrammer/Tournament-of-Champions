using UnityEngine;

public class Player
{
    private Game _game;
    private Weapon _weapon = new Weapon();

    public void Init(Game game, string weaponId, int weaponDamage, int weaponAmmo)
    {
        _game = game;
        _weapon.Init(weaponId, weaponDamage, weaponAmmo);
    }

    public void Update()
    {
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
