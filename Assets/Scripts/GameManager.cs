using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            ReloadScene();
        }
        if (Input.GetButtonDown("Cancel")) Application.Quit();
    }
    public static void ReloadScene()
    {
        int cScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cScene);
    }
}
