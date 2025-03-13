using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerManager;
    public static GameObject Player { get; private set; }
    public HealthSystem PlayerHealth { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    // Start is called before the first frame update
    void Start()
	{
		Player = playerManager;
		PlayerHealth = Player.GetComponent<HealthSystem>();
        PlayerMovement = Player.GetComponent<PlayerMovement>();
    }
}
