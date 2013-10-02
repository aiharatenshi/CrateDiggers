using UnityEngine;
using System.Collections;

abstract public class NPCBaseScript : WorldObjectScript
{

    public int betChance = 4; // 1/n chance of betting ever polling period
    public float bettingPollingPeriod = 1; // In seconds
    private bool flagForRespawn;

    public override void Start()
    {
        base.Start();
    }

    override public void Update()
    {
        base.Update();
        if (!timer.isActive)
        {
            timer.StartTimer(bettingPollingPeriod);
            if (UnityEngine.Random.Range(0, betChance) == 0 && dollarBillz > 0)
            {
                IncreaseBet();
            }
        }

        switch (health)
        {
            case 0:
                flagForRespawn = true;
                break;
        }
    }

    public void FixedUpdate()
    {
        if (flagForRespawn)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        flagForRespawn = false;
        rigidbody.AddForce(Vector3.zero, ForceMode.VelocityChange);
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            flagForRespawn = true;
        }
    }
}