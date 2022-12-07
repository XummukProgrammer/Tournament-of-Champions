using UnityEngine;

public class LevelNumberBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    public void Init(Game game)
    {
        game.LevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged(int levelNumber)
    {
        _text.text = (levelNumber + 1).ToString();
    }
}
