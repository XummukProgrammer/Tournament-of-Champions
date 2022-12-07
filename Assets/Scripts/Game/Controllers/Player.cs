using UnityEngine;

public class Player
{
    private Game _game;
    private Weapon _weapon = new Weapon();

    public void Init(Game game, string weaponId, int weaponDamage)
    {
        _game = game;
        _weapon.Init(weaponId, weaponDamage);
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
            targetController.Hit(_weapon.Damage);

            if (targetController.IsDied())
            {
                _game.DestroyTarget(targetController);
            }
        }
    }
}
