using UnityEngine;
using System.Collections;

public class PassBall : MonoBehaviour
{
    [Range(20.0f, 75.0f)]
    public float passForce;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Pass(Vector3 direction, BallBaseScript ball, PlayerBaseScript player)
    {
        ball.DetachFromPlayer();
        direction.Normalize();
        direction.z = 0;
        ball.rigidbody.AddForce(passForce * direction, ForceMode.VelocityChange);
    }
}
