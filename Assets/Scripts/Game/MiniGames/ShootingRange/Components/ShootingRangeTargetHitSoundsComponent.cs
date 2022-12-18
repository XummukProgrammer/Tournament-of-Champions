using UnityEngine;

public class ShootingRangeTargetHitSoundsComponent : GameComponent<ShootingRangeMiniGame>
{
    [SerializeField] private ShootingRangeTargetSoundInfo[] _soundInfos;

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
        var soundInfo = GetSoundInfo(target);
        if (soundInfo != null)
        {
            var soundIds = soundInfo.SoundIds;
            if (soundIds.Length > 0)
            {
                var soundId = soundIds[Random.Range(0, soundIds.Length)];
                MiniGame.EntryPoint.SoundsManager.PlaySound(soundId);
            }
        }
    }

    private ShootingRangeTargetSoundInfo GetSoundInfo(Target target)
    {
        foreach (var soundInfo in _soundInfos)
        {
            if (soundInfo.Id == target.Id)
            {
                return soundInfo;
            }
        }
        return null;
    }
}
