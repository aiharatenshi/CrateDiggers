using UnityEngine;
using System.Collections;

abstract public class GunBaseScript : MonoBehaviour
{

    public ProjectileBaseScript projectileType;

    // Use this for initialization
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public void Shoot() 
    {
        Instantiate(projectileType, transform.position, transform.rotation);
    }
}
