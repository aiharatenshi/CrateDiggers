using UnityEngine;
using System.Collections;
using System;

public class PlayerRPSChoice : TextMeshBaseScript
{

    public override void Start()
    {
        base.Start();
        textMesh.text = "Press F";
    }

    public override void Update()
    {
        base.Update();
    }

    public void NotifyChange()
    {
        timer.StartTimer(defaultDisplayTime);
    }

}