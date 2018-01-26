using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    
    public float m_health = 2;
    public float m_timer = 30;

    [SerializeField]
    private GameObject m_deathEffect = null;

    // Update is called once per frame
    public virtual void Update ()
    {
        m_timer += Time.deltaTime;

        if (m_health < 0.0f)
            OnDeath();

        if (m_timer< 0.0f)
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
        Destroy(this.gameObject);
    }
}
