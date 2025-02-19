using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    // Maximum distance at which the turret searches for zombies
    private float searchRadius = 20f; 
    
    // Particle systems used for shooting effects
    public ParticleSystem[] particles;

    // We'll store all zombies found in the scene
    private GameObject[] items;

    // Reference to the currently targeted zombie
    private GameObject closestObject;

    // Track whether we are in the middle of shooting a zombie
    private bool isShooting = false;

    // How long to shoot (in seconds) before destroying the zombie
    public float shootDuration = 2f;

    void OnEnable()
    {
        // Repeatedly check for new targets every 0.5 seconds
        InvokeRepeating("Check", 0.5f, 0.5f);
    }

    void Check()
    {
        // If we're already shooting a zombie, do nothing
        if (isShooting) return;

        float oldDistance = searchRadius;
        closestObject = null;

        // Find all zombies in the scene
        items = GameObject.FindGameObjectsWithTag("Zombie");

        // Determine the closest zombie within 'searchRadius'
        for (int i = 0; i < items.Length; i++)
        {
            if (!items[i].activeInHierarchy) 
                continue;

            float newDistance = Vector3.Distance(transform.position, items[i].transform.position);
            if (newDistance < oldDistance)
            {
                oldDistance = newDistance;
                closestObject = items[i];
            }
        }

        // If we found a valid zombie
        if (closestObject != null)
        {
            // Start shooting the zombie
            StartCoroutine(ShootZombie());
        }
    }

    IEnumerator ShootZombie()
    {
        isShooting = true;   // Lock on this target

        // Play all particle systems
        PlayParticles();

        float elapsedTime = 0f;

        // Continuously aim and shoot for 'shootDuration' seconds
        while (elapsedTime < shootDuration && closestObject != null && closestObject.activeInHierarchy)
        {
            // Keep aiming at the zombie
            transform.LookAt(closestObject.transform.position);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // If the zombie is still around, destroy it
        if (closestObject != null)
        {
            Destroy(closestObject);
        }

        // Stop particle effects (if desired)
        StopParticles();

        // Reset for the next target
        closestObject = null;
        isShooting = false;
    }

    private void PlayParticles()
    {
        foreach (ParticleSystem ps in particles)
        {
            if (!ps.isPlaying)
            {
                ps.Play();
            }
        }
    }

    private void StopParticles()
    {
        foreach (ParticleSystem ps in particles)
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
        }
    }
}
