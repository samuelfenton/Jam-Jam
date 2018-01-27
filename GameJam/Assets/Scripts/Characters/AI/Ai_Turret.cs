using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Turret : AIRobot
{
    private Animator m_animator = null;

    private GameObject m_player = null;
    public GameObject m_bullet = null;
    public float m_firingRange = 5;
    public float m_lookDistance = 10;

    [SerializeField]
    private float m_fireDelay = 1.0f;
    private bool m_canFire = true;

    private bool m_wakeupSequence = true;

    [SerializeField]
    private Vector3 m_bulletSpawnPos = Vector3.zero;

    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    [SerializeField]
    private float m_clampPitchAngle = 75.0f;

    [SerializeField]
    private GameObject m_turretBaseModel = null;
    [SerializeField]
    private GameObject m_turretGunModel = null;


    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.speed = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        m_player = GameObject.FindGameObjectWithTag("Player");

        if (m_wakeupSequence)
        {
            if (CanSeePlayer())
                m_animator.speed = 1;

            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                m_animator.enabled = false;
                m_wakeupSequence = false;
            }
        }
        else
        {
            if (m_player != null)
            {
                float m_playerDistance = Vector3.Distance(m_player.transform.position, transform.position);

                Look();

                if (m_playerDistance < m_firingRange && m_canFire && CanSeePlayer())
                { 
                    Shoot();
                }
            }
        }
    }

    void Look()
    {
        m_turretBaseModel.transform.LookAt(m_player.transform);
    }

    void Shoot()
    {
        Instantiate(m_bullet, m_turretGunModel.transform.TransformPoint(m_bulletSpawnPos), m_turretGunModel.transform.rotation);

        m_canFire = false;
        Invoke("EnableFiring", m_fireDelay);
    }


    private void EnableFiring()
    {
        m_canFire = true;
    }

    private bool CanSeePlayer()
    {
        RaycastHit hit;
        if(Physics.Raycast(m_turretGunModel.transform.TransformPoint(m_bulletSpawnPos), m_player.transform.position - m_turretGunModel.transform.TransformPoint(m_bulletSpawnPos), out hit, m_lookDistance))
        {
            if (hit.collider.tag == "Player")
                return true;
        }
        return false;
    }



}
