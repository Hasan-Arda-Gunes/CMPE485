using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyForce : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10f;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * forceAmount);

    }
}
