using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void Trasmit(GameObject trasmitObject)
    {
        Camera.main.gameObject.GetComponent<PlayerCamera>().SetTrasmit(trasmitObject);
    }

}
