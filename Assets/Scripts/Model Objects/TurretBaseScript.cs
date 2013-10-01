﻿using UnityEngine;
using System.Collections;

public class TurretBaseScript : MonoBehaviour {

    private GunBaseScript gun;
    private PlayerBaseScript target;
    private Vector3 aimDirection;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        gun = GetComponentInChildren<GunBaseScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            target = (PlayerBaseScript)FindObjectOfType(typeof(PlayerBaseScript));
        }
        else
        {
            aimDirection = target.transform.position - gameObject.transform.position;
            gun.Shoot(aimDirection);
            aimDirection.Normalize();
            aimDirection.z = 0;
            transform.Translate(moveSpeed * aimDirection * Time.deltaTime);
        }
	}
}
