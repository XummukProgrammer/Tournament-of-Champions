using UnityEngine;

[System.Serializable]
public class TargetBuilderElement
{
    [SerializeField] private string _id;
    [SerializeField] private Transform _position;

    public string Id => _id;
    public Vector3 Position => _position.position;
}
