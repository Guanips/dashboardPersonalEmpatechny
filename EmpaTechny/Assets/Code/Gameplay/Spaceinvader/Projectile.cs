using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 120f;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Inicializar en Awake
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is missing on Projectile!");
        }
    }

    // Esta función se llamará cuando el proyectil se reutilice
    public void ActivateProjectile(Vector2 position)
    {
        if (rectTransform == null)
        {
            Debug.LogError("rectTransform is null in ActivateProjectile!");
            return;
        }

        gameObject.SetActive(true);
        rectTransform.position = position;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            rectTransform.Translate(Vector3.up * speed * Time.deltaTime);

            if (rectTransform.position.y > Screen.height)
            {
                DeactivateProjectile();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Invader"))
        {
            Destroy(other.gameObject);
            DeactivateProjectile();
        }
    }

    public void DeactivateProjectile()
    {
        gameObject.SetActive(false);
    }
}
