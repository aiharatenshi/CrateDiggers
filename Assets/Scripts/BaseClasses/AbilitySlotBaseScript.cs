using UnityEngine;
using System.Collections.Generic;
using Constants;
using Constants;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimerScript))]

abstract public class AbilitySlotBaseScript : MonoBehaviour
{

    /// <summary>
    /// Abstract class for abilities.
    /// 
    /// Contains audoSource, timer & cooldown.
    /// </summary>


    public AudioClip sound;
    public float cooldown;
    public TimerScript cooldownTimer;
    public List<AbilityConstants.properties> abilityProps;
    protected int cooldownTimerNumber;

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
        cooldownTimer = GetComponent<TimerScript>();
        audio.clip = sound;

        abilityProps = new List<AbilityConstants.properties>();
    }

    public virtual void Update()
    {

    }

    public abstract void Use();

    public abstract void Use(Vector3 direction);


}
