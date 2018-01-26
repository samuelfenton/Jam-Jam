using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private enum CAMERA_STATE {FIXED, TRANSMITTING};
    private CAMERA_STATE m_cameraState = CAMERA_STATE.FIXED;

    private GameObject m_destinationObject = null;
    private Vector3 m_intialPosition = Vector3.zero;
    private Quaternion m_intialRotation = Quaternion.identity;
    private Vector3 m_destinationPosition = Vector3.zero;
    private Quaternion m_destinationRotation = Quaternion.identity;

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

                if (m_transmittingTimer >= m_transmittingTime)
                    TransmitArrival();
                else
                {
                    transform.position = Vector3.Lerp(m_intialPosition, m_destinationPosition, m_transmittingTimer / m_transmittingTime);
                    transform.rotation = Quaternion.Lerp(m_intialRotation, m_destinationRotation, m_transmittingTimer / m_transmittingTime);
                }
                break;
        }
	}

    public void SetTrasmit(GameObject destinationObject)
    {
        transform.parent = null;

        m_destinationObject = destinationObject;

        if (m_destinationObject.GetComponent<AIRobot>() != null)
            m_destinationObject.GetComponent<AIRobot>().enabled = false;

        m_transmittingTimer = 0.0f;
        m_cameraState = CAMERA_STATE.TRANSMITTING;

        m_intialPosition = transform.position;
        m_intialRotation = transform.rotation;
        m_destinationPosition = m_destinationObject.GetComponent<PlayerRobot>().GetCameraPos();
        m_destinationRotation = m_destinationObject.transform.rotation;
    }

    private void TransmitArrival()
    {
        //Set up scripts
        m_destinationObject.GetComponent<PlayerRobot>().enabled = true;

        //set up fixed position
        gameObject.transform.parent = m_destinationObject.GetComponent<PlayerRobot>().GetCameraAnchor();
        transform.localPosition = m_destinationPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        m_cameraState = CAMERA_STATE.FIXED;
    }
}
