using UnityEngine;

public class HUDBehaviour : MonoBehaviour
{
    public System.Action Clicked;

    public void Init()
    {
        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        OnHide();
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
