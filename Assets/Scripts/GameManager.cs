using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject normalCat;
    [SerializeField] GameObject retryButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    private void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        retryButton.SetActive(true);
    }
}
