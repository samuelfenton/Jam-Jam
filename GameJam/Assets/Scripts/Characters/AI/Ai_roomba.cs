using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_roomba : AIRobot
{
    public GameObject[] nodes;
    int nodesnum = 0;
    public float distance = 2;
    float range;

	// Use this for initialization
	void Start ()
    {
        nextnode();
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        range = Vector3.Distance(nodes[nodesnum].transform.position, transform.position);
        if(range > distance)
        {
            followNodes();

        }
    }
    void followNodes()
    {
        gameObject.transform.position = (nodes[nodesnum].transform.position  - gameObject.transform.position) * Time.deltaTime;
        nextnode();
    }

    void nextnode()
    {
        if (nodes.Length == 0)
        {
            return;
        }

        if(range == 0)
        nodesnum = (nodesnum + 1) % nodes.Length;
    }
}
