using UnityEngine;

public class MiniGame_SpaceInvaders : MiniGame
{
    public static MiniGame_SpaceInvaders Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
            return;
        }

        DontDestroyOnLoad(gameObject); // Mantener al cambiar de escena (opcional)
    }

    public override void StartGame()
    {
        MiniGame_SpaceInvaders.Instance.gameObject.SetActive(true);
        base.StartGame();
        // Habilitar controles de jugador (conforme a tu código)
        PlayerController.Instance.EnableControls(true);

    }

    public override void EndGame()
    {
        base.EndGame();
        MiniGame_SpaceInvaders.Instance.gameObject.SetActive(false);
        // Deshabilitar controles de jugador
        PlayerController.Instance.EnableControls(false);
    }
}
