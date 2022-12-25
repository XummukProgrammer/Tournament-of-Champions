using UnityEngine;

public class AddValueEffectBehaviour : MonoBehaviour
{
    public System.Action AnimationFinished;

    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private string _symbol = "+";

    public void Init(int value)
    {
        _text.text = _symbol + value.ToString();
    }

    public void OnAnimationFinished()
    {
        AnimationFinished?.Invoke();
    }
}
