using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public virtual void Init(MiniGame miniGame) { }
    public virtual void Deinit(MiniGame miniGame) { }
}
