// TODO: ƒобавить взаимодействие с мини-игрой

using UnityEngine;

public class Player
{
    private EntryPoint _entryPoint;
    private Weapon _weapon = new Weapon();
    private ScoreAttribute _scoreAttribute = new ScoreAttribute();
    private CursorBehaviour _cursorBehaviour;

    private Vector3 _cursorPosition;
    private Vector3 _accuracyOffset;

    public Vector3 CursorPosition => _cursorPosition;
    public ScoreAttribute ScoreAttribute => _scoreAttribute;
    public Weapon Weapon => _weapon;

    public void Init(EntryPoint entryPoint, 
        string weaponId, int weaponDamage, int weaponAmmo, float weaponReloadDelay, WeaponAccuracyBehaviour weaponAccuracyBehaviour, float weaponAccuracyChangeDelay,
        CursorBehaviour cursorBehaviour)
    {
        _entryPoint = entryPoint;
        _weapon.Init(weaponId, weaponDamage, weaponAmmo, weaponReloadDelay, weaponAccuracyBehaviour, weaponAccuracyChangeDelay);
        _weapon.AccuracyChanged += OnWeaponAccuracyChanged;
        _cursorBehaviour = cursorBehaviour;

        OnWeaponAccuracyChanged(_weapon.CurrentAccuracyOffset);
    }

    public void Update()
    {
        _weapon.Update();
        UpdateCursorPosition();

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        //if (_weapon.TryShot())
        //{
        //    var (targetController, targetZoneBehaviour) = _game.GetTargetInMouseArea(CursorPosition);

        //    if (targetController != null && targetZoneBehaviour != null)
        //    {
        //        targetController.Hit(_weapon.Damage);

        //        int scoreWithZone = targetController.GetScoreWithZone(targetZoneBehaviour.ZoneId);
        //        _scoreAttribute.GiveValue(scoreWithZone);

        //        if (targetController.IsDied())
        //        {
        //            _game.DestroyTarget(targetController);
        //        }
        //    }
        //}
    }

    private void OnWeaponAccuracyChanged(Vector2 accuracyOffset)
    {
        _accuracyOffset = accuracyOffset;
        UpdateCursorPosition();
    }

    private void UpdateCursorPosition()
    {
        //_cursorPosition = _game.GetMousePosition() + new Vector3(_accuracyOffset.x, _accuracyOffset.y, 0);
        //_cursorBehaviour.SetPosition(_cursorPosition);
    }
}
