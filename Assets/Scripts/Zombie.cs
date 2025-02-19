using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnDestroy()
    {
        ZombieSpawn.totalZombiesDestroyed++;
    }
}
