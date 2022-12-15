using UnityEngine;

public class MiniGameEntryBehaviour : MonoBehaviour
{
    [SerializeField] private GameComponents _components;

    public GameComponents Components => _components;

    public virtual MiniGame CreateMiniGame(MiniGamesManager miniGamesManager) { return null; }
}
