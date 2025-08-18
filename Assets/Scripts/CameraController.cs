using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetZ = 6.7f;
    public float smoothSpeed = 0.125f;

    Transform playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = Object.FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() 
    {
        // Camera position should be in
        Vector3 targetPosition = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z - offsetZ);

        // Set camera position to target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
