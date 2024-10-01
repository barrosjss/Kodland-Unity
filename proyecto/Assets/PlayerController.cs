using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;
    [SerializeField] private Text HpText;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;
    [SerializeField] private float moveSpeed = 5f;

    public float health = 100;
    private Rigidbody rb;

    void Start()
    {
        ChangeHealth(0);

        rb = GetComponent<Rigidbody>();
    }

    public void ChangeHealth(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            Lost();
        }
        HpText.text = health.ToString();
    }

    public void Win()
    {
        Victory.SetActive(true);
        Destroy(GetComponent<PlayerLook>());
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        Destroy(GetComponent<PlayerLook>());
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Collider[] tar = Physics.OverlapSphere(transform.position, 2);
            foreach (var item in tar)
            {
                if (item.tag == "Enemy")
                {
                    Destroy(item.gameObject);
                }
            }
        }

        Collider[] targets = Physics.OverlapSphere(transform.position, 3);
        foreach (var item in targets)
        {
            if (item.tag == "Heal")
            {
                ChangeHealth(50);
                Destroy(item.gameObject);
            }
            if (item.tag == "Finish")
            {
                Win();
            }
            if (item.tag == "Enemy")
            {
                Lost();
            }
        }
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        
    }

    void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, rifleStart.position, transform.rotation);

        Bullet bulletComponent = newBullet.GetComponent<Bullet>();

        if (bulletComponent != null){ 
            bulletComponent.setDirection(transform.forward);
        }
        else
        {
            Debug.LogError("No se encontró el componente Bullet en la bala creada.");
        }
    }
}
