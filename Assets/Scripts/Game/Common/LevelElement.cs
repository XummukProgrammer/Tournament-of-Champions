using UnityEngine;

[System.Serializable]
public class LevelElement
{
    [SerializeField] private string _id;
    [SerializeField] private Vector3 _position;

    public string Id => _id;
    public Vector3 Position => _position;
}
