using UnityEngine;

public class AirPlane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f;
    [SerializeField] float liftBootser = 0.5f;
    [SerializeField] float drag = 0.001f;
    [SerializeField] float angulardrag = 0.001f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float pitchPower = 50f;
    [SerializeField] float rollPower = 50f;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.forward * enginePower);
        }
       
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBootser);

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * pitchPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}
