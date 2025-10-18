using UnityEngine;

public class CameraFollowObj : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.06f, -7);

    void LateUpdate()
    {
        if (target != null)
            transform.position = new (target.position.x + offset.x, offset.y, offset.z);
    }
}
