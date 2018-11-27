using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class first_person_controller : MonoBehaviour
{

    public float speed = 5f;
    public Transform cam;
    public Rigidbody rb;
    public Vector3 velocity = Vector3.zero;
    public float verticalLookRotation;
    public float mouseSensitivity = 250f;
    public float distance = 5;
    public bool collided = false;
    public Collision other2;
    int counter = 0;

    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * yMov;
        Vector3 movUp = transform.up * zMov;
        velocity = (movHor + movVer + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.localEulerAngles = Vector3.left * verticalLookRotation;

    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (collided == true && Input.GetButtonDown("Fire1"))
        {
            other2.gameObject.SetActive(false);
            counter = counter + 1;
            TextMesh textObject = GameObject.Find("score").GetComponent<TextMesh>();
            TextMesh textObject2 = GameObject.Find("score2").GetComponent<TextMesh>();
            TextMesh textObject3 = GameObject.Find("score3").GetComponent<TextMesh>();

            if (counter < 10)
                textObject.text = "Score: " + counter.ToString();
            else
            {
                textObject.text = "¡Rescataste";
                textObject2.text = "a todos";
                textObject3.text = "los perritos!";
            }

            collided = false;
        }

    }

    void OnCollisionStay(Collision other)
    {
         if (other.gameObject.CompareTag("PickUp"))
         {
            other2 = other;
            collided = true;
          }
    }

}
