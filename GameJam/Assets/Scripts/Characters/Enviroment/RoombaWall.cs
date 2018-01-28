using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaWall : MonoBehaviour {

    [SerializeField]
    private GameObject m_initialRoomba = null;

    [SerializeField]
    private GameObject m_intialPrefab = null;

    private GameObject[] m_nodes;

    private Vector3 m_intialPosition = Vector3.zero;
    private Quaternion m_intialRotation = Quaternion.identity;

    // Use this for initialization
    void Start()
    {
        m_intialPosition = m_initialRoomba.transform.position;
        m_intialRotation = m_initialRoomba.transform.rotation;

        m_nodes = m_initialRoomba.GetComponent<Ai_roomba>().GetNodes();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_initialRoomba == null)
        {
            m_initialRoomba = Instantiate(m_intialPrefab, m_intialPosition, m_intialRotation);
            m_initialRoomba.GetComponent<Ai_roomba>().SetNodes(m_nodes);
        }
    }
}
