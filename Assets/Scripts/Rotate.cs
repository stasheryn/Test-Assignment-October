using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 130f;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
    }
}