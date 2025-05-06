using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float yOffset = 2f;
    public float zOffset = -10f;

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, yOffset, zOffset);
        }
    }
}
