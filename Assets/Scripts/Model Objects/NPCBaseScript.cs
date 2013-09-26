using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

abstract public class NPCBaseScript : WorldObjectScript
{

    public int betChance = 50;

    public override void Start()
    {
        base.Start();
    }

    override public void Update()
    {
        base.Update();
        if (UnityEngine.Random.Range(0, betChance) == 0 && dollarBillz > 0)
        {
            IncreaseBet();
        }
    }
}