using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target;
    public LayerMask collisionMask;
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public float smoothSpeed = 5f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }


    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;


            float distance = direction.magnitude;


            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, maxDistance, collisionMask))
            {
                float targetDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
                Vector3 targetPosition = target.position - transform.forward * targetDistance;
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 targetPosition = target.position - transform.forward * maxDistance;
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            }
        }
    }
   
}
