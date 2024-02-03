using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailRendererHandle : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        trailRenderer = GetComponent<TrailRenderer>();

        trailRenderer.emitting = false;
    }

    void Update()
    {
        if (playerMovement.IstireScreeching(out float lateralVelocity, out bool isBreaking))
            trailRenderer.emitting = true;
        else trailRenderer.emitting = false;


        
    }



}
