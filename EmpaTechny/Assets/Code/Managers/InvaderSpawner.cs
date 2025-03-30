using UnityEngine;

public class InvaderSpawner : MonoBehaviour
{
    public GameObject invaderPrefab;   // Prefab del invader (que debe ser un Image en el Canvas)
    public int rows = 3;
    public int columns = 5;
    public float xOffset = 150f;       // Ajusta este valor según el tamaño de los invaders
    public float yOffset = 150f;       // Ajusta este valor según el tamaño de los invaders
    public RectTransform canvasRect;   // Referencia al RectTransform del Canvas

    void Start()
    {
        SpawnInvaders();
    }

    private void SpawnInvaders()
    {
        // Transformar las posiciones relativas al Canvas
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 spawnPosition = new Vector3(col * xOffset, -row * yOffset, 0);

                // Usar el RectTransform para convertir las coordenadas a coordenadas del Canvas
                Vector2 localPosition = canvasRect.TransformPoint(spawnPosition);

                // Asegurarse de que las posiciones se queden dentro de los límites del Canvas
                localPosition.x = Mathf.Clamp(localPosition.x, 0, canvasRect.rect.width);
                localPosition.y = Mathf.Clamp(localPosition.y, 0, canvasRect.rect.height);

                // Crear el invader dentro del Canvas
                GameObject invader = Instantiate(invaderPrefab, localPosition, Quaternion.identity, canvasRect);
                invader.name = "Invader_" + row + "_" + col; // Opcional, para tener nombres únicos
            }
        }
    }
}
