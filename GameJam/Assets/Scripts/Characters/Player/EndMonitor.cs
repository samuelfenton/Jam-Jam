using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMonitor : MonoBehaviour
{
    [SerializeField]
    private float m_playerCloseDistance = 6.0f;

    [SerializeField]
    private Vector3 m_cameraOffset = Vector3.zero;

    private bool m_monitorEnabled = false;

    private Animator m_animator = null; 
	// Use this for initialization
	void Start ()
    {
        m_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < m_playerCloseDistance)
            {
                if (!m_monitorEnabled)
                {
                    m_animator.SetTrigger("DeployMonitor");
                    m_monitorEnabled = true;
                }
                else if (Input.GetAxis("Fire2") != 0.0f)
                {
                    EndGameCamera();
                }

            }
        }
        //loads credits
        //SceneManager.LoadScene(2);
    }

    private void EndGameCamera()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.tag = "Untagged";
        GameManager.instance.EndOfGame(transform.TransformPoint(m_cameraOffset));

        player.GetComponent<BaseCharacter>().OnDeath();
    }
}
