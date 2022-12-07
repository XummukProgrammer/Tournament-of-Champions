using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private TargetBuilder _targetBuilder;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameAsset _gameAsset;

    Game _game = new Game();

    private void Start()
    {
        var playerWeaponAsset = _storage.WeaponStorage.GetAsset(_gameAsset.PlayerWeaponId);
        if (playerWeaponAsset == null)
        {
            return;
        }

        _game.Init(_targetBuilder, _camera, _gameAsset.LevelsChain, playerWeaponAsset.Id, playerWeaponAsset.Damage, playerWeaponAsset.Ammo, playerWeaponAsset.ReloadDelay);
    }

    private void Update()
    {
        _game.Update();
    }
}
