using System.Collections.Generic;
using UnityEngine;

public class Game
{
    TargetBuilder _targetBuilder;

    public void Init(TargetBuilder targetBuilder)
    {
        _targetBuilder = targetBuilder;

        _targetBuilder.Create();
    }
}
