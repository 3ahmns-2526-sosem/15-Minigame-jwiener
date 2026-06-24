using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSpawner : MonoBehaviour
{
    public RectTransform canvas;
    public Button buttonPrefab;

    public TMP_Text scoreText;

    public float interval = 1f;
    public int maxButtons = 10;

    float timer;
    int count;
    int score;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            if (count >= maxButtons) return;

            SpawnButton();
        }
    }

    void SpawnButton()
    {
        Button b = Instantiate(buttonPrefab, canvas);
        RectTransform rt = b.GetComponent<RectTransform>();

        rt.anchoredPosition = GetRandomPos();

        b.onClick.AddListener(() => OnButtonClicked(b));

        count++;
    }

    void OnButtonClicked(Button b)
    {
        b.onClick.RemoveAllListeners();
        Destroy(b.gameObject);

        count--;
        score++;

        UpdateScoreUI();
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