using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleParentScript : MonoBehaviour {


    public List<ParticleSystem> childrenParticles;

    private void Start()
    {
        foreach (ParticleSystem particle in GetComponentsInChildren<ParticleSystem>())
        {
            childrenParticles.Add(particle);
        }
    }

    public void StartParticle()
    {
        foreach (ParticleSystem particle in childrenParticles)
        {
            particle.Play();
        }
    }
}
