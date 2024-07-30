using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControls : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float transitionDuration = 1.0f;
    public float finalFOV = 60f;
    public Vector3 finalFollowOffset = new Vector3(0f, 1.5f, -5f);


private float initialFOV;
private Vector3 initialFollowOffset;
private bool isTransitioning = false;


    public GameObject target;

    public Vector3 posOffset;

    // Start is called before the first frame update
    void Start()
    {

       initialFOV = virtualCamera.m_Lens.FieldOfView;
       initialFollowOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransitioning)
        {
            float t = Mathf.Clamp01(Time.deltaTime / transitionDuration);
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, finalFOV, t);

            CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, finalFollowOffset, t);

            if (Mathf.Approximately(virtualCamera.m_Lens. FieldOfView, finalFOV) &&
                transposer.m_FollowOffset == finalFollowOffset)
                {
                    isTransitioning = false;
                }
        }
    }


    public void TransitionToWideAngle()
    {
        isTransitioning = true;
    }


    public void TransitionToSidescrollAngle()
    {
        isTransitioning = true;
    }


    public void ResetCamera()
    {
        finalFOV = initialFOV;
        finalFollowOffset = initialFollowOffset;
        isTransitioning = true;
    }
}

