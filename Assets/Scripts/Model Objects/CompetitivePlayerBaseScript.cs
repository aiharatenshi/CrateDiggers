﻿using UnityEngine;
using System.Collections.Generic;
using System;
using Constants;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PossessionTimer))]
[RequireComponent(typeof(TimerScript))]

public class CompetitivePlayerBaseScript : MonoBehaviour
{

    /// <summary>
    /// Base class for player objects.
    /// Contains basic controller movement and interaction.
    /// 
    /// NOTE: Don't set default values for movement until we find something
    /// we actually like.
    /// </summary> 

    public GamepadInfo gamepad;

    public string playerName;

    public BallBaseScript ball;

    // Parameters
    [Range(0.1f, 8.0f)]
    public float moveSpeed;
    [Range(1.0f, 20.0f)]
    public int jumpMagnitude;
    [Range(0.1f, 1.0f)]
    public float moveSpeedAir;
    public float moveSpeedDefault; // This should be private, but needs to be public to test movespeeds during play
    [Range(0.0f, 30.0f)]
    public int maxVelocity;

    private bool flagForRespawn;
    private int health;
    private int startingHealth = CharacterConstants.playerHealth;
    public PossessionTimer possessionTimer;

    //State
    private bool acceptingInput;
    private bool startFrozen = false;
    private CharacterConstants.state state;
    private int freezeTimer;


    // Audio
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip landClip;
    public AudioClip walkClip;

    // Modules
    public AbilitySlotBaseScript[] abilitySlot = new AbilitySlotBaseScript[3];
    public TimerScript timer;

    // Extras
    private enum walk { left, right, up, down }
    public bool touchingGround = true;
    public Vector3 aimDirection;
    private bool holdingBall;


    public List<AbilityConstants.properties> charProperties;

    public void Start()
    {
        //base.Start();
        SetupDependencies();
        moveSpeedDefault = moveSpeed;

        tk2dSprite sprite = GetComponentInChildren<tk2dSprite>();

        charProperties = new List<AbilityConstants.properties>();
        sprite.collider.enabled = false;    // Need to disable the sprite collider (we're not using the player sprite for collisions)

        health = startingHealth;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Math.Abs(gamepad.rightStick.magnitude) > CharacterConstants.joystickDeadzone)
        {
            aimDirection = new Vector3(gamepad.rightStick.x, gamepad.rightStick.y, 0);
        }
        Debug.DrawRay(gameObject.transform.position, aimDirection * 5, Color.red);

        if (state != CharacterConstants.state.frozen)
        {
            HandleInput();
        }


        if (ball != null)
        {
            holdingBall = true;
        }
        else
        {
            holdingBall = false;
        }



        switch (state)
        {
            case CharacterConstants.state.normal:
                if (particleSystem.isPlaying)
                {
                    particleSystem.Stop();
                }
                switch (health)
                {
                    case 0:
                        state = CharacterConstants.state.frozen;
                        startFrozen = true;
                        //state = CharacterConstants.state.dead;
                        break;
                    default:
                        break;
                }
                break;
            case CharacterConstants.state.frozen:
                if (startFrozen) // First time state hits frozen
                {
                    freezeTimer = timer.StartTimer(CharacterConstants.freezeTime);
                    startFrozen = false;
                    acceptingInput = false;
                    particleSystem.Play();
                }
                else // all other times (already frozen)
                {
                    if (!timer.IsTimerActive(freezeTimer)) // if timer is done
                    {
                        state = CharacterConstants.state.normal;
                        health = startingHealth;
                    }
                }
                break;
            case CharacterConstants.state.dead:
                flagForRespawn = true;
                break;
            default:
                break;
        }

    }

    public virtual void FixedUpdate()
    {
        if (state != CharacterConstants.state.frozen)
        {
            HandleFixedInput();
        }


        if (flagForRespawn)
        {
            Respawn();
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.StartsWith("Environment"))
        {
            touchingGround = true;
            moveSpeed = moveSpeedDefault;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            TempGameManager manager = (TempGameManager)FindObjectOfType(typeof(TempGameManager));
            if (manager.GetState() == CompWorldConstants.worldStates.matchInProgress)
            {
                ball = collision.gameObject.GetComponent<BallBaseScript>();
                ball.AttachToPlayer(this);
            }

        }
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
        }
    }

    public virtual void OnCollisionExit(Collision collision)
    {


    }


    public virtual void OnTriggerStay(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {
        //TODO:REIMPLEMENT RESPAWNING
        /*
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            competitorModule.FlagForRespawn();
        }
        */


    }

    public virtual void HandleInput()
    {

        // We can change sprite transparencies as such:
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    tk2dSprite sprite = GetComponentInChildren<tk2dSprite>();
        //    sprite.color = new Color(1, 1, 1, 0.5f);
        //}

        // We can change the gameobject.layer to play with collision layers
        //if (Input.GetKeyDown(KeyCode.PageUp))
        //{
        //    gameObject.layer = LayerMask.NameToLayer("Environment2");
        //}

        //if (Input.GetKeyDown(KeyCode.PageDown))
        //{
        //    gameObject.layer = LayerMask.NameToLayer("Environment1");
        //}

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.b])
        {
            //
        }


        if (gamepad.rightTriggerDown)
        {
            UseAbilitySlotOne();
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.RB])
        {
            UseAbilitySlotTwo();
        }

        if (gamepad.leftTrigger)
        {
            ChargeBall();
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.x])
        {

        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.y])
        {
            DropBall();
        }
    }

    public virtual void HandleFixedInput()
    {
        if (gamepad.buttonDown[(int)CharacterConstants.buttons.a])
        {
            Jump();
        }

        if (gamepad.buttonUp[(int)CharacterConstants.buttons.a])
        {
        }

        if (rigidbody.useGravity)
        {
            if (gamepad.leftStick.x < 0)
            {
                Walk(walk.left);
            }

            if (gamepad.leftStick.x > 0)
            {
                Walk(walk.right);
            }
        }
        else
        {
            WalkTopDown();
        }

    }

    public virtual void HandleInput(KeyCode key) { }

    public void Respawn()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        health = startingHealth;
        flagForRespawn = false;
        audio.clip = deathClip;
        audio.Play();
    }

    // TODO: Move to CompetitorModule?
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (ball) DropBall();
        //particleSystem.Play();
    }

    public void DropBall()
    {
        ball.DetachFromPlayer();
        ball = null;
    }

    private void ChargeBall()
    {
        possessionTimer.IncreaseTime();
    }

    private void UseAbilitySlotOne()
    {
        if (ball == null)
        {
            GetComponentInChildren<ProjectileAbilityBaseScript>().Use(aimDirection);
        }

        if (ball)
        {
            GetComponentInChildren<PassBall>().Pass(aimDirection, ball, this);
            ball = null;
        }
    }

    private void UseAbilitySlotTwo()
    {
        GetComponentInChildren<ShieldAbilityScript>().Use(this);
    }

    private void UseAbilitySlotThree()
    {
    }

    private void Walk(walk leftOrRight)
    {
        // TODO: Modify walk speed by magnitude of joystick vector?

        if (leftOrRight == walk.left)
        {
            if (rigidbody.velocity.x > -maxVelocity)
            {
                rigidbody.AddForce(Vector3.left * moveSpeed, ForceMode.VelocityChange);
            }

        }
        else if (leftOrRight == walk.right)
        {
            if (rigidbody.velocity.x < maxVelocity)
            {
                rigidbody.AddForce(Vector3.right * moveSpeed, ForceMode.VelocityChange);
            }
        }

        audio.clip = walkClip;
        audio.Play();
    }

    /// <summary>
    /// This is the walk method for ZeroGrav/TopDown style movement
    /// </summary>
    private void WalkTopDown()
    {
        if (rigidbody.velocity.sqrMagnitude < maxVelocity * maxVelocity)
        {
            rigidbody.AddForce(gamepad.leftStick.normalized * moveSpeed, ForceMode.VelocityChange);
        }
    }

    private void Jump()
    {
        if (touchingGround)
        {
            rigidbody.AddForce(Vector3.up * jumpMagnitude, ForceMode.Impulse);
            moveSpeed = moveSpeedAir;
            touchingGround = false;
            audio.clip = jumpClip;
            audio.Play();
        }
    }

    public void SetGamepad(GamepadInfo _gamepad)
    {
        // TODO: Need some way of guaranteeing the same gamepadInfo is tied to the player every time. (I think I got it fixed)
        //GamepadInfo[] gamepadInfo = FindObjectsOfType(typeof(GamepadInfo)) as GamepadInfo[];
        //gamepad = gamepadInfo[playerNumber - 1];
        gamepad = _gamepad;
    }

    protected void SetupDependencies()
    {
        abilitySlot = GetComponentsInChildren<AbilitySlotBaseScript>() as AbilitySlotBaseScript[];
        ProjectileAbilityBaseScript temp = abilitySlot[0] as ProjectileAbilityBaseScript;

        if (gameObject.GetComponent<PossessionTimer>() == null)
        {
            gameObject.AddComponent("PossessionTimer");
        }
        possessionTimer = GetComponent<PossessionTimer>();
        possessionTimer.SetPlayer(this);

        if (gameObject.GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent<TimerScript>();
        }
        timer = GetComponent<TimerScript>();

        gameObject.GetComponentInChildren<NameTextMesh>().fullName = playerName;
    }

}