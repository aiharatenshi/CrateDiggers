using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    private int health;
    private float speed;
    private tk2dSprite sprite;


    // Use this for initialization
    void Start()
    {
        health = 100;
        speed = 4;
        sprite = GetComponent<tk2dSprite>();

        if (sprite == null) Debug.Log("Error cannot find sprite for " + this.gameObject.name.ToString() + "game object");
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 oldPosition = this.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x, oldPosition.y + speed, oldPosition.z);
            this.transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 oldPosition = this.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x - speed, oldPosition.y, oldPosition.z);
            this.transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 oldPosition = this.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x, oldPosition.y - speed, oldPosition.z);
            this.transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 oldPosition = this.transform.position;
            Vector3 newPosition = new Vector3(oldPosition.x + speed, oldPosition.y, oldPosition.z);
            this.transform.position = newPosition;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            /*
             * Player tells their game manager to switch to comp mode or frame mode
             * Player also switches their internal state to comp or frame mode
             * Input now corresponds to the proper sprite in correct world.
             * */
        }
    }
}
