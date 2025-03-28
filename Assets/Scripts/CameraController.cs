using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform kart;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (kart == null) return;
        Vector3 desiredPosition = kart.position + kart.TransformDirection(offset);


        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(kart.position + kart.forward * 2f);
    }
}
