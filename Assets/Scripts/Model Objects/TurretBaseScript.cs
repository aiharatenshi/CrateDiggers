﻿using UnityEngine;
using System.Collections;

public class TurretBaseScript : WorldObjectScript
{

    private AbilitySlotBaseScript abilitySlot;
    private PlayerBaseScript target;
    public Vector3 aimDirection;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        abilitySlot = GetComponentInChildren<AbilitySlotBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = (PlayerBaseScript)FindObjectOfType(typeof(PlayerBaseScript));
        }
        else
        {
            aimDirection = target.transform.position - gameObject.transform.position;
            Debug.DrawRay(transform.position, aimDirection, Color.red);
            abilitySlot.Use(aimDirection);
            MoveTowardTarget();
        }

        switch (health)
        {
            case 0:
                Destroy(gameObject);
                break;
        }
    }

    public void MoveTowardTarget()
    {
        aimDirection.Normalize();
        aimDirection.z = 0;
        transform.Translate(moveSpeed * aimDirection * Time.deltaTime);
    }

    public override void ReceiveInteractionHandshake()
    {
        throw new System.NotImplementedException();
    }

    public override void InteractionClose()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        throw new System.NotImplementedException();
    }
}
