using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CollectHealth : MonoBehaviour
{

    public int healthAmount = 1;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null) {
                //adds the health to the player and destroys the collectible
                playerHealth.healPlayer(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
