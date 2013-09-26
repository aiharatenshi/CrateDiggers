using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

abstract public class ProjectileBaseScript : MonoBehaviour {

    public float projectileSpeed;
    public int damage;
    protected float size;
    public float lifetime;
    protected Vector3 direction;
    private float spawnTime;

	public virtual void Start () {
        spawnTime = Time.time;
        direction = PlayerScript.aimDirection;
        direction.Normalize();
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //direction.Normalize();
        //direction *= projectileSpeed;
        //rigidbody.AddForce(direction, ForceMode.Impulse);
	}
	
	public virtual void Update () {
        if (Time.time - spawnTime > lifetime || transform.position.z < -20)
        {
            Destroy(gameObject);
        }
        transform.Translate(projectileSpeed * direction * Time.deltaTime);
	}

    public void FixedUpdate()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<WorldObjectScript>() )
        //{
        //    WorldObjectScript target = (WorldObjectScript)collision.gameObject.GetComponent<WorldObjectScript>();
        //    target.TakeDamage(damage);
        //    Destroy(gameObject);
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InteractiveObject") && !other.gameObject.CompareTag("Player"))
        {
            WorldObjectScript target = (WorldObjectScript)other.transform.parent.GetComponent<WorldObjectScript>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
