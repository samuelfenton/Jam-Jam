using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseCharacter

{
    [SerializeField]
    GameObject m_Explosion;
    GameObject m_BrokenDoor;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
	}

    public override void OnDeath()
    {
        base.OnDeath();

        Instantiate(m_Explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);

        m_BrokenDoor.SetActive(true);
    }
}
