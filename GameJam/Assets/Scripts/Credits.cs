using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : BaseCharacter
{

    [SerializeField]
    private GameObject m_Explosions;




    // Use this for initialization
    void Start ()
    {
		
	}
	
	public override void Update()
    {
        base.Update();
    }

    public override void OnDeath()
    {
        base.OnDeath();

        Instantiate(m_Explosions, transform.position, Quaternion.identity);

        Destroy(gameObject);


    }
}
