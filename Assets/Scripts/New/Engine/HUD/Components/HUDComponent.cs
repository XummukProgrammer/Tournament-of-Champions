using UnityEngine;

public class HUDComponent<TController, TMiniGame> : GameComponent<TMiniGame> 
    where TMiniGame : MiniGame 
    where TController : HUD
{
    [SerializeField] private HUDLocation _location;
    [SerializeField] private HUDBehaviour _prefab;

    private TController _controller;

    public HUDLocation Location => _location;
    public HUDBehaviour Prefab => _prefab;
    public TController Controller => _controller;

    protected override void OnInit()
    {
        base.OnInit();

        _controller = CreateController(MiniGame.EntryPoint.HUDManager);
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

    private TController CreateController(HUDManager hudManager) 
    { 
        return hudManager.CreateAndAddController<TController>(Prefab, Location); 
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
