using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private BaseMinigame currentMinigame;
    private Dictionary<string, BaseMinigame> minigames = new Dictionary<string, BaseMinigame>();

    public void RegisterMinigame(string name, BaseMinigame minigame)
    {
        if (!minigames.ContainsKey(name))
        {
            minigames[name] = minigame;
        }
    }

    public void StartMinigame(string name)
    {
        if (minigames.ContainsKey(name))
        {
            if (currentMinigame != null)
                currentMinigame.EndGame();

            currentMinigame = minigames[name];
            currentMinigame.StartGame();
        }
    }

    public void EndCurrentMinigame()
    {
        if (currentMinigame != null)
        {
            currentMinigame.EndGame();
            currentMinigame = null;
        }
    }
}

