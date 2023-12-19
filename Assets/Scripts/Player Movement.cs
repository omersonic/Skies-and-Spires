using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    
    [SerializeField] private float thrustSpeed = 1000f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float rotInputX = 0.6f;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // gets the rigidbody component
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        }
        
    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed, rotInputX); 
        }

        else if (Input.GetKey(KeyCode.D)) { // else if = otherwise, meaning if the if before isnt pressed
            
            ApplyRotation(-rotateSpeed, rotInputX); // the parameter rotThisFrame allows a negative input as well
        }
    }

    private void ApplyRotation(float rotThisFrame, float rotInputFrame) // uses a parameter as a variable for the rotation speed
    {
        //rb.freezeRotation = true; //freezing rotation so we can manually rotate
        //transform.Rotate(Vector3.forward * rotThisFrame * Time.deltaTime);
        // rb.freezeRotation = false; // unfreezing rotation so the physics system can take over

        rb.AddTorque(Vector3.forward * rotThisFrame * Time.deltaTime * rotInputFrame);
        // This is another possible solution, where the constraints aren't cancelled like in the above
        
    }
}
