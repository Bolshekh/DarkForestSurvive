using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    public static PlayerManager Player { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = Player.GetComponent<PlayerHealth>();
        PlayerMovement = Player.GetComponent<PlayerMovement>();
        Player = playerManager;
    }
}
