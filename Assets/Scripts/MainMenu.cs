using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;
    
    [SerializeField]
    private string gameSceneName;

    public void Play()
    {
        sceneController.LoadScene(gameSceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}