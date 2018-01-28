using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCapsule : MonoBehaviour
{
    [SerializeField]
    private GameObject m_intialDrone = null;

    [SerializeField]
    private GameObject m_intialPrefab = null;

    private Vector3 m_intialPosition = Vector3.zero;
    private Quaternion m_intialRotation = Quaternion.identity;

    // Use this for initialization
    void Start ()
    {
        m_intialPosition = m_intialDrone.transform.position;
        m_intialRotation = m_intialDrone.transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_intialDrone == null)
        {
            m_intialDrone = Instantiate(m_intialPrefab, m_intialPosition, m_intialRotation);
            m_intialDrone.GetComponent<PlayerDrone>().SetHome(this.gameObject);
        }
	}
}
