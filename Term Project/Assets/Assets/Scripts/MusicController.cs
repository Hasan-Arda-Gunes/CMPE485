using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource musicSource;

    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for 'M' key press
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }
    }
}