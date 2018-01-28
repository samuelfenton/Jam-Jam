using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public float m_health = 2;
    public float m_timer = 0;

    [SerializeField]
    private GameObject m_deathEffect = null;

    // Update is called once per frame
    public virtual void Update ()
    {
        m_timer += Time.deltaTime;

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

        if(tag != "Player")
            Destroy(this.gameObject);
        else
        {
            GameManager.instance.m_canvasUI.GetComponentInChildren<UI>().PlayDamageMessage();
            GameManager.instance.DeathTrasmit(transform.position + Vector3.up + Vector3.back, transform.rotation * Quaternion.Euler(70.0f, 0.0f, 0.0f));
            Destroy(this.gameObject);
        }
    }
}
