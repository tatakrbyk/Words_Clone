using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private bool _muteBackgroundMusic = false;
    private bool _muteSoundFx = false;

    public static SoundManager Instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void ToggleBackgroundMusic()
    {
        _muteBackgroundMusic= !_muteBackgroundMusic;
        if(_muteBackgroundMusic )
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        }
    }
    public void ToggleSoundFX()
    {
        _muteSoundFx= !_muteSoundFx;
        GameEvents.OnToggleSoundFXMethod();

    }
    public bool IsBackgroundMusicMuted()
    {
        return _muteBackgroundMusic;
    }
    public bool IsSoundFXMuted() { return _muteSoundFx; }

    public void SillienceBackgroundMusic(bool silience)
    {
        if(_muteBackgroundMusic == false)
        {
            if(silience)
                _audioSource.volume = 0f;
            else
                _audioSource.volume = 1f;
        }
    }
}
