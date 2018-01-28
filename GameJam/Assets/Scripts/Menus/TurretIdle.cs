using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdle : MonoBehaviour
{
    private Animator m_animator = null;

    [SerializeField]
    private GameObject m_turretBaseModel = null;

    [SerializeField]
    private GameObject m_turretGunModel = null;

    [SerializeField]
    private GameObject m_target = null;

    // Use this for initialization
    void Start ()
    {
        m_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(m_animator.enabled == false)
            m_turretBaseModel.transform.LookAt(m_target.transform);
        else if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            m_animator.enabled = false;
        }
    }
}
