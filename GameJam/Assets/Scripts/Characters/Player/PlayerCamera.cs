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
    private GameObject m_transmitEffect = null;

    [SerializeField]
    private float m_transmittingTime = 0.0f;
    private float m_transmittingTimer = 0.0f;

    [SerializeField]
    private Vector3 m_cameraRotationOffset = new Vector3(16.0f, 0.0f, 0.0f);

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
                    TransmitColour(m_transmittingTimer/ m_transmittingTime);
                }
                break;
        }
	}

    public void SetTrasmit(GameObject destinationObject)
    {
        transform.parent = null;

        m_destinationObject = destinationObject;

        Rigidbody rbDestination = m_destinationObject.GetComponent<Rigidbody>();
        if(rbDestination!=null)
            m_destinationObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (m_destinationObject.GetComponent<AIRobot>() != null)
            m_destinationObject.GetComponent<AIRobot>().enabled = false;

        m_transmittingTimer = 0.0f;
        m_cameraState = CAMERA_STATE.TRANSMITTING;

        m_intialPosition = transform.position;
        m_intialRotation = transform.rotation;

        m_destinationPosition = m_destinationObject.GetComponent<PlayerRobot>().GetCameraAnchor().TransformPoint(m_destinationObject.GetComponent<PlayerRobot>().GetCameraPos());

        m_destinationRotation = m_destinationObject.transform.rotation * Quaternion.Euler(m_cameraRotationOffset);

        if (m_transmitEffect != null)
        {
            GameObject transmitEffect = Instantiate(m_transmitEffect, transform.position, Quaternion.identity);
            transmitEffect.GetComponent<ParticleSystem>().startLifetime = Vector3.Distance(m_destinationObject.transform.position, transform.position) / 3;
            transmitEffect.transform.LookAt(m_destinationObject.transform.position);
            Destroy(transmitEffect, 5.0f);
        }
    }

    private void TransmitArrival()
    {
        //Set up scripts
        m_destinationObject.GetComponent<PlayerRobot>().enabled = true;

        //set up fixed position
        transform.parent = m_destinationObject.GetComponent<PlayerRobot>().GetCameraAnchor();
        transform.localPosition = m_destinationObject.GetComponent<PlayerRobot>().GetCameraPos() ;
        transform.localRotation = Quaternion.Euler(16.0f, 0.0f, 0.0f);

        m_cameraState = CAMERA_STATE.FIXED;
    }

    private void TransmitColour(float colourPercent)
    {
        Renderer[] childRenderers = m_destinationObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in childRenderers)
        {
            renderer.material.SetFloat("_Emmisivechange", 1 - ( 2 * colourPercent));
        }
    }
}
