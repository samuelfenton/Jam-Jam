using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField]
    private Slider m_Health;
    private Text m_Timer;
    private Image m_Hack;
    private Image m_Threat;
    private Image m_Search;
    private Image m_Identified;


    //the times between alerts anti-virus happen 
    [SerializeField]
    private float m_FirstThreat;
    private float m_SecondThreat;
    private float m_FirstSearch;
    private float m_secondSearch;
    private float m_IdentifiedTimer;


    BaseCharacter Player;

    // Use this for initialization
    void Start ()
    {
        m_Hack.enabled = false;
        m_Threat.enabled = false;
        m_Search.enabled = false;
        m_Identified.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_Health.value = Player.m_health;

        m_Timer.text = "" + Player.m_timer;


        if(Player.m_timer < m_FirstThreat && Player.m_timer > m_SecondThreat)
        {
            m_Threat.enabled = true;
        }

        if (Player.m_timer < m_FirstSearch && Player.m_timer > m_secondSearch)
        {
            m_Search.enabled = true;
        }

        if (Player.m_timer < m_IdentifiedTimer && Player.m_timer > 1)
        {
            m_Identified.enabled = true;
        }

    }
}
