using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
	public GameObject restartPanel;
    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
		if (restartPanel.active)
		{
			if (Input.GetKeyDown(KeyCode.Space)){
				Restart();
			}
		}
    }

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
