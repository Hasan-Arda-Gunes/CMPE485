using System.Collections;
using UnityEngine;

public class SawbladeTrap : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 3f;
   

    void Start()
    {
        StartCoroutine(MoveSawblade());
    }

    IEnumerator MoveSawblade()
    {
        Vector3 nextTarget = endPoint.position;

        while (true)
        {
            // Move toward the target
            transform.position = Vector3.MoveTowards(transform.position, nextTarget, speed * Time.deltaTime);

            // If reached the target, switch to the other point
            if (Vector3.Distance(transform.position, nextTarget) < 0.1f)
            {
                nextTarget = (nextTarget == startPoint.position) ? endPoint.position : startPoint.position;

                yield return new WaitForSeconds(0.5f);
            }

            yield return null;
        }
    }

}