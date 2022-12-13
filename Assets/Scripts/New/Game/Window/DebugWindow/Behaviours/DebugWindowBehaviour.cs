using UnityEngine;

public class DebugWindowBehaviour : WindowBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
