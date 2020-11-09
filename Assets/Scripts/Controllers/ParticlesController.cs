using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    private ParticlesModel _particles;

    private void Awake()
    {
        _particles = FindObjectOfType<ParticlesModel>();
        _particles.PreapreParticles();
    }
    public void PlaySimpleBugParticles()
    {
        _particles.PlayParticle(_particles.DeathSimpleBugPrepared);
    }
    public void PlayArmoredBugParticles()
    {
        _particles.PlayParticle(_particles.DeathShieldBugPrepared);
    }
    public void PlayAcidMushroomsParticles()
    {
        _particles.PlayParticle(_particles.DeathAcidMushroomPrepared);
    }
    public void PlayFrozenMushroomsParticles()
    {
        _particles.PlayParticle(_particles.DeathFrozenMushroomPrepared);
    }
    public void PlayBossParticles()
    {
        _particles.PlayParticle(_particles.DeathSimpleBugPrepared);
    }
}
