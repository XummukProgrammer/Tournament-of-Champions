using UnityEngine;

public class ShootingRangePlayerComponent : GameComponent<ShootingRangeMiniGame>
{
    [SerializeField] private WeaponAsset _weaponAsset;

    private ScoreAttribute _scoreAttribute = new ScoreAttribute();
    private CursorBehaviour _cursorBehaviour;

    private Vector3 _cursorPosition;
    private Vector3 _accuracyOffset;

    public Vector3 CursorPosition => _cursorPosition;
    public ScoreAttribute ScoreAttribute => _scoreAttribute;

    protected override void OnPostInit()
    {
        base.OnPostInit();

        _cursorBehaviour = MiniGame.EntryPoint.CursorBehaviour;

        MiniGame.PlayerWeaponComponent.AccuracyChanged += OnWeaponAccuracyChanged;
        OnWeaponAccuracyChanged(MiniGame.PlayerWeaponComponent.CurrentAccuracyOffset);
    }

    public override void OnUpdate()
    {
        UpdateCursorPosition();

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (MiniGame.PlayerWeaponComponent.TryShot())
        {
            var (targetController, targetZoneBehaviour) = MiniGame.GetTargetInMouseArea(CursorPosition);

            if (targetController != null && targetZoneBehaviour != null)
            {
                int scoreWithZone = targetController.GetScoreWithZone(targetZoneBehaviour.ZoneId);
                _scoreAttribute.GiveValue(scoreWithZone);

                int damage = MiniGame.PlayerWeaponComponent.Damage;
                targetController.Hit(damage);
                MiniGame.OnPlayerHitTarget(targetController, damage, scoreWithZone);
                

                if (targetController.IsDied())
                {
                    MiniGame.LevelComponent.DestroyTarget(targetController);
                }
            }
        }
    }

    private void OnWeaponAccuracyChanged(Vector2 accuracyOffset)
    {
        _accuracyOffset = accuracyOffset;
        UpdateCursorPosition();
    }

    private void UpdateCursorPosition()
    {
        _cursorPosition = MiniGame.EntryPoint.GetMousePosition() + new Vector3(_accuracyOffset.x, _accuracyOffset.y, 0);
        _cursorBehaviour.SetPosition(_cursorPosition);
    }
}
