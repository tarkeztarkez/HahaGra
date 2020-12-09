using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject restartPanel;
	public int lives = 3;


	void Start()
    {
		Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		if (restartPanel.active)
		{
			Time.timeScale = 0f;
			if (Input.GetKeyDown(KeyCode.Space)){
				Restart();
			}
		}
		if(lives == 0)
		{
			Die();
		}
    }

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Die()
	{
		restartPanel.SetActive(true);
	}

}
