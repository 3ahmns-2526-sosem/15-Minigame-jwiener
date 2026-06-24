using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSpawner : MonoBehaviour
{
    [Header("Setup")]
    public RectTransform canvas;
    public Button buttonPrefab;

    [Header("UI")]
    public TMP_Text scoreText;
    public GameObject winText;
    public GameObject loseText;

    [Header("Game Settings")]
    public float interval = 1f;
    public int maxButtons = 10;

    public float buttonLifetime = 3f;
    public int winScore = 10;

    float timer;
    int count;
    int score;

    bool gameEnded;

    void Start()
    {
        UpdateScoreUI();

        winText.SetActive(false);
        loseText.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            if (count < maxButtons)
                SpawnButton();
        }
    }

    void SpawnButton()
    {
        Button b = Instantiate(buttonPrefab, canvas);
        RectTransform rt = b.GetComponent<RectTransform>();

        rt.anchoredPosition = GetRandomPos();

        count++;

        bool clicked = false;

        b.onClick.AddListener(() =>
        {
            if (gameEnded) return;

            clicked = true;

            b.onClick.RemoveAllListeners();
            Destroy(b.gameObject);

            count--;

            score++;
            UpdateScoreUI();

            if (score >= winScore)
                EndGame(true);
        });

        // Lifetime check
        StartCoroutine(ButtonLifetime(b, () =>
        {
            if (gameEnded) return;

            if (!clicked)
            {
                EndGame(false);
            }
        }));
    }

    System.Collections.IEnumerator ButtonLifetime(Button b, System.Action onExpire)
    {
        yield return new WaitForSeconds(buttonLifetime);

        if (b != null)
        {
            Destroy(b.gameObject);
            count--;
            onExpire?.Invoke();
        }
    }

    void EndGame(bool won)
    {
        if (gameEnded) return;

        gameEnded = true;

        winText.SetActive(won);
        loseText.SetActive(!won);
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    Vector2 GetRandomPos()
    {
        Vector2 size = canvas.sizeDelta;

        float x = Random.Range(-size.x / 2f, size.x / 2f);
        float y = Random.Range(-size.y / 2f, size.y / 2f);

        return new Vector2(x, y);
    }
}