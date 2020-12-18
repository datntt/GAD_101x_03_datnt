using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject playerBullet;
    public Transform shootingPoint;

    public AudioSource aus;

    public AudioClip shootingSound;
    public AudioClip explosionSound;

    GameController m_gc;

    private Vector3 destination;
    bool isShooting = true;

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        // khi gameover player stop
        if (m_gc.IsGameOver()) {
            return;
        }
        // di chuyen player = chuot.
        if (Input.GetMouseButton(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), moveSpeed);
        }
    }

    public void FixedUpdate()
    {
        // gameover bullet shooting stop.
        if (m_gc.IsGameOver())
        {
            return;
        }

        if (isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if(playerBullet && shootingPoint)
        {
            if(aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(playerBullet, shootingPoint.position, Quaternion.identity);
            isShooting = false;
            yield return new WaitForSeconds(moveSpeed);
            isShooting = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            m_gc.SetGameOverState(true);
            aus.PlayOneShot(explosionSound);
            Destroy(collision.gameObject);
        }
    }
}
