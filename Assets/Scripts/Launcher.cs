using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameAsset _gameAsset;

    [SerializeField] private WeaponBehaviour _weaponBehaviour;
    [SerializeField] private HUDPanelBehaviour _hudPanelBehaviour;
    [SerializeField] private WinPanelBehaviour _winPanelBehaviour;
    [SerializeField] private DebugPanelBehaviour _debugPanelBehaviour;
    [SerializeField] private LosePanelBehaviour _losePanelBehaviour;
    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [SerializeField] private YaAdsBehaviour _yaAdsBehaviour;
    [SerializeField] private YaPurchasesBehaviour _yaPurchasesBehaviour;

    [SerializeField] private LevelAsset _levelAsset;
    [SerializeField] private Transform _controllersContainer;

    [SerializeField] private HUDContainerBehaviour _hudContainerBehaviour;

    Game _game = new Game();

    private void Start()
    {
        var playerWeaponAsset = _storage.WeaponStorage.GetAsset(_gameAsset.PlayerWeaponId);
        if (playerWeaponAsset == null)
        {
            return;
        }

        _hudPanelBehaviour.Init(_game);
        _winPanelBehaviour.Init(_game);
        _losePanelBehaviour.Init(_game);

        var gameComponents = Instantiate(_gameAsset.ComponentsPrefab);

        _game.Init(_camera, 
            playerWeaponAsset.Id, playerWeaponAsset.Damage, playerWeaponAsset.Ammo, playerWeaponAsset.ReloadDelay, 
            playerWeaponAsset.AccuracyBehaviour, playerWeaponAsset.AccuracyChangeDelay, 
            _weaponBehaviour, _debugPanelBehaviour, _cursorBehaviour,
            _yaAdsBehaviour, _yaPurchasesBehaviour,
            _levelAsset, _controllersContainer,
            _hudContainerBehaviour,
            gameComponents);
    }
    
    private void Update()
    {
        _game.Update();
    }
}
