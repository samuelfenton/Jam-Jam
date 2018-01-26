using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private enum CAMERA_STATE {FIXED, TRANSMITTING};
    private CAMERA_STATE m_cameraState = CAMERA_STATE.FIXED;

    private GameObject m_destinationObject = null;
    private Transform m_intialTransform = null;
    private Transform m_destinationTransform = null;

    [SerializeField]
    private float m_transmittingTime = 0.0f;
    private float m_transmittingTimer = 0.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		switch(m_cameraState)
        {
            case CAMERA_STATE.FIXED:

                break;
            case CAMERA_STATE.TRANSMITTING:
                //lerp from initial to destination transform
                m_transmittingTimer += Time.deltaTime;

                if (m_transmittingTimer <= m_transmittingTime)
                    TransmitArrival();
                else
                {
                    transform.position = Vector3.Lerp(m_intialTransform.position, m_destinationTransform.position, m_transmittingTimer / m_transmittingTime);
                    transform.rotation = Quaternion.Lerp(m_intialTransform.rotation, m_destinationTransform.rotation, m_transmittingTimer / m_transmittingTime);
                }
                break;
        }
	}

    public void SetTrasmit(GameObject destinationObject)
    {
        m_destinationObject = destinationObject;

        m_intialTransform = transform;

        m_destinationTransform.position = m_destinationObject.transform.TransformPoint(m_destinationObject.GetComponent<PlayerRobot>().m_cameraOffset);
        m_destinationTransform.rotation = m_destinationObject.transform.rotation;

        m_destinationObject.GetComponent<AIRobot>().enabled = false;
        m_transmittingTimer = 0.0f;
        m_cameraState = CAMERA_STATE.TRANSMITTING;
    }

    private void TransmitArrival()
    {
        //Set up scripts
        m_destinationObject.GetComponent<PlayerRobot>().enabled = true;

        //set up fixed position
        gameObject.transform.parent = m_destinationObject.transform;
        transform.localPosition = m_destinationObject.GetComponent<PlayerRobot>().m_cameraOffset;
        m_destinationTransform.rotation = Quaternion.Euler(Vector3.zero);

        m_cameraState = CAMERA_STATE.FIXED;
    }
}
