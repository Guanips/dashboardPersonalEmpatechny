using UnityEngine;

public class Invader : MonoBehaviour
{
    public float moveSpeed = 100f;  // Ajusta la velocidad según el tamaño del Canvas
    private bool movingRight = true;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = movingRight ? 1 : -1;
        rectTransform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Si llega al borde, cambia de dirección
        if (rectTransform.localPosition.x > 500f || rectTransform.localPosition.x < -500f)  // Ajusta los límites
        {
            movingRight = !movingRight;
            rectTransform.localPosition += Vector3.down * 50f; // Baja un poco después de cambiar de dirección
        }
    }
}
