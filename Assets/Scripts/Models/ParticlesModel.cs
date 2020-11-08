using UnityEngine;

public class ParticlesModel : MonoBehaviour
{
    public ParticleSystem DeathSimpleBug;
    public ParticleSystem DeathShieldBug;
    public ParticleSystem DeathAcidMushroom;
    public ParticleSystem DeathFrozenMushroom;
    public void PlayParticle(ParticleSystem Particles, Vector3 Position) 
    {
        Instantiate(Particles, Position, Quaternion.identity);
    }
}
