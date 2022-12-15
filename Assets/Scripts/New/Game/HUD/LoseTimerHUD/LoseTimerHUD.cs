using UnityEngine;

public class LoseTimerHUD : HUD
{
    public void SetTimer(float timer)
    {
        var behaviour = Behaviour.GetComponent<LoseTimerHUDBehaviour>();
        if (behaviour != null)
        {
            behaviour.SetTimer(Mathf.Round(timer));
        }
    }
}
