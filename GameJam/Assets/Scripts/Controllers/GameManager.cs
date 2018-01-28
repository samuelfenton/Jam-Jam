using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject m_canvasUI = null;

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

    public void DeathTrasmit(Vector3 position, Quaternion rotation)
    {
        Camera.main.gameObject.GetComponent<PlayerCamera>().OnPlayerDeath(position, rotation);
    }

    public void EndOfGame(Vector3 pos)
    {
        Camera.main.gameObject.GetComponent<PlayerCamera>().OnEndGame(pos);
    }

}
