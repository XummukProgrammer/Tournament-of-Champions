using UnityEngine;

public class DebugPanelBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
