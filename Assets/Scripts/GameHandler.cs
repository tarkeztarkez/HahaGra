using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject restartPanel;
	public int lives = 3;

	public static bool slowTimeActivated;
	public static bool immortalityActivated;
	public static float gameSpeed;

	public float slowTimeDelay;
	float timeFromSlow;
	public float immortalitydelay;
	float timeFromImmortality;
	void Start()
    {
		Time.timeScale = 1f;
		slowTimeActivated = false;
		immortalityActivated = false;
		gameSpeed = 4;
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
		if (slowTimeActivated)
		{
			SlowTimeActivated();
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 0f)
			{
				Time.timeScale = 1f;
			}
			else
			{
				Time.timeScale = 0f;
			}
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


	public void SlowTimeActivated()
	{
		gameSpeed = 2;
		if (timeFromSlow >= slowTimeDelay)
		{
			slowTimeActivated = false;
			gameSpeed = 4;
			timeFromSlow = 0;
		}
		timeFromSlow += Time.deltaTime;
	}

	public void ImmortalityActivated()
	{
		if (timeFromSlow >= immortalitydelay)
		{
			immortalityActivated = false;
			timeFromImmortality = 0;
		}
		timeFromImmortality += Time.deltaTime;
	}
}

