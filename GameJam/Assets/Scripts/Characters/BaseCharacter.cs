using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    private float m_health = 2;

    [SerializeField]
    private GameObject m_deathEffect = null;
	
	// Update is called once per frame
	void Update ()
    {
        if (m_health < 0.0f)
            OnDeath();
    }

    public void TakeDamage(float damage)
    {
        m_health -= damage;
    }

    public virtual void OnDeath()
    {
        if (m_deathEffect != null)
            Destroy(Instantiate(m_deathEffect, transform.position, Quaternion.identity), 5.0f);
        Destroy(gameObject);
    }
}
