using UnityEngine;

public class WindowComponent : GameComponent
{
    [SerializeField] private WindowBehaviour _prefab;

    private Window _controller;

    public WindowBehaviour Prefab => _prefab;
    public Window Controller => _controller;

    public override void Init(MiniGame miniGame)
    {
        _controller = CreateController(miniGame.EntryPoint.WindowManager);
        OnInit();
    }

    public override void Deinit(MiniGame miniGame)
    {
        OnDeinit();
    }

    public void Show()
    {
        _controller.Show();
        OnShow();
    }

    public void Hide()
    {
        _controller.Hide();
        OnHide();
    }

    protected virtual Window CreateController(WindowManager windowManager) { return null; }
    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
