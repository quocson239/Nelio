using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float parallaxFactor;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        float parallaxMovementX = deltaMovement.x * parallaxFactor;
        float parallaxMovementY = deltaMovement.y * parallaxFactor;

        transform.position = new Vector3(
            transform.position.x + parallaxMovementX,
            transform.position.y + parallaxMovementY,
            transform.position.z
        );

        lastCameraPosition = cameraTransform.position;
    }
}