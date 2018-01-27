using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : BaseCharacter
{

    [SerializeField]
    private GameObject m_Explosions;

    public float m_Timer = 25;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	public override void Update()
    {
        base.Update();

        m_Timer -= Time.deltaTime;

        if(m_timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void OnDeath()
    {
        base.OnDeath();

        Instantiate(m_Explosions, transform.position, Quaternion.identity);

        Destroy(gameObject);


    }
}
