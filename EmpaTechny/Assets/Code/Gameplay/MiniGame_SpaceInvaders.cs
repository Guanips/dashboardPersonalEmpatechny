using Supercyan.FreeSample;
using UnityEngine;

public class Minigame_SpaceInvaders : MiniGame
{
    [SerializeField] public GameObject playerController;

    public override void StartGame()
    {
        base.StartGame();
        playerController.GetComponent<SimpleSampleCharacterControl>().EnableControls(false);

    }

    public override void EndGame()
    {
        base.EndGame();
        playerController.GetComponent<SimpleSampleCharacterControl>().EnableControls(true);
    }
}


