public class ShootingRangeAddCoinEffectComponent : AddValueEffectComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        MiniGame.PlayerHitTarget += OnPlayerHitTarget;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.PlayerHitTarget -= OnPlayerHitTarget;
    }

    private void OnPlayerHitTarget(Target target, int damage, bool isDied, int addCoinValue)
    {
        Play(target.Behaviour.transform, addCoinValue);
    }
}
