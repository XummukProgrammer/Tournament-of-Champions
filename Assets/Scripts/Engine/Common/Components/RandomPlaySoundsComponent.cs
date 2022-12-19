using UnityEngine;

[System.Serializable]
public class RandomPlaySoundsInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string[] _soundIds;

    public string Id => _id;
    public string[] SoundIds => _soundIds;
}

public class RandomPlaySoundsComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private RandomPlaySoundsInfo[] _soundInfos;

    public void PlayRandonSound(string id)
    {
        var soundInfo = GetSoundInfo(id);
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

    private RandomPlaySoundsInfo GetSoundInfo(string id)
    {
        foreach (var soundInfo in _soundInfos)
        {
            if (soundInfo.Id == id)
            {
                return soundInfo;
            }
        }
        return null;
    }
}
