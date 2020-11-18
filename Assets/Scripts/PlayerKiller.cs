using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
	public GameObject RestartMenu;

    // Start is called before the first frame update
    void Start()
    {
			
    }

	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collision)
	{
		//Check for a match with the specific tag on any GameObject that collides with your GameObject
		if (collision.gameObject.tag == "Killer")								
		{
			RestartMenu.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
