using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerManager : Manager
{
    [SerializeField]
    private GameObject player;
    private PlayerState playerState = PlayerState.Exploration;

    public GameObject GetPlayer () { return player; }

    public PlayerState GetPlayerState() { return playerState; }
    public void SetPlayerState(PlayerState newPlayerState)
    {
        playerState = newPlayerState;
    }
}

public enum PlayerState
{
    Exploration,
    Inspect,
    Puzzle
}