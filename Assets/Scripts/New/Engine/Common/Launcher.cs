using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [SerializeField] private YaAdsBehaviour _yaAdsBehaviour;
    [SerializeField] private YaPurchasesBehaviour _yaPurchasesBehaviour;

    [SerializeField] private MiniGameEntryBehaviour[] _miniGameEntryBehaviours;
    [SerializeField] private string _startMiniGameId;

    [SerializeField] private HUDContainerBehaviour _hudContainerBehaviour;
    [SerializeField] private Transform _windowContainer;

    private EntryPoint _entryPoint = new EntryPoint();

    private void OnEnable()
    {
        _entryPoint.Init(_camera, 
            _cursorBehaviour, 
            _yaAdsBehaviour, _yaPurchasesBehaviour, 
            _hudContainerBehaviour, _windowContainer, 
            _miniGameEntryBehaviours, _startMiniGameId);
    }

    private void OnDisable()
    {
        _entryPoint.Deinit();
    }

    private void Update()
    {
        _entryPoint.Update();
    }
}
