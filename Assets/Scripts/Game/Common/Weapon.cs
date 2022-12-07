public class Weapon
{
    private string _id;
    private int _damage;

    public string Id => _id;
    public int Damage => _damage;

    public void Init(string id, int damage)
    {
        _id = id;
        _damage = damage;
    }
}
