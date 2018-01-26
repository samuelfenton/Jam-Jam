﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobot : BaseCharacter
{
    private float m_trasmitRange = 2.0f;
    private GameObject m_trasmitObject = null;

    public Vector3 m_cameraOffset = Vector3.zero;

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        //Player jumping

        if(Input.GetAxisRaw("Fire1") != 0.0f)
        {
            GameObject trasmitObject = GetTransmitableObject();
            if (trasmitObject != null)
                Trasmit(trasmitObject);
            Debug.Log(trasmitObject);
        }
	}

    private GameObject GetTransmitableObject()
    {
        Collider[] objectInRange = Physics.OverlapSphere(transform.position, m_trasmitRange);

        GameObject transmitableObject = null;

        foreach (Collider col in objectInRange)
        {
            if(col.gameObject.tag == "Enemy")
            {
                if (transmitableObject == null)
                    transmitableObject = col.gameObject;
                else if(Vector3.Distance(col.gameObject.transform.position, transform.position) < Vector3.Distance(transmitableObject.transform.position, transform.position)) //Get closest object to trasmit
                    transmitableObject = col.gameObject;
            }
        }

        return transmitableObject;
    }

    private void Trasmit(GameObject jumpObject)
    {
        gameObject.tag = "Enemy";
        GameController.instance.Trasmit(jumpObject);
        GetComponent<BaseCharacter>().OnDeath();
    }
}