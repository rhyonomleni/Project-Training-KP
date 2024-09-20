using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    public bool isOnGround = true;
    public float jumpForce = 10;
    private float xRange = 20;
    private float zRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.forward * speed * verticalInput);
        rb.AddForce(Vector3.right * speed * horizontalInput);

        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -15){
            transform.position = new Vector3(transform.position.x, transform.position.y, -15);
        }
        if (transform.position.z > zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        isOnGround = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Powerup")){
            Destroy(other.gameObject);
        }
    }
}
