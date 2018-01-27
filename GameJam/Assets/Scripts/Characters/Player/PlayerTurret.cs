using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : PlayerRobot
{
    private Animator m_animator = null;

    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    [SerializeField]
    private float m_clampPitchAngle = 75.0f;

    [SerializeField]
    private GameObject m_turretBaseModel = null;
    [SerializeField]
    private GameObject m_turretGunModel = null;

    [SerializeField]
    private Vector3 m_bulletSpawnPos = Vector3.zero;
    [SerializeField]
    private float m_fireDelay = 1.0f;
    [SerializeField]
    private GameObject m_bullet = null;

    private bool m_canFire = true;
	
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	public override void Update ()
    {
        //Disbale animator on idle
        if(m_animator.enabled)
        {
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                m_animator.enabled = false;
            }
        }

        //Player trasmission abilities
        base.Update();

        //Rotation TurretGun
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        //Update pitch
        Vector3 localEulerGun = m_turretGunModel.transform.localEulerAngles;

        //Pitch
        localEulerGun.x -= inputMouseY * m_rotationSpeed;
        localEulerGun.z = 0.0f;

        //Clamp pitch
        if (localEulerGun.x > m_clampPitchAngle && localEulerGun.x <180)
            localEulerGun.x = m_clampPitchAngle;

        if (localEulerGun.x < 360 - m_clampPitchAngle && localEulerGun.x > 180)
            localEulerGun.x = -m_clampPitchAngle;

        m_turretGunModel.transform.localEulerAngles = localEulerGun;

        //Yaw
        //Update Yaw
        Vector3 localEulerBase = m_turretBaseModel.transform.localEulerAngles;

        localEulerBase.y += inputMouseX * m_rotationSpeed;
        localEulerBase.z = 0.0f;

        m_turretBaseModel.transform.localEulerAngles = localEulerBase;

        if (Input.GetAxisRaw("Fire1")!=0.0f && m_canFire)//Fire bullet
        {
            Instantiate(m_bullet, m_turretGunModel.transform.TransformPoint(m_bulletSpawnPos), m_turretGunModel.transform.rotation);
            m_canFire = false;
            Invoke("EnableFiring", m_fireDelay);
            m_animator.enabled = true;
            m_animator.SetTrigger("FireGun");
        }
    }

    private void EnableFiring()
    {
        m_canFire = true;
    }

    public override Transform GetCameraAnchor()
    {
        return m_turretGunModel.transform;
    }
}
