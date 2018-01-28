using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private float m_timeToHack = 30.0f;

    [SerializeField]
    private GameObject m_quarantineMessage = null;

    [SerializeField]
    private GameObject m_damageMessage = null;

    [SerializeField]
    private Image m_hackingSlider = null;

    //Fading
    GameObject fadingObject;
    float timeBetweenFades;
    float fadeInAmount;

    // Update is called once per frame
    void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player!= null)
        {
            float hackingPercent = player.GetComponent<BaseCharacter>().m_timer / m_timeToHack;

            if (hackingPercent >= 1)
            {
                player.GetComponent<BaseCharacter>().OnDeath();

                fadingObject = m_quarantineMessage;
                timeBetweenFades = 0.05f;
                fadeInAmount = 0.02f;

                Invoke("FadeInText", timeBetweenFades);
            }
            m_hackingSlider.fillAmount = hackingPercent;
        }
    }

    private void FadeInText()
    {
        Color colour = fadingObject.GetComponent<Text>().color;
        colour.a += fadeInAmount;
        fadingObject.GetComponent<Text>().color = colour;

        if (colour.a <1)
        {
            Invoke("FadeInText", timeBetweenFades);
        }
    }

    public void PlayDamageMessage()
    {
        fadingObject = m_damageMessage;
        timeBetweenFades = 0.05f;
        fadeInAmount = 0.02f;

        Invoke("FadeInText", timeBetweenFades);
    }
}
