using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField]
    private Slider m_Health;
    [SerializeField]
    private Slider m_Timer;
    [SerializeField]
    private Image m_Hack;
    [SerializeField]
    private Image m_Threat;
    [SerializeField]
    private Image m_Search;
     [SerializeField]
    private Image m_Identified;


    //the times between alerts anti-virus happen 
    [SerializeField]
    private float m_FirstThreat;
    [SerializeField]
    private float m_SecondThreat;
    [SerializeField]
    private float m_FirstSearch;
    [SerializeField]
    private float m_secondSearch;
    [SerializeField]
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

        m_Timer.value = Player.m_timer;

        m_Timer.maxValue = 30;

       

    }
}
