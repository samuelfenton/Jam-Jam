using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    [SerializeField]
    private GameObject m_CreditsText;
    private Vector3 m_Direction;
    [SerializeField]
    private float m_Speed;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        m_CreditsText.transform.Translate((Vector3.up * m_Speed)* Time.deltaTime);
	}
}
