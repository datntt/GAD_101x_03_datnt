using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float speed;
    public float timeToDestroy;

    Rigidbody2D body;
    GameController m_gc;

    AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();

        Destroy(gameObject, timeToDestroy); 
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                m_gc.ScoreIncrement(); // up point.

                if (aus && hitSound)
                {
                    aus.PlayOneShot(hitSound);
                }
                // Partical system
                if (hitVFX)
                {
                    Instantiate(hitVFX, collision.transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else if (collision.CompareTag("SceneTopLimit"))
            {
                Destroy(gameObject);
            }
        }
        
    }
}
