using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    [SerializeField] private AudioGroup[] audioGroups;
    private Dictionary<string, List<AudioClip>> audioDict;

    void Awake()
    {
        initDict();
    }

    private void initDict()
    {
        audioDict = new Dictionary<string, List<AudioClip>>();
        foreach (AudioGroup audioGroup in audioGroups)
        {
            audioDict[audioGroup.name] = audioGroup.audioClips;
        }
    }

    public AudioClip GetAudioClip(string name)
    {
        if (audioDict.ContainsKey(name))
        {
            List<AudioClip> audioClips = audioDict[name];
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }
}
[System.Serializable]
public struct AudioGroup
{
    public string name;
    public List<AudioClip> audioClips;
}