using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PossessionTimer))]

public class CompetitorModuleScript : MonoBehaviour
{
    /// <summary>
    /// Add this script to gameObjects to acquire the components needed for competing
    /// in the "competitive game"
    /// </summary>

    private CompetitorBaseScript player;
    public int health = 4;
    public bool godMode = false;
    protected int score = 0;
    public PossessionTimer possessionTimer;
    public BallBaseScript ball;
    public RockPaperScissors rpsGame = null;
    public bool flagForRespawn;

    void Start()
    {
        if (gameObject.GetComponent<PossessionTimer>() == null)
        {
            gameObject.AddComponent("PossessionTimer");
        }
        possessionTimer = GetComponent<PossessionTimer>();
        possessionTimer.SetPlayer(player);
    }

    void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
        switch (health)
        {
            case 0:
                FlagForRespawn();
                break;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public virtual void TakeDamage(int amount)
    {
        if (!godMode)
        {
            health -= amount;
        }
    }

    public void SetPlayer(CompetitorBaseScript _player)
    {
        player = _player;
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

    public void FlagForRespawn()
    {
        flagForRespawn = true;
    }
}
