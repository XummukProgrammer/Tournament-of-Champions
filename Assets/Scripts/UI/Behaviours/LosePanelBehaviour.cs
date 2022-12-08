using UnityEngine;

public class LosePanelBehaviour : MonoBehaviour
{
    public void Init(Game game)
    {
        game.Losed += OnGameLosed;
    }

    private void OnGameLosed()
    {
        gameObject.SetActive(true);
    }
}
