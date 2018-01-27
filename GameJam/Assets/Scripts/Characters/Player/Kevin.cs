using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin : MonoBehaviour
{
    private string m_password = "kevin";
    private char[] m_passwordArray = new char[5];

    [SerializeField]
    private GameObject m_easterEgg = null;

    private int m_passwordIndex = 0;
	// Use this for initialization
	void Start ()
    {
        m_passwordArray = m_password.ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == m_passwordArray[m_passwordIndex])
                m_passwordIndex++;
            else
                m_passwordIndex = 0;
            if (m_passwordIndex == 5)
            {
                m_easterEgg.SetActive(true);
                Destroy(this);
            }
        }
    }
}
