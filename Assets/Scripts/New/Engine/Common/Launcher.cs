using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [SerializeField] private BaseMiniGameEntryBehaviour[] _miniGameEntryBehaviours;
    [SerializeField] private string _startMiniGameId;

    [SerializeField] private HUDContainerBehaviour _hudContainerBehaviour;
    [SerializeField] private Transform _windowContainer;

    private EntryPoint _entryPoint = new EntryPoint();

    private void OnEnable()
    {
        _entryPoint.Init(_camera, 
            _cursorBehaviour,
            _hudContainerBehaviour, _windowContainer, 
            _miniGameEntryBehaviours, _startMiniGameId);
    }

    private void OnDisable()
    {
        _entryPoint.OnDisabled();
        _entryPoint.Deinit();
    }

    private void Update()
    {
        _entryPoint.Update();
    }
}
