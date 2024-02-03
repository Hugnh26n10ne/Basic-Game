using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayerController : SFXController
{
    void Update()
    {
        UpdateEngineSFX();
        UpdateTireScreechingSFX();
        UpdateBrakingSFX();
    }

    public virtual void UpdateEngineSFX()
    {
        float velocityMagnitude = playerMovement.GetVelocityMagnitude();

        float desiredEngineVolume = velocityMagnitude * 0.05f;

        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1f);

        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        desiredEnginePitch = velocityMagnitude * 0.2f;

        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);

        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }


    public virtual void UpdateTireScreechingSFX()
    {
        if (playerMovement.IstireScreeching(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
            {
                tiresScreechingAudioSource.volume = Mathf.Lerp(tiresScreechingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScreechingPitch = Mathf.Lerp(tireScreechingPitch, 0.5f, Time.deltaTime * 10);
                brakingAudioSource.volume = Mathf.Lerp(brakingAudioSource.volume, 0, Time.deltaTime * 10);
            }
            else
            {
                tiresScreechingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tireScreechingPitch = Mathf.Abs(lateralVelocity) * 0.1f;
                brakingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        }
        else
        {
            tiresScreechingAudioSource.volume = Mathf.Lerp(tiresScreechingAudioSource.volume, 0, Time.deltaTime * 10);
        }
    }

    public virtual void UpdateBrakingSFX()
    {
        if (playerMovement.IsGoStraight(out bool isStraighting))
        {
            if (isStraighting)
            {
                brakingAudioSource.volume = Mathf.Lerp(brakingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                brakingPitch = Mathf.Lerp(brakingPitch, 0.5f, Time.deltaTime * 10);
            }
        }
        else
        {
            brakingAudioSource.volume = Mathf.Lerp(brakingAudioSource.volume, 0, Time.deltaTime * 10);
        }
    }
}
