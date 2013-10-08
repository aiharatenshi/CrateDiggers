using UnityEngine;
using System.Collections.Generic;
using Constants;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimerScript))]

abstract public class AbilitySlotBaseScript : MonoBehaviour
{
    /// <summary>
    /// Basic projectile ability class. Fires attached ammo type @ firerate
    /// in the direction the source obj is "aiming" (Vec3)
    /// Plays sound on fire.
    /// </summary>

    public ProjectileBaseScript projectileType;
    public AudioClip sound;
    [Range(0.05f, 2.0f)]
    public float fireRate;
    private TimerScript fireRateTimer;
    public float spread;
    public List<AbilityConstants.properties> abilityProps;


    // TODO: Reload mechanics.

    public virtual void Start()
    {
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent("AudioSource");
        }
        if (gameObject.GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent("TimerScript");
        }
        fireRateTimer = GetComponent<TimerScript>();
        audio.clip = sound;

        abilityProps = new List<AbilityConstants.properties>();
    }

    public virtual void Update()
    {

    }

    public void Shoot(Vector3 direction)
    {
        if (!fireRateTimer.IsTimerActive(0))
        {
            ProjectileBaseScript projectile = (ProjectileBaseScript)Instantiate(projectileType, transform.position, Quaternion.identity);
            projectile.SetDirection(direction);
            audio.Play();
            fireRateTimer.StartTimer(fireRate);
 
            /* NOTE: Projectiles need to ignore the source object's "movement" collider AND its hitbox collider
             * Player (instance) >> Abilities (empty container obj) >> Ability Slot (this)
             * Player (instance) >> Hitbox
             * 
             * Either this collider setup needs to be standard, or we need to include failsafes to check for different configs
             * otherwise transform.parent calls can throw nullptr exceptions
             */
            Physics.IgnoreCollision(transform.parent.transform.parent.collider, projectile.collider, true);
            Physics.IgnoreCollision(transform.parent.transform.parent.GetComponentInChildren<HitboxBaseScript>().collider, projectile.collider, true);
        }
    }
}
