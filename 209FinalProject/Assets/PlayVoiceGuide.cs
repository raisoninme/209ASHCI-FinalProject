using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource[] audioSources;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSources = new AudioSource[audioClips.Length];
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
        }

        PlayNextClip();
    }

    void Update()
    {
        if (!audioSources[currentClipIndex].isPlaying)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSources[currentClipIndex].Play();

            currentClipIndex++;
        }
        else
        {
            
        }
    }
}