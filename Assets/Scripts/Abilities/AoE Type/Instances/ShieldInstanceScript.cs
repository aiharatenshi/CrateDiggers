using UnityEngine;
using System.Collections;
using Constants;

public class ShieldInstanceScript : AbilityInstanceBaseScript
{

    CompetitivePlayerBaseScript shieldedPlayer;

    public override void Start()
    {
        base.Start();
        lifetime = AbilityConstants.shieldDefaultLifetime;
        gameObject.tag = "Shield";
    }

    public override void Update()
    {
        base.Update();
        transform.position = shieldedPlayer.transform.position;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }

    public void SetPlayer(CompetitivePlayerBaseScript target)
    {
        shieldedPlayer = target;
    }

}
