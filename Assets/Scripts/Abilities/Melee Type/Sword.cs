using UnityEngine;
using System.Collections;

public class Sword : MeleeWeaponBaseScript
{

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
