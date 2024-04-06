using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerManager : Manager
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Camera playerCamera;
    private PlayerState playerState = PlayerState.Exploration;

    public GameObject GetPlayer () { return player; }

    public Camera GetPlayerCamera () { return playerCamera;}

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