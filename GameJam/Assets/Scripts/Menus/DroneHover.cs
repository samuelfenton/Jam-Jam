using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHover : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		transform.position += transform.up * (Mathf.Sin(Time.fixedTime)/250.0f);
	}
}
