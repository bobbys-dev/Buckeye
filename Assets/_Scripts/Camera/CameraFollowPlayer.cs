using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 camera_offset = new Vector3(0, 10, -20);

    public Vector3 Camera_offset { get => camera_offset; set => camera_offset = value; }

    // Use LateUpdate so that it updates after all other items have been processed
    void LateUpdate()
    {
        transform.position = player.position + camera_offset;
    }
}
