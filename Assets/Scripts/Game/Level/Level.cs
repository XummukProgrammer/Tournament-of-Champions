using UnityEngine;

public class Level
{
    public System.Action<int> WaveChanged;
    public System.Action Ended;

    private LevelAsset _asset;
    private LevelWave _levelWave = new LevelWave();
    private int _currentWave;

    private bool _isInited = false;

    private ShootingRangeLoseTimerComponent _loseTimerComponent;

    public void Init(LevelAsset asset, ShootingRangeLoseTimerComponent loseTimerComponent)
    {
        _asset = asset;
        _isInited = true;

        _loseTimerComponent = loseTimerComponent;

        TryChangeWave(0);
    }

    public void Deinit()
    {
        _isInited = false;

        _levelWave.Deinit();
    }

    public void Update()
    {
        if (!_isInited)
        {
            return;
        }

        if (_levelWave.IsEnded())
        {
            WaveChanged?.Invoke(_currentWave);

            if (!TryChangeWave(_currentWave + 1))
            {
                Ended?.Invoke();
            }
        }
    }

    private bool TryChangeWave(int index)
    {
        _levelWave.Deinit();

        var waveBehaviours = _asset.WaveBehaviours;
        if (index < 0 || index >= waveBehaviours.Length)
        {
            return false;
        }

        _currentWave = index;

        var waveBehaviour = _asset.WaveBehaviours[index];
        _levelWave.Init(waveBehaviour);

        _loseTimerComponent.AddTime(waveBehaviour.Info.EntryAddTime);

        return true;
    }

    public void DestroyTargetController(Target target)
    {
        _levelWave.DestroyController(target);
    }
}
