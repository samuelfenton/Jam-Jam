using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_roomba : AIRobot
{
    public GameObject[] m_Nodes;
    int m_NodesNumber = 0;
    public float m_Distance = 2;
    float m_Range;

	// Use this for initialization
	void Start ()
    {
        nextnode();
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        m_Range = Vector3.Distance(m_Nodes[m_NodesNumber].transform.position, transform.position);
        if(m_Range > m_Distance)
        {
            followNodes();

        }
    }
    void followNodes()
    {
        gameObject.transform.position = (m_Nodes[m_NodesNumber].transform.position  - gameObject.transform.position) * Time.deltaTime;
        nextnode();
    }

    void nextnode()
    {
        if (m_Nodes.Length == 0)
        {
            return;
        }

        if(m_Range == 0)
        m_NodesNumber = (m_NodesNumber + 1) % m_Nodes.Length;
    }
}
