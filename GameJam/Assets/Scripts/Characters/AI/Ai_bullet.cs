using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_bullet : MonoBehaviour {

    BaseCharacter player;
    public float damage;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "player";
        player.TakeDamage(damage);
        Destroy(gameObject);
    }
}
