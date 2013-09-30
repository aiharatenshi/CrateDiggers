using UnityEngine;
using System.Collections;

public class TurretBaseScript : MonoBehaviour {

    private GunBaseScript gun;
    private PlayerBaseScript target;
    private Vector3 aimDirection;

	// Use this for initialization
	void Start () {
        gun = GetComponentInChildren<GunBaseScript>();
	}
	
	// Update is called once per frame
	void Update () {
        target = (PlayerBaseScript)FindObjectOfType(typeof(PlayerBaseScript));
        aimDirection = target.transform.position - gameObject.transform.position;
        gun.Shoot(aimDirection);
	}
}
