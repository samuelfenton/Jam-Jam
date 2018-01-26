using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Turret : MonoBehaviour {


    public Transform gameobject;
    public Transform Turret;
    public GameObject Player;
    public GameObject bullet;
    public float distance = 5;
    public float lookdistance = 10;
    float range;

    [SerializeField]
    private float m_fireDelay = 1.0f;
    private bool m_canFire = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        range = Vector3.Distance(gameobject.position, Turret.position);

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
        GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(gameobject);
    }

    void shoot()
    {

        Instantiate<GameObject>(bullet, transform.position, transform.rotation);

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
