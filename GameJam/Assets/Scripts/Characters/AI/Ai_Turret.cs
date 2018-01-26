using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Turret : AIRobot
{
    public Transform m_turret;
    public GameObject Player;
    public GameObject bullet;
    public float distance = 5;
    public float lookdistance = 10;
    float range;

    [SerializeField]
    private float m_fireDelay = 1.0f;
    private bool m_canFire = true;

    [SerializeField]
    private Vector3 m_bulletSpawnPos = Vector3.zero;


    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        range = Vector3.Distance(Player.transform.position, m_turret.position);

       //TODO can see player
        if (range < lookdistance)
        {   
            look();
            if(range < distance && m_canFire)
            {
                shoot();
            }
        }
	}

    void look()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(Player.transform);
    }

    void shoot()
    {

        Instantiate(bullet, transform.TransformPoint(m_bulletSpawnPos), transform.rotation);

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
