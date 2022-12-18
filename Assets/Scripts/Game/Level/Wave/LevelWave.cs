using System.Collections.Generic;
using UnityEngine;

public class LevelWave
{
    private List<IController> _controllers = new List<IController>();

    public void Init(LevelWaveBehaviour behaviour)
    {
        foreach (var element in behaviour.GetElements())
        {
            var controller = element.CreateController();
            if (controller != null)
            {
                controller.Init();
                _controllers.Add(controller);
            }
        }
    }

    public void Deinit()
    {
        foreach (var controller in _controllers)
        {
            controller.Deinit();
        }

        _controllers.Clear();
    }

    public void DestroyController(IController controller)
    {
        controller.Deinit();
        _controllers.Remove(controller);
    }

    public bool IsEnded()
    {
        return _controllers.Count == 0;
    }
}
