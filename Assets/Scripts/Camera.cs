using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offset = new Vector3(0,2,5);

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
