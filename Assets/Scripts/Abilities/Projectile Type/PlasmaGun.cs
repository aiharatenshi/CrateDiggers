using UnityEngine;
using System.Collections;
using Constants;

public class PlasmaGun : ProjectileAbilityBaseScript
{

    public override void Start()
    {
        base.Start();
        projectileType = (ProjectileBaseScript)Resources.Load(AbilityConstants.PREFAB_NAMES[AbilityConstants.type.PlasmaBullet], typeof(ProjectileBaseScript));
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
