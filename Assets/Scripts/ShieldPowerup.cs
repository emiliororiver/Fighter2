using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public float shieldDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // DEBUG — add these lines:
        Debug.Log("Collided object: " + other.gameObject.name);
        Debug.Log("Parent: " + other.transform.parent);
        Debug.Log("PlayerShield found? → " + other.GetComponentInParent<PlayerShield>());

        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponentInParent<PlayerShield>();

            if (shield == null)
            {
                Debug.LogError("NO PlayerShield script found on this object or parent!");
                return;
            }

            shield.ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}