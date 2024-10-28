using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    [SerializeField] private Transform ballTransform;
    private Vector3 offset;

    [SerializeField] private float lerpTime;

    void Start()
    {
        offset = transform.position - ballTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpTime * Time.deltaTime);
        transform.position = newPos;
    }
}
