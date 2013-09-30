using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimerScript))]

abstract public class GunBaseScript : MonoBehaviour
{

    public ProjectileBaseScript projectileType;
    public AudioClip sound;
    public float fireRate;
    private TimerScript fireRateTimer;
    public float spread;

    // Use this for initialization
    public virtual void Start()
    {
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent("AudioSource");
        }
        if (gameObject.GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent("TimerScript");
        }
        fireRateTimer = GetComponent<TimerScript>();
        audio.clip = sound;
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public void Shoot(Vector3 dir)
    {
        if (!fireRateTimer.isActive)
        {
            ProjectileBaseScript projectile = (ProjectileBaseScript)Instantiate(projectileType, transform.position, transform.rotation);
            projectile.SetDirection(dir);
            audio.Play();
            fireRateTimer.StartTimer(fireRate);
        }
    }
}
