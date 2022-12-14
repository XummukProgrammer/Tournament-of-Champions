public class WindowAction : Action
{
    private Window _controller;

    public void Open(Window controller)
    {
        _controller = controller;
    }

    public void OpenByType<T>() where T : Window
    {
        Open(Game.WindowManager.GetControllerByType<T>());
    }

    protected override void OnInit()
    {
        base.OnInit();

        OnExecute += OnShowWindow;
        OnIsFinish += IsCloseWindow;
        OnFinish += OnCloseWindow;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        OnExecute -= OnShowWindow;
        OnIsFinish -= IsCloseWindow;
        OnFinish -= OnCloseWindow;
    }

    private void OnShowWindow()
    {
        _controller.Create();
    }

    private bool IsCloseWindow()
    {
        return false;
    }

    private void OnCloseWindow()
    {
        _controller.Destroy();
    }
}
