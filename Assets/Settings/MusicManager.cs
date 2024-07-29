using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_MUSIC = "MusicVolume";
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;
    private float volume = .3f;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_MUSIC, .3f);
        audioSource.volume = volume;

    }
    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f) { volume = 0f; }
        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_MUSIC, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() { return volume; }
}
