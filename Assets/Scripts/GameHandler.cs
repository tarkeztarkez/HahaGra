using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject restartPanel;
	static public int lives = 3;
	public static float gameSpeedModifier;

	static public Timer immortalityTimer;
	static public Timer slowTimeTimer;

	void Start()
    {
		Time.timeScale = 1f;
		gameSpeedModifier = 1f;
    }

    // Update is called once per frame
    void Update()
	{ 
		if(lives == 0)
		{
			Die();
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

	public static void trapTrigerred()
	{
		lives = +-1;
	}

	public void Die()
	{
		restartPanel.SetActive(true);
		Time.timeScale = 0f;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Restart();
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	static public void ActivateSlowTime()
	{
		if (slowTimeTimer.GetTimeRemaining() > 0) slowTimeTimer.Cancel();
		gameSpeedModifier = 0.5f;
		slowTimeTimer = Timer.Register(2f, onComplete:() =>
		{
			gameSpeedModifier = 1f;
		});
	}

	static public void ActivateImmortality()
	{
		immortalityTimer = Timer.Register(10f, onComplete:()=> { });	
	}
}

