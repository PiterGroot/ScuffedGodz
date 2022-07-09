using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static List<GameObject> players = new List<GameObject>();
    private void Awake()
    {
        PlayerMovement[] foundPlayers = FindObjectsOfType<PlayerMovement>();
        foreach (PlayerMovement player in foundPlayers) players.Add(player.gameObject);
    }
    public static GameObject GetRandomPlayer()
    {
        return Random.value < .5 ? players[0] : players[1];
    }
}
