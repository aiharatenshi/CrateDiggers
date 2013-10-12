using UnityEngine;
using System.Collections;

public class PassBall : AbilitySlotBaseScript
{
    [Range(20.0f, 75.0f)]
    public float passForce;

    public override void Start()
    {
        base.Start();
        cooldown = 0;
    }

    public void Pass(Vector3 direction, BallBaseScript ball, CompetitivePlayerBaseScript player)
    {
        ball.DetachFromPlayer();
        direction.Normalize();
        direction.z = 0;
        ball.rigidbody.AddForce(passForce * direction, ForceMode.VelocityChange);
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Use(Vector3 direction, BallBaseScript ball, CompetitivePlayerBaseScript player)
    {
        ball.DetachFromPlayer();
        direction.Normalize();
        direction.z = 0;
        ball.rigidbody.AddForce(passForce * direction, ForceMode.VelocityChange);
    }
}
