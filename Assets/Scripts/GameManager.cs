using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject normalCat;
    [SerializeField] GameObject fatCat;
    [SerializeField] GameObject pirateCat;
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
        
        if (level == 1)         // lv.1 20% 확률로 고양이를 더 생성
        {
            int p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)    // lv.2 50% 확률로 고양이를 더 생성
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)    // lv.3 뚱뚱한 고양이를 생성
        {
            Instantiate(fatCat);
        }
        else if (level >= 4)    // lv.4 해적 고양이를 생성
        {
            Instantiate(pirateCat);
        }
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
