using UnityEngine;

public class SFXManager : SingletonMonoBehaviour<SFXManager>
{
    public AudioSource[] audioSources;

    public void Play(AudioClip clip, Vector3 position)
    {
        AudioSource freeAudioSource = FindFreeAudioSource();

        freeAudioSource.transform.position = position;
        freeAudioSource.clip = clip;
        freeAudioSource.Play();
    }

    private AudioSource FindFreeAudioSource()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }

        Debug.LogError($"Слишком много звуков!");
        return null;
    }
}
