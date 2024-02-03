using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleBackFireHandle : MonoBehaviour
{

    private float particleEmissionRate = 0f;

    private PlayerMovement playerMovement;

    private ParticleSystem particleSystemBackFire;
    private ParticleSystem.EmissionModule particleSystemEmissionModule;


    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        particleSystemBackFire = GetComponentInParent<ParticleSystem>();
        particleSystemEmissionModule = particleSystemBackFire.emission;
        particleSystemEmissionModule.rateOverTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if(playerMovement.IsGoStraight(out bool isStraighting))
        {
            if (isStraighting)
            {
                particleEmissionRate = 30;
            }
            else
            {
                particleEmissionRate = Mathf.Abs(0) * 2;
            }
        }
        
    }
}
