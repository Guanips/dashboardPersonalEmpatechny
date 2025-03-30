using UnityEngine;

public class Invader : MonoBehaviour
{
    public float speed = 50f;  // Velocidad de caída
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, -speed * Time.deltaTime);

        // Si el invader sale de la pantalla, lo destruimos
        if (rectTransform.anchoredPosition.y < -100)
        {
            Destroy(gameObject);
        }
    }
}
