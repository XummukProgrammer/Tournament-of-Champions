using UnityEngine;

public class Player
{
    Game _game;

    public void Init(Game game)
    {
        _game = game;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        var targetController = _game.GetTargetInMouseArea();
        if (targetController != null)
        {
            Debug.Log("Shot target!!!");
        }
    }
}
