using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource audioSource;
    public AudioClip popClip;
    public AudioClip windflapClip;
    public AudioClip hotAirClip;
    public AudioClip windZoneClip;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBalloon()
    {

        audioSource.PlayOneShot(popClip);
    }
    public void PlayWindFlap()
    {
        audioSource.PlayOneShot(windflapClip);
    }

    public void PlayHotAir()
    {

        audioSource.PlayOneShot(hotAirClip, .1f);

    }
    public void PlayWindZone()
    {

        audioSource.PlayOneShot(windZoneClip, .25f);
    }

}
