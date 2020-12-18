using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float jumpForce;
    public float ballSpeed;

    Rigidbody rb;
    Transform cameraFollow;
    Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = Camera.main.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        // press arrow ball run

        float xSpped = Input.GetAxis("Horizontal");
        float zSpeed = Input.GetAxis("Vertical");
        rb.AddTorque(new Vector3(xSpped, 0, zSpeed) * ballSpeed * Time.deltaTime);

        // press speace ball up
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce * 200 * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        //vec.x = cameraFollow.transform.position.x;
        vec.y = cameraFollow.transform.position.y;
        //vec.z = transform.position.z;

        cameraFollow.transform.position = vec;
    }
}
