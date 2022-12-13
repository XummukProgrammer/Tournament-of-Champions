using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    Target _controller;

    public Target Controller => _controller;

    public void Init(Target controller)
    {
        _controller = controller;
    }
}
