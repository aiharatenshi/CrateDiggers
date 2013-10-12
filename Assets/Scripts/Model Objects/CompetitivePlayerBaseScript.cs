using UnityEngine;
using System.Collections.Generic;
using System;
using Constants;

[RequireComponent(typeof(Rigidbody))]

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

    public BallBaseScript ball;

    // Parameters
    [Range(0.1f, 15.0f)]
    public int moveSpeed;
    [Range(1.0f, 50.0f)]
    public int jumpMagnitude;
    [Range(0.1f, 15.0f)]
    public int moveSpeedAir;
    public int moveSpeedDefault; // This should be private, but needs to be public to test movespeeds during play
    [Range(0.0f, 30.0f)]
    public int maxVelocity;

<<<<<<< Updated upstream
<<<<<<< HEAD:Assets/Scripts/Model Objects/PlayerBaseScript.cs
    public WorldObjectScript interactionTarget = null;
    public WorldAreaScript currentArea = null;
    private static RockPaperScissors rpsGame = null;
    public bool touchingGround = true;
    public Vector3 aimDirection;
    public Camera cam;
    public AbilitySlotBaseScript abilitySlot;
    public MeleeWeaponBaseScript meleeWeapon;
    public ProjectileBaseScript ammo;
=======
=======
    //TODO:ADD HEALTH AND DEATH CHECK INTO THIS CLASS

>>>>>>> Stashed changes
    // Audio
>>>>>>> Aaron:Assets/Scripts/Model Objects/CompetitivePlayerBaseScript.cs
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip landClip;
    public AudioClip walkClip;

    // Modules
    public AbilitySlotBaseScript[] abilitySlot = new AbilitySlotBaseScript[3];

    // Extras
    private enum walk { left, right }
    public bool touchingGround = true;
    public Vector3 aimDirection;
    private bool holdingBall;


<<<<<<< Updated upstream
    public List<AbilityConstants.properties> charProperties;

    public override void Start()
=======
    public void Start()
>>>>>>> Stashed changes
    {
        //base.Start();
        SetupDependencies();
        moveSpeedDefault = moveSpeed;

        tk2dSprite sprite = GetComponentInChildren<tk2dSprite>();
<<<<<<< HEAD:Assets/Scripts/Model Objects/PlayerBaseScript.cs
        sprite.collider.enabled = false;

        charProperties = new List<AbilityConstants.properties>();
=======
        sprite.collider.enabled = false;    // Need to disable the sprite collider (we're not using the player sprite for collisions)
>>>>>>> Aaron:Assets/Scripts/Model Objects/CompetitivePlayerBaseScript.cs
    }

    // Update is called once per frame
    public void Update()
    {
        //base.Update();

        aimDirection = new Vector3(gamepad.leftStick.x, gamepad.leftStick.y, 0);
        Debug.DrawRay(gameObject.transform.position, aimDirection * 5, Color.red);

        HandleInput();

        if (ball != null)
        {
            holdingBall = true;
        }
        else
        {
            holdingBall = false;
        }
            
        //TODO:REIMPLEMENT RESPAWNING
        /*
        if (competitorModule.flagForRespawn)
        {
            Respawn();
        }
        */
    }

    //TODO:REIMPLEMENT RESPAWNING
    public virtual void FixedUpdate()
    {
        HandleFixedInput();
        /*
        if (competitorModule.flagForRespawn)
        {
            Respawn();
        }
        */
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

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.RB])
        {
            
        }

        if (gamepad.rightTriggerDown)
        {
            UseAbilitySlotOne();
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.x])
        {
            
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.y])
        {
            //TODO: IMPLEMENT DROP BALL()
            ball.DetachFromPlayer();
            ball = null;
        }
    }

    public virtual void HandleFixedInput()
    {
        if (gamepad.button[(int)CharacterConstants.buttons.a])
        {
            Jump();
        }

        if (gamepad.leftStick.x < 0)
        {
            Walk(walk.left);
        }

        if (gamepad.leftStick.x > 0)
        {
            Walk(walk.right);
        }
    }

    public virtual void HandleInput(KeyCode key) { }

    public void Respawn()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;

        //competitorModule.flagForRespawn = false;
        audio.clip = deathClip;
        audio.Play();
    }

    // TODO: Move to CompetitorModule?
    public void TakeDamage(int amount)
    {
        //competitorModule.TakeDamage(amount);
        //competitorModule.DropBall();
    }

    private void UseAbilitySlotOne()
    {
        if (ball == null)
        {
            abilitySlot[0].Use(aimDirection);
        }

        if (ball)
        {
            ball.DetachFromPlayer();
            ball = null;
        }
    }

    private void UseAbilitySlotTwo()
    {
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
    }

}