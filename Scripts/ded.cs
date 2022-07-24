using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ded : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("dice")||other.CompareTag("enemy"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();


            if (rb != null)
            {
                rb.transform.position = new Vector3(-355, 0, 61);
                rb.velocity = new Vector3(0, 0, 0);
            }
        }

    }


}
