using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    // How many shots this zombie can take (2 means two hits to kill).
    public int health = 2;  

    // Call this when the zombie is hit by the player’s gun.
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);  // Kills this zombie
        }
    }
}
