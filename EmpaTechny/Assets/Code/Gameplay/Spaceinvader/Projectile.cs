using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Usar RectTransform para objetos UI
    }

    void Update()
    {
        // Mueve el proyectil hacia arriba en el Canvas
        rectTransform.Translate(Vector3.up * speed * Time.deltaTime);

        // Verifica si el proyectil se sale del Canvas
        if (rectTransform.position.y > Screen.height)
        {
            Destroy(gameObject); // Destruye el proyectil si se sale de la pantalla
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Invader"))
        {
            Destroy(other.gameObject); // Destruye al invader
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
