using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime = 2f;              // Coin disappears after 2 seconds
    public ScoreManager scoreManager;        // Drag your ScoreManager here in Inspector

    void Start()
    {
        // Automatically destroy coin after lifeTime seconds
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))      // Make sure your player has the "Player" tag
        {
            if (scoreManager != null)
                scoreManager.AddScore(1);    // Add 1 to score

            Destroy(gameObject);             // Remove coin immediately
        }
    }
}