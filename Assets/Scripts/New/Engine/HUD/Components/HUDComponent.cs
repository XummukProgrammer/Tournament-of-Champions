using UnityEngine;

public class HUDComponent : GameComponent
{
    [SerializeField] private HUDLocation _location;
    [SerializeField] private HUDBehaviour _prefab;

    private HUD _controller;

    public HUDLocation Location => _location;
    public HUDBehaviour Prefab => _prefab;
    public HUD Controller => _controller;

    public override void Init(Game game)
    {
        _controller = CreateController(game.HUDManager);
        OnInit();
    }

    public override void Deinit(Game game)
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

    protected virtual HUD CreateController(HUDManager hudManager) { return null; }
    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
