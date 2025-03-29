using UnityEngine;
using UnityEngine.UI;

public interface IMinigame
{
    void StartGame();
    void EndGame();
    void ResetGame();
}

public abstract class BaseMinigame : MonoBehaviour, IMinigame
{
    [Header("General Settings")]
    [SerializeField] private string minigameName;
    [SerializeField] private Sprite backgroundImage;
    [SerializeField] private AudioClip backgroundMusic;

    [Header("UI Elements")]
    [SerializeField] private Canvas minigameCanvas;
    [SerializeField] private Image backgroundUI;
    [SerializeField] private Text scoreText;
    [SerializeField] private Button startButton;

    protected bool isGameActive;
    protected int score;

    public virtual void StartGame()
    {
        isGameActive = true;
        if (backgroundUI != null && backgroundImage != null)
        {
            backgroundUI.sprite = backgroundImage;
        }
        if (backgroundMusic != null)
        {
            AudioSource.PlayClipAtPoint(backgroundMusic, Vector3.zero);
        }
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }

        Debug.Log($"{minigameName} started!");
    }

    public virtual void EndGame()
    {
        isGameActive = false;
        Debug.Log($"{minigameName} ended!");
    }

    public virtual void ResetGame()
    {
        score = 0;
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
        Debug.Log($"{minigameName} reset!");
    }

    public virtual void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

