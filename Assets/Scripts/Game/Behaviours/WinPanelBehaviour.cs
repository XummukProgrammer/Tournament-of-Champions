using UnityEngine;

public class WinPanelBehaviour : MonoBehaviour
{
    public void Init(Game game)
    {
        game.Winned += OnGameWin;
    }

    private void OnGameWin()
    {
        gameObject.SetActive(true);
    }
}
