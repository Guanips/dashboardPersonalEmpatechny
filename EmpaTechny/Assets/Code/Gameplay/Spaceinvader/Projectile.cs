using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 120f;
    private RectTransform rectTransform;

    public float shootCooldown = 1f;
    private float lastShootTime = 0f;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is missing on Projectile!");
        }
    }

    public void ActivateProjectile(Vector2 position)
    {
        if (rectTransform == null)
        {
            Debug.LogError("rectTransform is null in ActivateProjectile!");
            return;
        }

        gameObject.SetActive(true);
        rectTransform.position = position;
        if (Time.time - lastShootTime >= shootCooldown)
        {
            lastShootTime = Time.time;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Invader")
        {
            Destroy(collision.collider.gameObject);
            DeactivateProjectile();
        }
    }

    public void DeactivateProjectile()
    {
        gameObject.SetActive(false);
    }
}
