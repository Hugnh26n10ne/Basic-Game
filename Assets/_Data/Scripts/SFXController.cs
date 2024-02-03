using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [Header("Audio sources")]

    public AudioSource tiresScreechingAudioSource;
    public AudioSource engineAudioSource;
    public AudioSource carHitAudioSource;
    public AudioSource brakingAudioSource;
    public AudioSource alarmLightAudio;

    protected float desiredEnginePitch = 0.5f;
    protected float tireScreechingPitch = 0.5f;
    protected float carHitAudioPitch = 0.5f;
    protected float brakingPitch = 0.5f;

    protected PlayerMovement playerMovement;

    // Start is called before the first frame update
    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        float relativeVelocity = collision.relativeVelocity.magnitude;

        float volume = relativeVelocity * 0.1f;

        carHitAudioSource.volume = volume;
        carHitAudioPitch = Random.Range(0.95f, 1.05f);

        if (!carHitAudioSource.isPlaying)
        {
            carHitAudioSource.Play();
        }
    }
}
