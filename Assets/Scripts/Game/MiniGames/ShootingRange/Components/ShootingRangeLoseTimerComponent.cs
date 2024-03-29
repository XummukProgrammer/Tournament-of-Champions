using UnityEngine;

public class ShootingRangeLoseTimerComponent : GameComponent<ShootingRangeMiniGame>
{
    [SerializeField] private float _startTime = 100;

    private float _loseTime;

    public float LoseTime => _loseTime;

    public void AddTime(float time)
    {
        _loseTime += time;
    }

    private void Awake()
    {
        _loseTime = _startTime;
    }

    public override void OnUpdate()
    {
        _loseTime -= Time.deltaTime;

        if (_loseTime < 0)
        {
            _loseTime = 0;
        }
    }

    public bool IsLose()
    {
        return _loseTime <= 0f;
    }
}
