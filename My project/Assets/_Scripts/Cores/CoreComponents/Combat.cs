using UnityEngine;


public class Combat : CoreComponent, IDamageable
{
    // [SerializeField] private GameObject damageParticles;

    private Stats stats;
    // private ParticleManager particleManager;

    protected override void Awake()
    {
        base.Awake();

        stats = core.GetCoreComponent<Stats>();
        // particleManager = core.GetCoreComponent<ParticleManager>();
    }

    public void Damage(float amount)
    {
        Debug.Log(core.transform.parent.name + " Damaged!");
        stats.Health.Decrease(amount);
        Debug.Log(stats.Health.CurrentValue);
        // particleManager.StartParticlesWithRandomRotation(damageParticles);
    }

}