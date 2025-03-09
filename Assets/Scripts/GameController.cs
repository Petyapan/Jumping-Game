using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPosition;
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    
    private void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }
    
    private IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = startPosition;
        spriteRenderer.enabled = true;
    }
}
