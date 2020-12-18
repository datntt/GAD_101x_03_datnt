using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 destination;
    private bool isShooting = true;

    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;

    public AudioSource shootSFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), 0.1f);
        }
        if(isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        // khởi tạo 1 viên đạn ở vị trí bulletSpawnPoint, góc (Quaternion) mặc định theo góc của bullletPrefab.
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        // phát âm thanh
        shootSFX.Play();
        // Sau  khi spawn đạn, sẽ dừng bắn trong thời gian #fireRate
        isShooting = false;
        yield return new WaitForSeconds(fireRate);
        // sau khi chờ đủ khoảng thời gian #fireRate sẽ bắn tiếp tục.
        isShooting = true;
    }

    
}
