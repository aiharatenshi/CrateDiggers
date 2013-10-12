using UnityEngine;
using System.Collections;

public class PlasmaBullet : ProjectileBaseScript
{

    // Use this for initialization
    void Start()
    {
        base.Start();
        lifetime = Constants.AbilityConstants.PlasmaGunCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

}
