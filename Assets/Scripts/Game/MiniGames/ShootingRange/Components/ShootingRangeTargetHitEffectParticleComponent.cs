public class ShootingRangeTargetHitEffectParticleComponent : ParticleEffectComponent<ShootingRangeMiniGame>
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
        Destroy();
    }

    private void OnPlayerHitTarget(Target target, int damage, bool isDied, int addCoinValue)
    {
        Play(target.Behaviour.gameObject.transform);
    }
}
