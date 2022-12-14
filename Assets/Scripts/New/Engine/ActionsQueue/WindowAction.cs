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

        ExecuteDelegate = OnShowWindow;
        IsFinishDelegate = IsCloseWindow;
        FinishDelegate = OnCloseWindow;
    }

    private void OnShowWindow()
    {
        _controller.Create();
    }

    private bool IsCloseWindow()
    {
        return _controller.IsClose();
    }

    private void OnCloseWindow()
    {
        _controller.Destroy();
    }
}
