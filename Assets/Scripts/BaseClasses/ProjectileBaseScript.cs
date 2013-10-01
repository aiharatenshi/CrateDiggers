using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

abstract public class ProjectileBaseScript : MonoBehaviour
{

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
        if (physicsProjectile)
        {
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
        if (Time.time - spawnTime > lifetime || transform.position.z < -20)
        {
            Destroy(gameObject);
        }

        if (physicsProjectile)
        {
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

    public void OnCollisionEnter(Collision collision) // TODO: Need to fix collision handling (standardize method of referencing collider -- on obj or on child object?)
    {
        if (collision.gameObject.CompareTag("InteractiveObject") || collision.gameObject.CompareTag("Player"))
        {
            WorldObjectScript target = (WorldObjectScript)collision.gameObject.GetComponent<WorldObjectScript>();
            target.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Hit");
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractiveObject") || other.gameObject.CompareTag("Player"))
        {
            WorldObjectScript target = (WorldObjectScript)other.transform.parent.GetComponent<WorldObjectScript>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
