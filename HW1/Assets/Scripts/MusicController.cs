using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource bgMusic;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    public void ToggleMusic()
    {
        if (bgMusic.isPlaying)
        {
            bgMusic.Pause();
        }
        else
        {
            bgMusic.UnPause();
        }
    }
}