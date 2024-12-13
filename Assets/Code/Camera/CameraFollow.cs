using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float smooth;


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x + xOffset, targetTransform.position.y + yOffset, -10), smooth * Time.deltaTime);
    }


}
