public class ScoreAttribute : IAttribute
{
    public override void GiveValue(int value)
    {
        int prevValue = _value;
        _value += value;
        ValueChanged?.Invoke(prevValue, _value);
    }

    public override void TakeValue(int value)
    {
        throw new System.NotImplementedException();
    }
}
