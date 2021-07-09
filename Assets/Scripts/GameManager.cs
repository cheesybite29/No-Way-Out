using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ReloadScene();
        }
    }
    public static void ReloadScene()
    {
        int cScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cScene);
    }
}
