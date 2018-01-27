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

        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }


    public void Trasmit(GameObject trasmitObject)
    {
        Camera.main.gameObject.GetComponent<PlayerCamera>().SetTrasmit(trasmitObject);
    }

}
