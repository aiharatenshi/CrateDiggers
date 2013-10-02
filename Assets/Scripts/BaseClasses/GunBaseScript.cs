using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimerScript))]

abstract public class GunBaseScript : MonoBehaviour
{
    /// <summary>
    /// Basic projectile weapon class. Fires attached ammo type @ firerate
    /// in the direction the source obj is "aiming" (Vec3)
    /// Plays sound on fire.
    /// </summary>

    public ProjectileBaseScript projectileType;
    public AudioClip sound;
    [Range(0.05f, 2.0f)]
    public float fireRate;
    private TimerScript fireRateTimer;
    public float spread;

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
    }

    public virtual void Update()
    {

    }

    public void Shoot(Vector3 dir)
    {
        if (!fireRateTimer.isActive)
        {
            ProjectileBaseScript projectile = (ProjectileBaseScript)Instantiate(projectileType, transform.position, transform.rotation);
            projectile.SetDirection(dir);
            audio.Play();
            fireRateTimer.StartTimer(fireRate);
 
            /* NOTE: Projectiles need to ignore the source object's "movement" collider AND its hitbox collider
             * Player (instance) >> Weapons (empty container obj) >> Gun (this)
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
