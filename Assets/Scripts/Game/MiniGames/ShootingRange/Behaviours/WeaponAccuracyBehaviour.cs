using UnityEngine;

public class WeaponAccuracyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public Vector2[] GetPoints()
    {
        Vector2[] points = new Vector2[_points.Length];
        int index = 0;

        foreach (var point in _points)
        {
            points[index] = new Vector2(point.position.x, point.position.y);
            ++index;
        }

        return points;
    }
}
