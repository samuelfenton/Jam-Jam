using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseCharacter

{
    [SerializeField]
    private GameObject m_Explosion;

    public GameObject m_BrokenDoor;

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

        Destroy(Instantiate(m_Explosion, transform.position, Quaternion.identity),5.0f);
        m_BrokenDoor.SetActive(true);

        Destroy(gameObject);
    }
}
