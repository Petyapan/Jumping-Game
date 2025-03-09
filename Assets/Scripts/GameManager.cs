using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeToWaitBeforeExit;

    [SerializeField]
    private SceneController sceneController;
    
    [SerializeField]
    private string gameSceneName;

    [SerializeField]
    private GameObject player; // Reference to the player GameObject
    
    [SerializeField]
    private Vector2 startPosition;
    
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        startPosition = player.transform.position;
    }

    public void OnPlayerDied()
    {
        Invoke(nameof(EndGame), timeToWaitBeforeExit);
    }

    private void EndGame()
    {
        sceneController.LoadScene(gameSceneName);
    }

    public void PlayerHitObstacle()
    {
        StartCoroutine(RespawnPlayer(0.5f));
    }

    private IEnumerator RespawnPlayer(float duration)
    {
        playerSpriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        player.transform.position = startPosition;
        playerSpriteRenderer.enabled = true;
    }
}