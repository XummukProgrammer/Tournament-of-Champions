using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameAsset _gameAsset;

    //[SerializeField] private LevelNumberBehaviour _levelNumberBehaviour;
    [SerializeField] private ScoreNumberBehaviour _scoreNumberBehaviour;

    [SerializeField] private WeaponBehaviour _weaponBehaviour;
    [SerializeField] private HUDPanelBehaviour _hudPanelBehaviour;
    [SerializeField] private WinPanelBehaviour _winPanelBehaviour;
    [SerializeField] private DebugPanelBehaviour _debugPanelBehaviour;
    [SerializeField] private LoseTimerBehaviour _loseTimerBehaviour;
    [SerializeField] private LosePanelBehaviour _losePanelBehaviour;
    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [SerializeField] private YaAdsBehaviour _yaAdsBehaviour;
    [SerializeField] private YaPurchasesBehaviour _yaPurchasesBehaviour;

    Game _game = new Game();

    private void Start()
    {
        var playerWeaponAsset = _storage.WeaponStorage.GetAsset(_gameAsset.PlayerWeaponId);
        if (playerWeaponAsset == null)
        {
            return;
        }

        //_levelNumberBehaviour.Init(_game);
        _hudPanelBehaviour.Init(_game);
        _winPanelBehaviour.Init(_game);
        _losePanelBehaviour.Init(_game);

        _game.Init(_camera, _gameAsset.LevelsChain, 
            playerWeaponAsset.Id, playerWeaponAsset.Damage, playerWeaponAsset.Ammo, playerWeaponAsset.ReloadDelay, 
            playerWeaponAsset.AccuracyBehaviour, playerWeaponAsset.AccuracyChangeDelay, 
            _weaponBehaviour, _debugPanelBehaviour, _scoreNumberBehaviour, _loseTimerBehaviour, _cursorBehaviour,
            _yaAdsBehaviour, _yaPurchasesBehaviour);
    }
    
    private void Update()
    {
        _game.Update();
    }
}
