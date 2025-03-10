using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    
    [SerializeField]
    private float fadeDuration = 1f;
    
    [SerializeField]
    private string sceneToLoad;
  

    
    public IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        // Gradually increase the alpha value of the Canvas Group
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // Load the new scene after the fade-out
        SceneManager.LoadScene(sceneToLoad);
    }
}
