using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;

    [SerializeField]
    private GameObject m_mainCamera = null;
    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        m_mainCamera = Camera.main.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Trasmit(GameObject trasmitObject)
    {
        m_mainCamera.GetComponent<PlayerCamera>().SetTrasmit(trasmitObject);
    }

}
