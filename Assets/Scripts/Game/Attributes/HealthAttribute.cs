public class HealthAttribute : IAttribute
{
    public override void GiveValue(int value)
    {
        _value += value;
        ValueChanged?.Invoke(_value);
    }

    public override void TakeValue(int value)
    {
        _value -= value;

        if (_value < 0)
        {
            _value = 0;
        }

        ValueChanged?.Invoke(_value);
    }
}
