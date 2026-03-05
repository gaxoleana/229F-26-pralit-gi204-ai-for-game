using UnityEngine;

public class SpinBarrel : MonoBehaviour
{
    public float moveForce = 800f;
    public float spinForce = 150f;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * spinForce);
            // Optional: Add a little upward force to make it hop
            rb.AddForce(transform.up * (spinForce / 2));
        }
    }
}
