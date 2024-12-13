using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;


    private void LateUpdate() {
        transform.position = new Vector3(targetTransform.position.x + xOffset, targetTransform.position.y + yOffset, -10);
    }


}
