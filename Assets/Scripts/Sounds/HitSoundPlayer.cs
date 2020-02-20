using UnityEngine;

public class HitSoundPlayer : MonoBehaviour
{
    public AudioClip HitClip;

    public void Play()
    {
        SFXManager.Instance.Play(HitClip, transform.position);
    }
}
