using UnityEngine;
using System.Collections;

abstract public class MeleeWeaponBaseScript : AbilitySlotBaseScript
{

    // TODO: This needs to be completely revamped.

    public ProjectileBaseScript projectileType;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Use()
    {
        if (!cooldownTimer.IsTimerActive(0))
        {
            Instantiate(projectileType, transform.position, transform.rotation);
            audio.Play();
            cooldownTimer.StartTimer(cooldown);
        }
    }

    public override void Use(Vector3 direction) { }
}
