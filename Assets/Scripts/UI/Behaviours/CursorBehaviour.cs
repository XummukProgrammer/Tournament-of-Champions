using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    public void SetPosition(Vector3 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
