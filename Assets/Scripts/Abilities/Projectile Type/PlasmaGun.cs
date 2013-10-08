using UnityEngine;
using System.Collections;
using Constants;

public class PlasmaGun : ProjectileAbilityBaseScript
{

    public override void Start()
    {
        base.Start();
        cooldown = AbilityConstants.PlasmaGunCooldown;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector3 direction)
    {
        base.Use(direction);
    }
}
