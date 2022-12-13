using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameAsset _gameAsset;
    [SerializeField] private Transform _controllersContainer;

    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [SerializeField] private YaAdsBehaviour _yaAdsBehaviour;
    [SerializeField] private YaPurchasesBehaviour _yaPurchasesBehaviour;

    [SerializeField] private LevelAsset _levelAsset;

    [SerializeField] private HUDContainerBehaviour _hudContainerBehaviour;
    [SerializeField] private Transform _windowContainer;

    private Game _game = new Game();

    private void Start()
    {
        var playerWeaponAsset = _storage.WeaponStorage.GetAsset(_gameAsset.PlayerWeaponId);
        if (playerWeaponAsset == null)
        {
            return;
        }

        var gameComponents = Instantiate(_gameAsset.ComponentsPrefab);

        _game.Init(_camera, 
            playerWeaponAsset.Id, playerWeaponAsset.Damage, playerWeaponAsset.Ammo, playerWeaponAsset.ReloadDelay, 
            playerWeaponAsset.AccuracyBehaviour, playerWeaponAsset.AccuracyChangeDelay, 
            _cursorBehaviour,
            _yaAdsBehaviour, _yaPurchasesBehaviour,
            _levelAsset, _controllersContainer,
            _hudContainerBehaviour, _windowContainer,
            gameComponents);
    }
    
    private void Update()
    {
        _game.Update();
    }
}
