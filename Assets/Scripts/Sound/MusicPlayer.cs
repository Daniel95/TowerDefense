using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private Sprite[] buttonSprites;

    private Image image;

    [SerializeField]
    private string musicName;

    [SerializeField]
    private float volume;

    private AudioSource music;

    private bool musicPlaying = true;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();

        music = (AudioSource)gameObject.AddComponent<AudioSource>();

        music.clip = LoadSound(musicName);
        music.volume = volume;
        //playing the music

        ChangeMusicState();
    }

    private AudioClip LoadSound(string fileName)
    {
        AudioClip clip = (AudioClip)Resources.Load("Sounds/" + fileName);
        return clip;
    }

    public void ChangeMusicState() {
        musicPlaying = !musicPlaying;
        if (musicPlaying) StopMusic();
        else PlayMusic();
        image.sprite = buttonSprites[System.Convert.ToInt32(musicPlaying)];
    }


    public void PlayMusic()
    {
        music.loop = true;
        music.Play();
        image.sprite = buttonSprites[0];
    }

    public void StopMusic()
    {
        music.Stop();
        image.sprite = buttonSprites[1];
    }
}

