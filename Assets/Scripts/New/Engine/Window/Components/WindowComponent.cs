using UnityEngine;

public class WindowComponent<TController, TMiniGame> : GameComponent<TMiniGame> 
    where TMiniGame : MiniGame
    where TController : Window
{
    [SerializeField] private WindowBehaviour _prefab;

    private TController _controller;

    public WindowBehaviour Prefab => _prefab;
    public TController Controller => _controller;

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

    private TController CreateController(WindowManager windowManager) 
    { 
        return windowManager.CreateAndAddController<TController>(Prefab); 
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
