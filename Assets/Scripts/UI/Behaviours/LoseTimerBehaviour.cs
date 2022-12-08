using UnityEngine;

public class LoseTimerBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    private LoseTimer _loseTimer;

    public void Init(LoseTimer loseTimer)
    {
        _loseTimer = loseTimer;
    }

    private void Update()
    {
        _text.text = Mathf.Round(_loseTimer.LoseTime).ToString();
    }
}
