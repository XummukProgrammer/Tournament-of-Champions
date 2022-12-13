using UnityEngine;

public class HUDPanelBehaviour : MonoBehaviour
{
    public void Init(Game game)
    {
        game.Winned += OnGameWin;
    }

    private void OnGameWin()
    {
        gameObject.SetActive(false);
    }
}
