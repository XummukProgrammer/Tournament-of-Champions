using UnityEngine;

public class LoseTimerHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timer;

    public void SetTimer(float time)
    {
        _timer.text = time.ToString();
    }
}
