using UnityEngine;

public class Level
{
    public System.Action<int> WaveChanged;
    public System.Action Ended;

    private Transform _container;
    private LevelAsset _asset;
    private LevelWave _levelWave = new LevelWave();
    private int _currentWave;

    public void Init(LevelAsset asset, Transform container)
    {
        _asset = asset;
        _container = container;

        TryChangeWave(0);
    }

    public void Deinit()
    {
        _levelWave.Deinit();
    }

    public void Update()
    {
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

        var waveBehaviour = GameObject.Instantiate(_asset.WaveBehaviours[index]);
        _levelWave.Init(_container, waveBehaviour);
        GameObject.Destroy(waveBehaviour.gameObject);

        return true;
    }

    public void DestroyTargetController(Target target)
    {
        _levelWave.DestroyController(target);
    }
}