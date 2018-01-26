using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : PlayerRobot
{
    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    [SerializeField]
    private float m_clampPitchAngle = 75.0f;

    [SerializeField]
    private GameObject m_charaterModelHolder = null;

    [SerializeField]
    private Vector3 m_bulletSpawnPos = Vector3.zero;
    [SerializeField]
    private float m_fireDelay = 1.0f;
    [SerializeField]
    private GameObject m_bullet = null;

    private bool m_canFire = true;
	
	// Update is called once per frame
	public override void Update ()
    {
        //Player trasmission abilities
        base.Update();

        //Rotation TurretGun
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        Vector3 localEulerAngle = m_charaterModelHolder.transform.localEulerAngles;

        //Pitch
        localEulerAngle.x -= inputMouseY * m_rotationSpeed;

        //Clamp pitch
        if (localEulerAngle.x > m_clampPitchAngle && localEulerAngle.x <180)
            localEulerAngle.x = m_clampPitchAngle;

        if (localEulerAngle.x < 360 - m_clampPitchAngle && localEulerAngle.x > 180)
            localEulerAngle.x = -m_clampPitchAngle;

        //Yaw
        localEulerAngle.y += inputMouseX * m_rotationSpeed;
        localEulerAngle.z = 0.0f;
        m_charaterModelHolder.transform.localEulerAngles = localEulerAngle;

        if (Input.GetAxisRaw("Fire1")!=0.0f && m_canFire)//Fire bullet
        {
            Instantiate(m_bullet, m_charaterModelHolder.transform.TransformPoint(m_bulletSpawnPos), m_charaterModelHolder.transform.rotation);
            m_canFire = false;
            Invoke("EnableFiring", m_fireDelay);
        }
    }

    private void EnableFiring()
    {
        m_canFire = true;
    }
}
