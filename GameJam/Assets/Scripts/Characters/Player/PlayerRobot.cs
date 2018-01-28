using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobot : BaseCharacter
{
    [SerializeField]
    private float m_trasmitRange = 2.0f;

    [SerializeField]
    protected Vector3 m_cameraOffset = Vector3.zero;

    [SerializeField]
    protected GameObject m_charaterModelHolder = null;

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        //Player jumping

        if(Input.GetAxisRaw("Fire2") != 0.0f)
        {
            GameObject trasmitObject = GetTransmitableObject();
            if (trasmitObject != null)
                Trasmit(trasmitObject);
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
        jumpObject.tag = "Player";
        GameManager.instance.Trasmit(jumpObject);
        tag = "Untagged";
        OnDeath();
        this.enabled = false;
    }

    //Used to get camera spawning pos
    public virtual Vector3 GetCameraPos()
    {
        return m_cameraOffset;
    }

    //Used to get camera parent anchor
    public virtual Transform GetCameraAnchor()
    {
        return gameObject.transform;
    }

    public GameObject GetModel()
    {
        return m_charaterModelHolder;
    }

}
