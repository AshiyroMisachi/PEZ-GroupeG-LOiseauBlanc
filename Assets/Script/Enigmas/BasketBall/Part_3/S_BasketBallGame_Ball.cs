using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BasketBallGame_Ball : MonoBehaviour
{
    private S_Interractible_BasketBallGame basketBallGame;
    [SerializeField]
    private float time, timeAfter;
    [SerializeField]
    private float timeForDestroy;

    private void Update()
    {
        if (time != 0)
        {
            if (time > timeAfter)
            {
                basketBallGame.DestroyCurrentBall();
                return;
            }
            time += Time.deltaTime;
        }
    }

    public void SetBasketBallGame(S_Interractible_BasketBallGame basketBallGame)
    {
        this.basketBallGame = basketBallGame;
    }

    public void StartLaunch()
    {
        time = Time.time;
        timeAfter = time + timeForDestroy;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BasketBallGame_Basket")
        {
            basketBallGame.IncrementScore(1);
        }
    }
}