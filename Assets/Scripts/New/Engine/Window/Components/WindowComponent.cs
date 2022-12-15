using UnityEngine;

public class WindowComponent : GameComponent
{
    [SerializeField] private WindowBehaviour _prefab;

    private Window _controller;

    public WindowBehaviour Prefab => _prefab;
    public Window Controller => _controller;

    protected override void OnInit()
    {
        base.OnInit();

        _controller = CreateController(MiniGame.EntryPoint.WindowManager);
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
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
