using UnityEngine;

public class ParticlesModel : MonoBehaviour
{
    public Transform ParticlesSpawnPoint;
    public ParticleSystem DeathSimpleBug;
    public ParticleSystem DeathShieldBug;
    public ParticleSystem DeathAcidMushroom;
    public ParticleSystem DeathFrozenMushroom;

    [HideInInspector] public ParticleSystem DeathSimpleBugPrepared;
    [HideInInspector] public ParticleSystem DeathShieldBugPrepared;
    [HideInInspector] public ParticleSystem DeathAcidMushroomPrepared;
    [HideInInspector] public ParticleSystem DeathFrozenMushroomPrepared;

    public void PreapreParticles() 
    {
        DeathSimpleBugPrepared = Instantiate(DeathSimpleBug, ParticlesSpawnPoint);
        DeathSimpleBugPrepared.Stop();
        DeathShieldBugPrepared = Instantiate(DeathShieldBug, ParticlesSpawnPoint);
        DeathShieldBugPrepared.Stop();
        DeathAcidMushroomPrepared = Instantiate(DeathAcidMushroom, ParticlesSpawnPoint);
        DeathAcidMushroomPrepared.Stop();
        DeathFrozenMushroomPrepared = Instantiate(DeathFrozenMushroom, ParticlesSpawnPoint);
        DeathFrozenMushroomPrepared.Stop();
    }
    public void PlayParticle(ParticleSystem Particles) 
    {
        Particles.Play();
    }
}
