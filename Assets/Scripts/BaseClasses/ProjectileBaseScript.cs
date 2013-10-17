﻿using UnityEngine;
using System.Collections;
using Constants;

[RequireComponent(typeof(Rigidbody))]

abstract public class ProjectileBaseScript : AbilityInstanceBaseScript
{
    /// <summary>
    /// Basic projectile class.
    /// Defaults to Kinematic Rigidbody Trigger Collider.
    /// Changes to Rigidbody Trigger Collider if flagged as physics projectile (e.g. arrow)
    /// 
    /// NOTES: Projectiles collide with colliders tagged "Hitbox", but only affect
    /// objects with CompetitorModules (any child of CompetitorBaseScript)
    /// </summary>
    
    [Range(1.0f, 50.0f)]
    public float projectileSpeed;
    protected Vector3 direction;
    public bool physicsProjectile;

    public virtual void Start()
    {
        base.Start();
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
        direction.Normalize();
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public virtual void Update()
    {
        base.Update();

        if (physicsProjectile)
        {
            // Physics movement occurs @ init
        }
        else
        {
            transform.Translate(new Vector3(1, 0, 0) * projectileSpeed * Time.deltaTime);
        }
    }

    public void FixedUpdate()
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            CompetitivePlayerBaseScript target = (CompetitivePlayerBaseScript)other.transform.parent.GetComponent<CompetitivePlayerBaseScript>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag.StartsWith("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
