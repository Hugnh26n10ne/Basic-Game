using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPoliceController : SFXController
{
    [SerializeField] private float maxDistance = 10f;
    void Update()
    {
        UpdateAlarmLightSFX();
    }

    public virtual void UpdateAlarmLightSFX()
    {
        if (!GameManager.startGame || PlayerController.instance.playerStats.hp < 0)
        {
            alarmLightAudio.volume = 0;
            return;
        }

        float distanceToPolice = Vector3.Distance(PlayerController.instance.transform.position, transform.position);

        // Giới hạn khoảng cách tối đa
        float clampedDistance = Mathf.Min(distanceToPolice, maxDistance);

        // Tính toán âm lượng dựa trên khoảng cách giới hạn
        float desiredEngineVolume = Mathf.Lerp(1f, 0.2f, Mathf.Clamp01(clampedDistance / maxDistance));

        // Giả định maxDistance là khoảng cách tối đa bạn muốn có ảnh hưởng tới âm lượng

        alarmLightAudio.volume = Mathf.Lerp(alarmLightAudio.volume, desiredEngineVolume, Time.deltaTime * 10);

    }
}
