using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMinigame : BaseMinigame
{
    public override void StartGame()
    {
        base.StartGame();
        // Lógica específica para iniciar este minijuego
        Debug.Log("Catching falling objects!");
    }

    public override void EndGame()
    {
        base.EndGame();
        // Lógica específica para terminar este minijuego
    }

    public override void ResetGame()
    {
        base.ResetGame();
        // Reiniciar elementos del juego
    }
}
