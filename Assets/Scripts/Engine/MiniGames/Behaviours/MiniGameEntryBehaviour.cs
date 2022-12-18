using UnityEngine;

public class BaseMiniGameEntryBehaviour : MonoBehaviour
{
    public virtual MiniGame CreateMiniGame(MiniGamesManager miniGamesManager) { return null; }
}

public class MiniGameEntryBehaviour<T> : BaseMiniGameEntryBehaviour where T : MiniGame
{
    [SerializeField] private GameComponents _components;

    public GameComponents Components => _components;

    public override MiniGame CreateMiniGame(MiniGamesManager miniGamesManager) 
    { 
        return miniGamesManager.CreateAndAddMiniGame<T>(Components); 
    }
}
