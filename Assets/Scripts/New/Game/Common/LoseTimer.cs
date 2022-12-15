using UnityEngine;

public class LoseTimer
{
    private float _loseTime;

    public float LoseTime => _loseTime;

    public void AddTime(float time)
    {
        _loseTime += time;
    }

    public void Update()
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
