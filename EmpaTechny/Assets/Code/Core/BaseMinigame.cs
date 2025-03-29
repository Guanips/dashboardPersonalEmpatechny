using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinigame
{
    void StartGame();
    void EndGame();
    void ResetGame();
}

public abstract class BaseMinigame : MonoBehaviour, IMinigame
{
    protected bool isGameActive;

    public virtual void StartGame()
    {
        isGameActive = true;
        Debug.Log($"{GetType().Name} started!");
    }

    public virtual void EndGame()
    {
        isGameActive = false;
        Debug.Log($"{GetType().Name} ended!");
    }

    public virtual void ResetGame()
    {
        Debug.Log($"{GetType().Name} reset!");
    }
}
