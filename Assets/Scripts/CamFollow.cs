using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform playTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void LateUpdate()
    {
        Vector3 newPos = playTarget.position;
        newPos.z = -10;
        transform.position = newPos;
    }
}
