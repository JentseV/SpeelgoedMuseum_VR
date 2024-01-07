using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] musicTracks;
    public AudioClip specificSong; 
    public GameLogic gameLogic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicTracks.Length > 0 && specificSong != null)
        {
            audioSource.clip = specificSong;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No intro song or music tracks assigned!");
        }
    }

void Update()
{
    if (gameLogic.entry)
    {
        if (audioSource.clip == specificSong && audioSource.isPlaying)
        {
            audioSource.Stop();
            PlayRandomKidsPlayingSound();
        }
        else if (!audioSource.isPlaying)
        {
            PlayRandomKidsPlayingSound();
        }
    }
}

    void PlayRandomKidsPlayingSound()
    {
        int randomIndex = Random.Range(0, musicTracks.Length);

        audioSource.clip = musicTracks[randomIndex];
        audioSource.Stop();
        audioSource.Play();
    }
}
