using UnityEngine;

public class ScoreNumberBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void Init(ScoreAttribute scoreAttribute)
    {
        scoreAttribute.ValueChanged += OnScoreAttributeChanged;
    }

    private void OnScoreAttributeChanged(int prevValue, int nextValue)
    {
        _text.text = nextValue.ToString();
    }
}
