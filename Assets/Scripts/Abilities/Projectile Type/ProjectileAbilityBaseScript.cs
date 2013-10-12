using UnityEngine;
using System.Collections;

public class ProjectileAbilityBaseScript : AbilitySlotBaseScript
{

    /// <summary>
    /// Basic projectile ability class. Fires attached ammo type @ firerate
    /// in the direction the source obj is "aiming" (Vec3)
    /// Plays sound on fire.
    /// </summary>

    public ProjectileBaseScript projectileType;
    int cooldownTimerNumber;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {

    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector3 direction)
    {
        if (!cooldownTimer.IsTimerActive(cooldownTimerNumber))
        {
            ProjectileBaseScript projectile = (ProjectileBaseScript)Instantiate(projectileType, transform.position, Quaternion.identity);
            projectile.SetDirection(direction);
            audio.Play();
            cooldownTimerNumber = cooldownTimer.StartTimer(cooldown);

            /* NOTE: Projectiles need to ignore the source object's "movement" collider AND its hitbox collider
             * Player (instance) >> Abilities (empty container obj) >> Ability Slot (this)
             * Player (instance) >> Hitbox
             */
            Physics.IgnoreCollision(transform.parent.transform.parent.collider, projectile.collider, true);
            Physics.IgnoreCollision(transform.parent.transform.parent.GetComponentInChildren<HitboxBaseScript>().collider, projectile.collider, true);
        }
    }
}
