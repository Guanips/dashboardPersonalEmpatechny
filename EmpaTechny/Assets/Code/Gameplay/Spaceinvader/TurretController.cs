using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;  // El punto de disparo debe estar dentro del Canvas
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();  // Asegúrate de que la torreta también use RectTransform
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
        Vector3 moveDirection = new Vector2(horizontalInput, 0);

        // Limita el movimiento dentro de los límites del Canvas
        float newPosX = Mathf.Clamp(rectTransform.position.x + moveDirection.x * moveSpeed * Time.deltaTime, 0, Screen.width);
        rectTransform.position = new Vector2(newPosX, rectTransform.position.y);
    }

    private void Shoot()
    {
        // Instanciar el proyectil (vacuna) desde el firePoint (dentro del Canvas)
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }
}
