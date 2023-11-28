using UnityEngine;

public class VoiceGuide : MonoBehaviour
{
    private AudioSource[] audioSources;
    private int currentAudioIndex = 0;

    void Start()
    {
        // deactivate the VoiceGuide
        gameObject.SetActive(false);
        audioSources = GetComponentsInChildren<AudioSource>();
        // TODO: Change AudioChip "Step1/2/3/4" according to the recipe
    }

    void Update()
    {
        // if the VoiceGuide is active, do the following: 
        // TODO:change the sequence of the audioSources according to the recipe and also the timer
        if (gameObject.activeSelf && currentAudioIndex < audioSources.Length)
        {
            if (!audioSources[currentAudioIndex].isPlaying)
            {
                audioSources[currentAudioIndex].Play();
                currentAudioIndex++;
            }
        }
    }
}
