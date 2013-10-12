using UnityEngine;
using System.Collections;
using Constants;

public class ShieldInstanceScript : AbilityInstanceBaseScript
{

    CompetitorBaseScript shieldedPlayer;

    public override void Start()
    {
        base.Start();
        lifetime = AbilityConstants.ShieldDefaultLifetime;
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

    public void SetPlayer(CompetitorBaseScript target)
    {
        shieldedPlayer = target;
    }

}
