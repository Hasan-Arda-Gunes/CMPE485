using UnityEngine;
using System.Collections;

public class SkeletonGuard : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    public Transform player;
    public GameObject loseUI;
    public float visionDepth = 15.0f;
    public float visionWidth = 2.0f;
    void Start()
    {
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        Transform target = pointB;

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Rotate to face the target
            transform.LookAt(target.position);

            // Check if reached the target
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                target = (target == pointA) ? pointB : pointA;
                yield return new WaitForSeconds(1.0f);
            }
            Vector3 relativePlayerPos = transform.InverseTransformPoint(player.position);
            bool isWithinWidth = Mathf.Abs(relativePlayerPos.x) < visionWidth / 2;
            bool isWithinDepth = relativePlayerPos.z > 0 && relativePlayerPos.z < visionDepth;

            if (isWithinWidth && isWithinDepth)
            {
                CatchPlayer();
            }

            yield return null;
        }
    }

    void CatchPlayer()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}