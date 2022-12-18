using UnityEngine;

public class LevelWaveElementBehaviour : MonoBehaviour
{
    public virtual IController CreateController() { return null; }
}
