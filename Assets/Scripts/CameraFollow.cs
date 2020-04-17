using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;
    public float cameraSpeed;

    private void Update()
    {
        this.targetPosition = new Vector3(this.target.transform.position.x, this.target.transform.position.y, this.transform.position.z);
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, this.cameraSpeed * Time.deltaTime);
    }
}
