using System.Collections.Generic;
using UnityEngine;

public class LevelWaveBehaviour : MonoBehaviour
{
    public List<LevelWaveElementBehaviour> GetElements()
    {
        List<LevelWaveElementBehaviour> elements = new List<LevelWaveElementBehaviour>();

        foreach (var element in GetComponentsInChildren<LevelWaveElementBehaviour>())
        {
            elements.Add(element);
        }

        return elements;
    }
}
