using UnityEngine;

// TODO: ƒобавить взаимодействие с мини-игрой

public class LoseTimerHUD : HUD
{
    protected override void OnInit()
    {
        base.OnInit();

        UpdateTimer();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        var behaviour = Behaviour.GetComponent<LoseTimerHUDBehaviour>();
        if (behaviour != null)
        {
            //behaviour.SetTimer(Mathf.Round(Game.LoseTimer.LoseTime));
        }
    }
}
