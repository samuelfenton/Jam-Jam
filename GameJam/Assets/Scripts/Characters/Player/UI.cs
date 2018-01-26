using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Slider m_Health;

    public Text m_Timer;

    public GameObject m_Hack;
    public GameObject m_Threat;
    public GameObject m_Search;
    public GameObject m_Identified;

    BaseCharacter Player;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_Health.value = Player.m_health;

        m_Timer.text = "" + Player.m_timer;
	}
}
