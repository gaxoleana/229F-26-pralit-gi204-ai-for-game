using UnityEngine;

public class SpinBarrel : MonoBehaviour
{
    public float moveForce = 80f;
    public float spinTorque = 15f;

    public AudioSource rollingSource;
    public float maxVolumeSpeed = 1f;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rollingSource != null)
        {
            rollingSource.loop = true;
            rollingSource.playOnAwake = true;
            rollingSource.volume = 0;
            rollingSource.Play();
        }
    }


    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.right * moveForce);
            rb.AddTorque(transform.right * spinTorque);
        }

        if (rollingSource != null)
        {
            float currentSpeed = rb.linearVelocity.magnitude;
            Debug.Log("Current Speed is " + currentSpeed);
            rollingSource.volume = Mathf.Lerp(0, 1, currentSpeed / maxVolumeSpeed);
            rollingSource.pitch = Mathf.Lerp(1.0f, 0.8f, currentSpeed / maxVolumeSpeed);
        }
    }
}
