using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonitourEndGame : BaseCharacter
{
    bool Player = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
         
        if(Player)
        //loads credits
        SceneManager.LoadScene(2);
    }
}
