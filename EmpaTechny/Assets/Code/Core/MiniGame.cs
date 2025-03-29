using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    protected bool isPlaying = false;

    public virtual void StartGame()
    {
        isPlaying = true;
        gameObject.SetActive(true);
    }

    public virtual void EndGame()
    {
        isPlaying = false;
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (isPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }
}
