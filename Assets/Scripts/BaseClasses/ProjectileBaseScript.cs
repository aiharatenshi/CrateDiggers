﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

abstract public class ProjectileBaseScript : MonoBehaviour
{
    /// <summary>
    /// Basic projectile class.
    /// Defaults to Kinematic Rigidbody Trigger Collider.
    /// Changes to Rigidbody Trigger Collider if flagged as physics projectile (e.g. arrow)
    /// </summary>
    [Range(1.0f, 50.0f)]
    public float projectileSpeed;
    public int damage;
    protected float size;
    public float lifetime;
    protected Vector3 direction;
    private float spawnTime;
    public bool physicsProjectile;

    public virtual void Start()
    {
        spawnTime = Time.time;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rigidbody.isKinematic = true;
        collider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Hitboxes");
        gameObject.tag = "Projectile";
        if (physicsProjectile)
        {
            rigidbody.isKinematic = false;
            direction.Normalize();
            direction.z = 0;
            rigidbody.AddForce(projectileSpeed * direction, ForceMode.VelocityChange);
        }
    }

    public virtual void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public virtual void Update()
    {
        if (Time.time - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }

        if (physicsProjectile)
        {
            // Physics movement occurs @ init
        }
        else
        {
            direction.Normalize();
            direction.z = 0;
            transform.Translate(projectileSpeed * direction * Time.deltaTime);
        }
    }

    public void FixedUpdate()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            WorldObjectScript target = (WorldObjectScript)other.transform.parent.GetComponent<WorldObjectScript>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
