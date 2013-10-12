using UnityEngine;
using System.Collections;
using Constants;

public class ShieldAbilityScript : AreaEffectAbilityBaseScript
{
    /// <summary>
    /// Basic shield ability. Instantiates a Shield prefab on use.
    /// </summary>
    /// 

    public override void Start()
    {
        base.Start();
        areaOfEffect = AbilityConstants.ShieldDefaultArea;

    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    public void Use(CompetitorBaseScript target)
    {
        if (!cooldownTimer.IsTimerActive(cooldownTimerNumber))
        {
            ShieldInstanceScript shield = (ShieldInstanceScript)Instantiate(Resources.Load(AbilityConstants.PREFAB_NAMES[AbilityConstants.type.Shield], typeof(ShieldInstanceScript)), transform.position, Quaternion.identity);
            shield.SetPlayer(target);
            cooldownTimerNumber = cooldownTimer.StartTimer(AbilityConstants.ShieldDefaultCooldown);
        }

    }

    public override void Use(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

}
