using UnityEngine;
using UnityEngine.SceneManagement;

public class GameActions : MonoBehaviour
{
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}