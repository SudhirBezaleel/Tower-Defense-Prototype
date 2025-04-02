using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    // Reference to the UI Text element
    public Text scoreText;

    // To track how many zombies were previously recorded
    private int lastZombieCount = 0;

    private void Update()
    {
        int currentZombieCount = ZombieSpawn.totalZombiesDestroyed;

        // If new zombies have been destroyed since the last check
        if (currentZombieCount > lastZombieCount)
        {
            int difference = currentZombieCount - lastZombieCount;
            // Award 10 currency per zombie destroyed
            SaveScript.playerCurrency += difference * 10;
            lastZombieCount = currentZombieCount;
        }

        // Update the UI text with both zombies killed and current currency
        scoreText.text = "Zombies Killed: " + currentZombieCount +
                         "\nCurrency: " + SaveScript.playerCurrency;
    }
}
