using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(Rigidbody))]

public class PlayerBaseScript : WorldObjectScript
{

    /// <summary>
    /// Base abstract class for player objects.
    /// Contains basic controller movement and interaction.
    /// </summary>

    public int moveSpeed = 100;
    public int jumpMagnitude = 20;
    public int moveSpeedAir;
    private int moveSpeedDefault;
    public WorldObjectScript interactionTarget = null;
    public WorldAreaScript currentArea = null;
    private static RockPaperScissors rpsGame = null;
    public bool physicsInput = true;
    public bool touchingGround = true;
    public int playChance = 10;
    public static Vector3 aimDirection;
    public Camera cam;
    public GunBaseScript gun;
    public ProjectileBaseScript ammo;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        rpsGame = GameObject.FindGameObjectWithTag("CompetitiveGame").GetComponent<RockPaperScissors>();
        moveSpeedAir = moveSpeed / 2;
        moveSpeedDefault = moveSpeed;
        gun = GetComponentInChildren<GunBaseScript>();
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
        gun.transform.rotation = Quaternion.Euler(aimDirection);

    }

    public virtual void FixedUpdate()
    {
        if (physicsInput)
        {
            HandlePhysicsInput();
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
        touchingGround = false;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Interaction test
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

        if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
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
        if (Input.GetKey("up"))
        {
            if (touchingGround)
            {
                rigidbody.AddForce(Vector3.up * jumpMagnitude, ForceMode.Impulse);
            }
        }

        if (Input.GetKey("down"))
        {
            //rigidbody.AddForce(Vector3.down * moveSpeed);
        }

        if (Input.GetKey("left"))
        {
            rigidbody.AddForce(Vector3.left * moveSpeed);
        }

        if (Input.GetKey("right"))
        {
            rigidbody.AddForce(Vector3.right * moveSpeed);
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

}