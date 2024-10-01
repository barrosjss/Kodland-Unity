using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;
    private Vector3 direction;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    public void setDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void FixedUpdate()
    {
        MoveBullet();
        CheckCollisions();
    }

    void MoveBullet()
    {
        // Desactivamos la gravedad para la bala
        rb.useGravity = false;

        // Aplicamos una fuerza constante en la dirección del disparo
        rb.velocity = direction * speed;
    }

    void CheckCollisions()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(10f);
                }
                Destroy(gameObject);
                break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
