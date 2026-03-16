
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float sensitivity = 5f;
    float mouseX;
    float mouseY;
    float offsetDistanceY;

    Transform player;

    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        offsetDistanceY = transform.position.y * 5;
    }


    void Update()
    {

        transform.position = player.position + new Vector3(0, offsetDistanceY, 0);
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);

    }
}