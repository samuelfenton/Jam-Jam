using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float m_damage = 2.0f;
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if(hit.collider.tag == "Player")
                hit.collider.gameObject.GetComponent<BaseCharacter>().TakeDamage(m_damage);
        }
	}
}
