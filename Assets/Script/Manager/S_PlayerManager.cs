using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerManager : Manager
{
    private PlayerState playerState = PlayerState.Exploration;

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