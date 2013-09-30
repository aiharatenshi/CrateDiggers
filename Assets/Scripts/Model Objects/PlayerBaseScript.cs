using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]

public class PlayerBaseScript : WorldObjectScript
{

    /// <summary>
    /// Base abstract class for player objects.
    /// Contains basic controller movement and interaction.
    /// 
    /// NOTE: Don't set default values for movement until we find something
    /// we actually like.
    /// </summary>

    public int moveSpeed;
    public int jumpMagnitude;
    public int moveSpeedAir;
    private int moveSpeedDefault; // This should be private, but needs to be public to test movespeeds during play
    public int maxVelocity;
    public WorldObjectScript interactionTarget = null;
    public WorldAreaScript currentArea = null;
    private static RockPaperScissors rpsGame = null;
    public bool physicsInput = true;
    public bool touchingGround = true;
    public int playChance = 10;
    public Vector3 aimDirection;
    public Camera cam;
    public GunBaseScript gun;
    public MeleeWeaponBaseScript meleeWeapon;
    public ProjectileBaseScript ammo;
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip landClip;
    public AudioClip walkClip;
    private bool flagForRespawn;
    /// <summary>
    /// If false overrides whatever value moveSpeedAir is set to
    /// </summary>
    public bool AirControl;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        rpsGame = GameObject.FindGameObjectWithTag("CompetitiveGame").GetComponent<RockPaperScissors>();
        moveSpeedDefault = moveSpeed;
        gun = GetComponentInChildren<GunBaseScript>();
        meleeWeapon = GetComponentInChildren<MeleeWeaponBaseScript>();
        ammo = gun.projectileType;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        HandleInput();

        if (UnityEngine.Random.Range(0, playChance) == 0)
        {
            WorldObjectScript[] players = FindObjectsOfType(typeof(WorldObjectScript)) as WorldObjectScript[];
            int a = UnityEngine.Random.Range(0, players.Length);
            int b = UnityEngine.Random.Range(0, players.Length);
            if (a != b && players[a].currentBet > 0 && players[b].currentBet > 0)
            {
                rpsGame.Play(players[a], players[b]);
            }
        }

        aimDirection = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        Debug.DrawRay(gameObject.transform.position, aimDirection, Color.red);

        if (!AirControl)
        {
            moveSpeedAir = 0;
        }

    }

    public virtual void FixedUpdate()
    {
        Debug.Log(rigidbody.velocity.magnitude);
        if (physicsInput)
        {
            HandlePhysicsInput();
        }
        if (flagForRespawn)
        {
            Respawn();
        }
        if (rigidbody.velocity.sqrMagnitude > maxVelocity * maxVelocity)  // TODO: This shouldn't cap x and y velocity dependently. Need to rewrite later.
        {
            float yVel = rigidbody.velocity.y;
            Vector3 maxedVelocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
            maxedVelocity.Normalize();
            maxedVelocity.Set(maxedVelocity.x * maxVelocity, maxedVelocity.y * maxVelocity, 0);
            rigidbody.velocity = maxedVelocity;
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        touchingGround = true;
    }

    public virtual void OnCollisionStay(Collision collision)
    {
        touchingGround = true;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
        }
    }

    public virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            touchingGround = false;
        }

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
        if (!physicsInput)
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
            }

            if (Input.GetKey("down"))
            {
                transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
            }

            if (Input.GetKey("left"))
            {
                transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
            }

            if (Input.GetKey("right"))
            {
                transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(interactionTarget);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            IncreaseBet();
        }

        if (Input.GetMouseButton(0))
        {
            gun.Shoot(aimDirection);
        }
        if (Input.GetMouseButton(1))
        {
            meleeWeapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            RotateRPSChoice();
            GetComponentInChildren<PlayerRPSChoice>().UpdateText(Enum.GetName(typeof(RockPaperScissors.RPS), choice));
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

    public virtual void HandlePhysicsInput()
    {
        if (!touchingGround)
        {
            moveSpeed = moveSpeedAir;
        }
        else
        {
            moveSpeed = moveSpeedDefault;
        }
        if (Input.GetKeyDown("up"))
        {
            if (touchingGround)
            {
                rigidbody.AddForce(Vector3.up * jumpMagnitude, ForceMode.Impulse);
                audio.clip = jumpClip;
                audio.Play();
            }
        }

        if (Input.GetKey("down"))
        {
            //rigidbody.AddForce(Vector3.down * moveSpeed);
        }

        if (Input.GetKey("left"))
        {
            rigidbody.AddForce(Vector3.left * moveSpeed);
            audio.clip = walkClip;
            audio.Play();
        }

        if (Input.GetKey("right"))
        {
            rigidbody.AddForce(Vector3.right * moveSpeed);
            audio.clip = walkClip;
            audio.Play();
        }

        if (touchingGround) // Allow player to stop instantly if touching ground
        {
            if (Input.GetKeyUp("left") && !Input.GetKeyDown("right"))
            {
                rigidbody.velocity.Set(0, rigidbody.velocity.y, 0);
            }
            if (Input.GetKeyUp("right")&& !Input.GetKeyDown("left"))
            {
                rigidbody.velocity.Set(0, rigidbody.velocity.y, 0);
            }
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

}