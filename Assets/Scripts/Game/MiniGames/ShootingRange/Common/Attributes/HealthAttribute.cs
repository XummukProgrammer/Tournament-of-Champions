public class HealthAttribute : IAttribute
{
    public override void GiveValue(int value)
    {
        int prevValue = _value;
        _value += value;
        ValueChanged?.Invoke(prevValue, _value);
    }

    public override void TakeValue(int value)
    {
        int prevValue = _value;
        _value -= value;

        if (_value < 0)
        {
            _value = 0;
        }

        ValueChanged?.Invoke(prevValue, _value);
    }
}
