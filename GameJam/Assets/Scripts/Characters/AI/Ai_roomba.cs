using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_roomba : AIRobot
{
    public GameObject[] m_nodes;
    int m_nodeIndex = 0;

    [SerializeField]
    private float m_closingDistance = 2;

    [SerializeField]
    private float m_forwardSpeed = 2;

    private Rigidbody m_rbCharacter = null;
	// Use this for initialization
	void Start ()
    {
        m_rbCharacter = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (Vector3.Distance(m_nodes[m_nodeIndex].transform.position, transform.position) < m_closingDistance)
            NextNode();
        else
            GoToNode();
    }
    void GoToNode()
    {
        Vector3 movementDir = (m_nodes[m_nodeIndex].transform.position - gameObject.transform.position).normalized;
        m_rbCharacter.velocity = movementDir * m_forwardSpeed;
    }

    void NextNode()
    {
        if (m_nodeIndex == m_nodes.Length -1) //End of nodes
        {
            m_nodeIndex = 0;
            transform.position = m_nodes[0].transform.position;
        }
        else
        {
            m_nodeIndex++;
        }

        //Rotate to face next node
        transform.LookAt(m_nodes[m_nodeIndex].transform.position);

    }
}
