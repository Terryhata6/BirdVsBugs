using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    private ParticlesModel _particles;

    private void Awake()
    {
        _particles = FindObjectOfType<ParticlesModel>();
    }
    public void PlaySimpleBugParticles(Vector3 Position)
    {
        _particles.PlayParticle(_particles.DeathSimpleBug, Position);
    }
    public void PlayArmoredBugParticles(Vector3 Position)
    {
        _particles.PlayParticle(_particles.DeathShieldBug, Position);
    }
    public void PlayAcidMushroomsParticles(Vector3 Position)
    {
        _particles.PlayParticle(_particles.DeathAcidMushroom, Position);
    }
    public void PlayFrozenMushroomsParticles(Vector3 Position)
    {
        _particles.PlayParticle(_particles.DeathFrozenMushroom, Position);
    }
}
