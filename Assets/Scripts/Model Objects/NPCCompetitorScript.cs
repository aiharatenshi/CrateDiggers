using UnityEngine;
using System.Collections;

abstract public class NPCCompetitorBaseScript : CompetitorBaseScript
{

    public int betChance = 4; // 1/n chance of betting ever polling period
    public float bettingPollingPeriod = 1; // In seconds

    public override void Start()
    {
        base.Start();
    }

    override public void Update()
    {
        base.Update();
        if (!timer.IsTimerActive(0))
        {
            timer.StartTimer(bettingPollingPeriod);
            if (UnityEngine.Random.Range(0, betChance) == 0 && purse.dollarBillz > 0)
            {
                BettingManagerScript.IncreaseBet(purse);
            }
        }
    }

    public void FixedUpdate()
    {
        if (competitorModule.flagForRespawn)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        competitorModule.flagForRespawn = false;
        rigidbody.AddForce(Vector3.zero, ForceMode.VelocityChange);
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            competitorModule.FlagForRespawn();
        }
    }
}