using UnityEngine;
using UnityEngine.UI;


public class InteractableMiniGame : MonoBehaviour
{
    public GameObject miniGame; // Campo p�blico de tipo MiniGame

    public GameObject interactionUI; // UI que muestra "Presiona E para jugar"
    private bool isPlayerNearby = false;
    public GameObject spaceInvadersGO;

    private void Start()
    {
        interactionUI.SetActive(false); // Ocultar mensaje al inicio
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Interaccion");
            Interact();
        }
    }

    public void Interact()
    {
        if (miniGame != null)
        {
            Debug.Log("Inicio minijuego");
            spaceInvadersGO.SetActive(true);
            miniGame.GetComponent<MiniGame>().StartGame(); // Inicia el juego asignado
            
        }
        else
        {
            Debug.LogWarning("No se ha asignado un minijuego.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            isPlayerNearby = true;
            interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            isPlayerNearby = false;
            interactionUI.SetActive(false);
        }
    }
}
