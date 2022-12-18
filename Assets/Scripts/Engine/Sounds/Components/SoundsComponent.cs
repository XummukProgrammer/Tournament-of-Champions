using UnityEngine;

public class SoundsComponent : GameComponent<MiniGame>
{
    [SerializeField] private SoundInfo[] _soundInfos;

    protected override void OnInit()
    {
        base.OnInit();

        foreach (var soundInfo in _soundInfos)
        {
            MiniGame.EntryPoint.SoundsManager.CreateSound(soundInfo.Id, soundInfo.AudioClip);
        }
    }
}
