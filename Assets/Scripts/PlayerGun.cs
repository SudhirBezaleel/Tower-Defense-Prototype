using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Reference to your main camera (usually the "FPS Camera" on the player)
    public Camera playerCamera;

    // How far the gun can shoot
    public float shootingRange = 100f;

    void Update()
    {
        // If left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Cast a ray from the center of the screen
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // If we hit something within shootingRange
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            // Check if the hit object is tagged "Zombie"
            if (hit.transform.CompareTag("Zombie"))
            {
                // Try to get the ZombieHealth component
                ZombieHealth zh = hit.transform.GetComponent<ZombieHealth>();
                if (zh != null)
                {
                    // Deal 1 point of damage (2 hits to kill)
                    zh.TakeDamage(1);
                }
            }
        }
    }

    // Draw a simple crosshair in the middle of the screen using OnGUI
    void OnGUI()
    {
        // Adjust size/position as desired
        float size = 20f;
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 24;
        style.normal.textColor = Color.red;

        // Draw a simple "+" crosshair
        GUI.Label(
            new Rect(
                (Screen.width - size) / 2f, 
                (Screen.height - size) / 2f, 
                size, 
                size
            ), 
            "+", 
            style
        );
    }
}

