using UnityEngine;

public class HUDComponent : GameComponent
{
    [SerializeField] private HUDLocation _location;
    [SerializeField] private HUDBehaviour _prefab;

    private HUD _controller;

    public HUDLocation Location => _location;
    public HUDBehaviour Prefab => _prefab;
    public HUD Controller => _controller;

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

    protected virtual HUD CreateController(HUDManager hudManager) { return null; }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
