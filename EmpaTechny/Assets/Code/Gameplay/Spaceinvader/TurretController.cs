using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float moveSpeed = 120f;
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;  // Punto de disparo (debe estar asignado en el Inspector)
    private RectTransform rectTransform;
    public Canvas canvas;  // Canvas donde se deben instanciar los proyectiles

    public float shootCooldown = 0.4f;  // Cooldown de disparo en segundos
    private float cooldownTimer = 0f;  // Temporizador de cooldown

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();  // Obtiene el RectTransform de la torreta
    }

    void Update()
    {
        MovePlayer();

        // Actualizar el temporizador de cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;  // Disminuir el temporizador de cooldown
        }

        // Solo disparar si el temporizador ha llegado a cero y se presiona la tecla de disparo
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            Shoot();
            cooldownTimer = shootCooldown;  // Reiniciar el temporizador de cooldown
        }
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        // Tamaño real del Canvas
        float canvasWidth = canvasRect.rect.width;
        float turretWidth = rectTransform.rect.width; // Ancho de la torreta

        // Nueva posición calculada
        float newPosX = rectTransform.anchoredPosition.x + moveDirection.x * moveSpeed * Time.deltaTime;

        // Ajustar límites para que la torreta no se salga del Canvas
        float minX = -canvasWidth / 2 + turretWidth / 2;
        float maxX = canvasWidth / 2 - turretWidth / 2;

        newPosX = Mathf.Clamp(newPosX, minX, maxX);

        rectTransform.anchoredPosition = new Vector2(newPosX, rectTransform.anchoredPosition.y);
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instancia el proyectil en la posición del firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity, canvas.transform);

            // Get the projectile's script component and activate the projectile
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                // You can pass the shooting position and handle other logic inside the projectile script itself
                projectileScript.ActivateProjectile(firePoint.position);
            }
        }
        else
        {
            Debug.LogError("Projectile prefab or firePoint is not assigned!");
        }
    }
}
