using UnityEngine;

public class EntryPoint
{
    private Camera _camera;

    private CursorBehaviour _cursorBehaviour;

    private HUDManager _hudManager = new HUDManager();
    private WindowManager _windowManager = new WindowManager();
    private ActionsQueue _actionsQueue = new ActionsQueue();
    private MiniGamesManager _miniGamesManager = new MiniGamesManager();

    private MiniGameEntryBehaviour[] _miniGameEntryBehaviours;
    private string _startMiniGameId;

    public HUDManager HUDManager => _hudManager;
    public WindowManager WindowManager => _windowManager;
    public ActionsQueue ActonsQueue => _actionsQueue;
    public MiniGamesManager MiniGamesManager => _miniGamesManager;
    public CursorBehaviour CursorBehaviour => _cursorBehaviour;

    public void Init(Camera camera, CursorBehaviour cursorBehaviour,
        HUDContainerBehaviour hudContainerBehaviour, Transform windowContainer,
        MiniGameEntryBehaviour[] miniGameEntryBehaviours, string startMiniGameId)
    {
        Cursor.visible = false;

        _camera = camera;
        _cursorBehaviour = cursorBehaviour;
        _miniGameEntryBehaviours = miniGameEntryBehaviours;
        _startMiniGameId = startMiniGameId;

        _hudManager.Init(this, hudContainerBehaviour);
        _windowManager.Init(this, windowContainer);
        _miniGamesManager.Init(this);
        _actionsQueue.Init(this);

        StartMiniGame(_startMiniGameId);
    }

    public void Deinit()
    {
        _hudManager.Deinit();
        _windowManager.Deinit();
        _actionsQueue.Deinit();
        _miniGamesManager.Deinit();
    }

    public void Update()
    {
        _hudManager.Update();
        _windowManager.Update();
        _actionsQueue.Update();
        _miniGamesManager.Update();
    }

    public Vector3 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StartMiniGame(string miniGameId)
    {
        foreach (var miniGameEntryBehaviour in _miniGameEntryBehaviours)
        {
            if (miniGameEntryBehaviour.name == miniGameId)
            {
                miniGameEntryBehaviour.CreateMiniGame(_miniGamesManager);
            }
        }
    }
}
