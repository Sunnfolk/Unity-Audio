using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerSample : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // This will play a Clip from its Beginning.
            // If a Source is Paused and you call Play(), the source will become unpaused.
            _source.Play();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // This Function will Pause the audio clip
            _source.Pause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // This Function will Unpause the audio from where it was paused. 
            // Unlike Play(), it will not create a new playback voice if it is not currently paused.
            _source.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            // This Function will Stop the audio from playing
            _source.Stop();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // This Function will play an audioclip Independant of the AudioSource and can overlap.
            _source.PlayOneShot(_clip);
        }
        if (Input.GetMouseButtonDown(1))
        {
            // This you can use to check wether the AudioSource is already playing a song; so that you dont start it over again.
            if (!_source.isPlaying)
            {
                _source.PlayOneShot(_clip);
            }
        }
    }
}