using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float m_damage;
    [SerializeField]
    private float m_bulletSpeed = 0.0f;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * m_bulletSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player" || collision.collider.gameObject.tag == "Enemy")
            collision.collider.gameObject.GetComponent<BaseCharacter>().TakeDamage(m_damage);

        if (collision.collider.gameObject.tag == "Door")
        {
            //TODO door stuff
        }

        Destroy(gameObject);
    }
}
