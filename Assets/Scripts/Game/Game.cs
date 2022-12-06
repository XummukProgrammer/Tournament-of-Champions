using UnityEngine;

public class Game
{
    TargetBuilder _targetBuilder;
    Player _player = new Player();

    Camera _camera;

    public void Init(TargetBuilder targetBuilder, Camera camera)
    {
        _targetBuilder = targetBuilder;
        _camera = camera;

        _targetBuilder.Create();

        _player.Init(this);
    }

    public void Update()
    {
        _player.Update();
    }

    public Target GetTargetInMouseArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            var targetBehaviour = hit.collider.GetComponent<TargetBehaviour>();
            if (targetBehaviour != null)
            {
                return targetBehaviour.Controller;
            }
        }
        return null;
    }

    public void DestroyTarget(Target controller)
    {
        controller.Destroy();
        _targetBuilder.DestroyController(controller);
    }
}
