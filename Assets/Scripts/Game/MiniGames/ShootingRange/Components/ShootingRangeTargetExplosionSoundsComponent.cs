public class ShootingRangeTargetExplosionSoundsComponent : RandomPlaySoundsComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        MiniGame.PlayerHitTarget += OnPlayerHitTarget;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.PlayerHitTarget -= OnPlayerHitTarget;
    }

    private void OnPlayerHitTarget(Target target, int damage, bool isDied)
    {
        if (isDied)
        {
            PlayRandonSound(target.Id);
        }
    }
}
