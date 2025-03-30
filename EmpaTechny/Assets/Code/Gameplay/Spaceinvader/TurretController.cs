using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float moveSpeed = 120f;
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;  // Punto de disparo (debe estar asignado en el Inspector)
    private RectTransform rectTransform;
    public Canvas canvas;  // Canvas donde se deben instanciar los proyectiles

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();  // Obtiene el RectTransform de la torreta
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // Tama�o real del Canvas
        float canvasWidth = canvasRect.rect.width;
        float turretWidth = rectTransform.rect.width; // Ancho de la torreta

        // Nueva posici�n calculada
        float newPosX = rectTransform.anchoredPosition.x + moveDirection.x * moveSpeed * Time.deltaTime;

        // Ajustar l�mites para que la torreta no se salga del Canvas
        float minX = -canvasWidth / 2 + turretWidth / 2;
        float maxX = canvasWidth / 2 - turretWidth / 2;

        newPosX = Mathf.Clamp(newPosX, minX, maxX);

        rectTransform.anchoredPosition = new Vector2(newPosX, rectTransform.anchoredPosition.y);
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instancia el proyectil en la posici�n del firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, canvas.transform);

            // Opcional: si el proyectil tiene un script con un m�todo ActivateProjectile(), lo llamamos
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.ActivateProjectile(firePoint.position);
            }
        }
        else
        {
            Debug.LogError("Projectile prefab or firePoint is not assigned!");
        }
    }
}
