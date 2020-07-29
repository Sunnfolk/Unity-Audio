using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerSample : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    private AudioClip _clip;


    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // This will play a Clip from its Beginning
        _source.Play();

        // This Function will Pause the audio clip
        _source.Pause();

        // This Function will Unpause the audio from where it was paused
        _source.UnPause();

        // This Function will Stop the audio from playing
        _source.Stop();

        // This Function will play an audioclip Independant of the AudioSource and can overlap.
        _source.PlayOneShot(_clip);

        // This you can use to check wether the AudioSource is already playing a song; so that you dont start it over again.
        if (!_source.isPlaying)
        {
            _source.PlayOneShot(_clip);
        }
    }
}
