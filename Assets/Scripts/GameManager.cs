using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject normalCat;
    [SerializeField] GameObject retryButton;
    [SerializeField] Text levelText;
    [SerializeField] RectTransform levelFront;

    private int level;
    private int score;

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

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelText.text = level.ToString();
        levelFront.localScale = new Vector3((score % 5) / 5f, 1f, 1f);
    }
}
