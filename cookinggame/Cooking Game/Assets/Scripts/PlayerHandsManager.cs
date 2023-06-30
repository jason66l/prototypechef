using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandsManager : MonoBehaviour
{
    public static PlayerHandsManager instance; // Singleton instance
    public GameObject playerHands; // Reference to the "Player Hands" object

    private void Awake()
    {
        // Create a singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
