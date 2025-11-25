using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour
{
    [Header("Shield Visual")]
    public GameObject ShieldVisual; 
    private bool isShielded = false;

    [Header("Audio Clips")]
    public AudioClip shieldUpSound;
    public AudioClip shieldDownSound;

    private AudioSource audioSource;

    private void Awake()
    {
        // Make sure the AudioSource is on the same GameObject as this script
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the AudioSource is enabled
        audioSource.enabled = true;

        // Optional: make sure ShieldVisual is hidden at start
        if (ShieldVisual != null)
        {
            ShieldVisual.SetActive(false);
        }
    }

    public void ActivateShield(float duration)
    {
        StartCoroutine(ShieldRoutine(duration));
    }

    private IEnumerator ShieldRoutine(float duration)
    {
        isShielded = true;

        if (ShieldVisual != null)
            ShieldVisual.SetActive(true);

        // Play shield-up sound
        if (shieldUpSound != null && audioSource.enabled)
            audioSource.PlayOneShot(shieldUpSound);

        yield return new WaitForSeconds(duration);

        if (ShieldVisual != null)
            ShieldVisual.SetActive(false);

        isShielded = false;

        // Play shield-down sound
        if (shieldDownSound != null && audioSource.enabled)
            audioSource.PlayOneShot(shieldDownSound);
    }

    public bool IsShielded()
    {
        return isShielded;
    }
}