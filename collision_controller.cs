using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_controller : MonoBehaviour
{

    public first_person_controller movement;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "fence")
        {
            movement.enabled = false;
        }
    }

}