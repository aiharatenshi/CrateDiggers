using UnityEngine;
using System.Collections;
using System;
using Constants;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PossessionTimer))]

public class PlayerBaseScript : WorldObjectScript
{

    /// <summary>
    /// Base class for player objects.
    /// Contains basic controller movement and interaction.
    /// 
    /// NOTE: Don't set default values for movement until we find something
    /// we actually like.
    /// </summary>
    /// 

    private enum walk { left, right }

    [Range(0.1f, 15.0f)]
    public int moveSpeed;
    [Range(1.0f, 50.0f)]
    public int jumpMagnitude;
    [Range(0.1f, 15.0f)]
    public int moveSpeedAir;
    public int moveSpeedDefault; // This should be private, but needs to be public to test movespeeds during play
    [Range(0.0f, 30.0f)]
    public int maxVelocity;
    public WorldObjectScript interactionTarget = null;
    public WorldAreaScript currentArea = null;
    private static RockPaperScissors rpsGame = null;
    public bool touchingGround = true;
    public Vector3 aimDirection;
    public Camera cam;
    public AbilitySlotBaseScript[] abilitySlot = new AbilitySlotBaseScript[3];
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip landClip;
    public AudioClip walkClip;
    private bool flagForRespawn;
    public BallBaseScript ball;
    public PossessionTimer possessionTimer;
    public GamepadInfo gamepad;
    //public int playerNumber;

    public override void Start()
    {
        base.Start();

        if (GameObject.FindGameObjectWithTag("CompetitiveGame"))
        {
            rpsGame = GameObject.FindGameObjectWithTag("CompetitiveGame").GetComponent<RockPaperScissors>();
        }
        if (gameObject.GetComponent<PossessionTimer>() == null)
        {
            gameObject.AddComponent("PossessionTimer");
        }
        moveSpeedDefault = moveSpeed;
        abilitySlot = GetComponentsInChildren<AbilitySlotBaseScript>() as AbilitySlotBaseScript[];

        possessionTimer = GetComponent<PossessionTimer>();
        possessionTimer.SetPlayer(this);

        ProjectileAbilityBaseScript temp = abilitySlot[0] as ProjectileAbilityBaseScript;;

        //gameObject.tag = "Player";

        tk2dSprite sprite = GetComponentInChildren<tk2dSprite>();
        sprite.collider.enabled = false;    // Need to disable the sprite collider (we're not using the player sprite for collisions)
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckDead();

        //aimDirection = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        aimDirection = new Vector3(gamepad.leftStick.x, gamepad.leftStick.y, 0);
        Debug.DrawRay(gameObject.transform.position, aimDirection * 5, Color.red);

        HandleInput();

    }

    public virtual void FixedUpdate()
    {
        HandleFixedInput();
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

    public virtual void OnTriggerEnter(Collider other)
    {
        // Interaction test
        // NOTE: Use tags for these kinds of checks. This won't return null pointer errors of you mess up.
        // REMEMBER TO SET THE TAGS.
        if (other.gameObject.CompareTag("InteractiveObject"))
        {
            interactionTarget = other.gameObject.transform.parent.GetComponentInChildren<WorldObjectScript>();
            interactionTarget.ReceiveInteractionHandshake();
        }

        if (other.gameObject.CompareTag("WorldArea"))
        {
            Debug.Log("Entered area");
            currentArea = other.gameObject.transform.parent.GetComponentInChildren<WorldAreaScript>();
        }

    }

    public virtual void OnTriggerStay(Collider other)
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (interactionTarget != null)
        {
            interactionTarget.InteractionClose();
            interactionTarget = null;
        }
        if (other.gameObject.CompareTag("WorldArea"))
        {
            currentArea = null;
        }
        if (other.gameObject.CompareTag("OutOfBounds"))
        {
            flagForRespawn = true;
        }
    }

    /// <summary>
    /// This method should only be called as an escape during an Interact() attempt.
    /// </summary>
    /// <returns>True if in range to interact, false if not possible</returns>
    public virtual bool InteractionPossible()
    {
        if (interactionTarget != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// This method should be called when the player pressed "use"
    /// </summary>
    /// <param name="target">Requires a valid NamedObject otherwise does nothing</param>
    public virtual void Interact(WorldObjectScript target)
    {
        if (!InteractionPossible())
        {
            Debug.Log("Nothing to interact with!");
        }
        else
        {
            Debug.Log("Interacting with " + target.objectName + ".");
            target.OnInteract();
            rpsGame.Play(gameObject.GetComponentInChildren<PlayerScript>(), target);
        }
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
            Interact(interactionTarget);
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.RB])
        {
            IncreaseBet();
        }

        if (gamepad.rightTriggerDown)
        {
            UseAbilitySlotOne();
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.x])
        {
            RotateRPSChoice();
            GetComponentInChildren<PlayerRPSChoice>().UpdateText(Enum.GetName(typeof(RockPaperScissors.RPS), choice));
        }

        if (gamepad.buttonDown[(int)CharacterConstants.buttons.y])
        {
            DropBall();
        }
    }

    private void RotateRPSChoice()
    {
        switch (choice)
        {
            case RockPaperScissors.RPS.rock:
                choice = RockPaperScissors.RPS.paper;
                break;
            case RockPaperScissors.RPS.paper:
                choice = RockPaperScissors.RPS.scissors;
                break;
            case RockPaperScissors.RPS.scissors:
                choice = RockPaperScissors.RPS.rock;
                break;
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

    public override void ReceiveInteractionHandshake()
    {
        throw new System.NotImplementedException();
    }

    public override void InteractionClose()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Respawn()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        flagForRespawn = false;
        audio.clip = deathClip;
        audio.Play();
    }

    public void DropBall()
    {
        if (ball)
        {
            ball.DetachFromPlayer();
            ball = null;
        }
    }

    public float GetPossessionTime()
    {
        return possessionTimer.GetPossessionTime();
    }

    public void ResetPossessionTime()
    {
        possessionTimer.Reset();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        DropBall();
    }

    private void UseAbilitySlotOne()
    {
        if (ball == null)
        {
            abilitySlot[0].Use(aimDirection);
        }

        if (ball)
        {
            GetComponentInChildren<PassBall>().Pass(aimDirection, ball, this);
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

    private void CheckDead()
    {
        switch (health)
        {
            case 0:
                flagForRespawn = true;
                break;
        }
    }

}