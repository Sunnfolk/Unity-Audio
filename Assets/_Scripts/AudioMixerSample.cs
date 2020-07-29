using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerSample : MonoBehaviour
{
    [SerializeField] private static AudioMixer _mixer;

    public static void SetSFXVol (float sfxvol)
    {
        _mixer.SetFloat("SFXVol", sfxvol);
    }
    public static void SetMusicVol(float musicvol )
    {
        _mixer.SetFloat("MusicVol", musicvol);
    }
    public static void SetMasterVol(float mastervol)
    {
        _mixer.SetFloat("MasterVol", mastervol);
    }

    public void ClearVolume(string name)
    {
        _mixer.ClearFloat(name);
    }
}
