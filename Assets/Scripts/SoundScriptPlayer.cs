using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundScriptPlayer : MonoBehaviour
{
    public AudioClip woodSound;
    public AudioClip dirtSound;
    public AudioClip grassSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string surfaceTag = collision.gameObject.tag; 

        switch (surfaceTag)
        {
            case "WoodFloor":
                PlaySound(woodSound);
                break;
            case "Terrain":
                PlaySound(dirtSound);
                break;
            case "Grass":
                PlaySound(grassSound);
                break;
            default:
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        audioSource.Stop();
    }

    void PlaySound(AudioClip sound)
    {
        if (audioSource.clip != sound)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
