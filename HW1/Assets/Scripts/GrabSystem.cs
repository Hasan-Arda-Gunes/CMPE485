using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public Transform holdParent;
    public float grabRange = 2f;
    private GameObject grabbedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press E to Grab/Drop
        {
            if (grabbedObject == null)
            {
                TryGrab();
            }
            else
            {
                Drop();
            }
        }
    }

    void TryGrab()
    {
        // Check for nearby objects with the "Key" tag
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRange);
        foreach (var col in colliders)
        {
            if (col.CompareTag("Key"))
            {
                grabbedObject = col.gameObject;
                Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();

                // Disable physics while holding
                rb.isKinematic = true;
                grabbedObject.transform.SetParent(holdParent);
                grabbedObject.transform.localPosition = Vector3.zero;
                break;
            }
        }
    }

    void Drop()
    {
        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject.tag = "Key"; // Ensure it keeps its tag
        grabbedObject = null;
    }
}