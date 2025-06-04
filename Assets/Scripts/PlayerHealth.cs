using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    private int currentHealth;

    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    void Update() {
        //check if the player falls through the map
        if (transform.position.y <= -15) {
            Die();
        }
    }

    //method to take damage
    public void takeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);
        UpdateHearts();

        if (currentHealth <= 0 ) {
            Die();
        }
    }

    public void healPlayer(int amount) {
        currentHealth += amount;
        //ensures that player can not have more than 3 lives
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        Debug.Log("Player healed " + amount + " health. Current health: " + currentHealth);
        UpdateHearts();
    }

    //method to handle player death
    private void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Player should be dead");
    }

    //updates the heart images to reflect player's current health
    private void UpdateHearts() {
        for (int i = 0; i < heartImages.Length; i++) {
            if (i < currentHealth) {
                //full hearts
                heartImages[i].sprite = fullHeart;
            } else {
                //empty hearts
                heartImages[i].sprite = emptyHeart;
            }
        }
    }
}
