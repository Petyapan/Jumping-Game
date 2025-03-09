using UnityEngine;

public class FadeOutTrigger : MonoBehaviour
{
    [SerializeField]
    private FadeOut fadeOut; // Reference to the FadeOut script
    
    private bool _fadeOutTriggered; // Flag to track if fade-out has been triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return; // Check if the player has entered the trigger
        Debug.Log("Player entered the trigger! Starting fade-out...");
        StartCoroutine(fadeOut.FadeToBlack()); // Trigger fade-out
    }
}
