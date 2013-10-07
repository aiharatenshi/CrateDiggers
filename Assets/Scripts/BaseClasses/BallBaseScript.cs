using UnityEngine;
using System.Collections;

public class BallBaseScript : MonoBehaviour
{

    public PlayerBaseScript possessingPlayer;

    void Start()
    {

    }

    void Update()
    {
        if (possessingPlayer)
        {
            transform.position = possessingPlayer.transform.position + new Vector3(0, 2, 0);
        }
    }

    public void AttachToPlayer(PlayerBaseScript player)
    {
        possessingPlayer = player;
        rigidbody.isKinematic = true;
    }

    public void DetachFromPlayer()
    {
        possessingPlayer = null;
        rigidbody.isKinematic = false;
    }
}
