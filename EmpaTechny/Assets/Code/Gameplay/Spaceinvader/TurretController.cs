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

        // Limita el movimiento dentro de los límites del Canvas
        float newPosX = Mathf.Clamp(rectTransform.anchoredPosition.x + moveDirection.x * moveSpeed * Time.deltaTime, 0, canvas.GetComponent<RectTransform>().rect.width);
        rectTransform.anchoredPosition = new Vector2(newPosX, rectTransform.anchoredPosition.y);
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instancia el proyectil en la posición del firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, canvas.transform);

            // Opcional: si el proyectil tiene un script con un método ActivateProjectile(), lo llamamos
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
