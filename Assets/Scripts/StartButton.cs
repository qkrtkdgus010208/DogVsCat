using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
