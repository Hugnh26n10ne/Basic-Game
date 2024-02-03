using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleSmokeHandle : MonoBehaviour
{
    private float particleEmissionRate = 0;

    private PlayerMovement playerMovement;

    private ParticleSystem particleSystemSmoke;
    private ParticleSystem.EmissionModule particleSystemEmissionModule;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();

        particleSystemSmoke = GetComponentInParent<ParticleSystem>();

        particleSystemEmissionModule = particleSystemSmoke.emission;

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


        if(playerMovement.IstireScreeching(out float lateralVelocity, out bool isBreaking))
        {
            if (isBreaking)
            {
                particleEmissionRate = 30;
            }
            else
            {
                particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
            }
        }
    }
}
