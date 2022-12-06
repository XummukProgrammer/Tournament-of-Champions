public abstract class IAttributeChangePolicy
{
    public abstract void GiveValue(int value);
    public abstract void TakeValue(int value);
}

public abstract class IAttribute : IAttributeChangePolicy
{
    public System.Action<int> ValueChanged;

    protected int _value = 0;

    public int Value => _value;
}
