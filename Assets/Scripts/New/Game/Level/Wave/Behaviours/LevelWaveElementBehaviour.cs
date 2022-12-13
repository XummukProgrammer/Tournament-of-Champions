using UnityEngine;

public class LevelWaveElementBehaviour : MonoBehaviour
{
    public virtual IController CreateController(Transform container) { return null; }
}
