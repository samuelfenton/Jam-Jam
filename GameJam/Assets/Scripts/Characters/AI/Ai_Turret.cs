using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Turret : AIRobot
{
    private GameObject m_Player;
    public GameObject m_Bullet;
    public float m_Distance = 5;
    public float m_lookDistance = 10;
    private float m_range = 0;

    [SerializeField]
    private float m_fireDelay = 1.0f;
    private bool m_canFire = true;

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


    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        m_Player = GameObject.FindGameObjectWithTag("Player");

        if(m_Player != null)
        {
            m_range = Vector3.Distance(m_Player.transform.position, transform.position);

           //TODO can see player
            if (m_range < m_lookDistance)
            {
                Look();
                if(m_range < m_Distance && m_canFire)
                {
                    Shoot();
                }
            }
        }
	}

    void Look()
    {
        //Vector3 lookGunDir = m_Player.transform.position - m_turretGunModel.transform.position;

        //m_turretBaseModel.transform.LookAt(m_Player.transform);

        //Yaw
        //Update Yaw
        //Vector3 localEulerBase = m_turretBaseModel.transform.localEulerAngles;

        //localEulerBase.y += aimX * m_rotationSpeed;
        //localEulerBase.z = 0.0f;

        //m_turretBaseModel.transform.localEulerAngles = localEulerBase;
    }

    void Shoot()
    {

        Instantiate(m_Bullet, transform.TransformPoint(m_bulletSpawnPos), transform.rotation);

        //need make timer for bullets and rotaion speed
        //make ray cast so dont shoot threq walls

        m_canFire = false;
        Invoke("EnableFiring", m_fireDelay);
    }


    private void EnableFiring()
    {
        m_canFire = true;
    }


}
