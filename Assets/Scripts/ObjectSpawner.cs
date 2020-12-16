using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectSpawner : MonoBehaviour
{
	public GameObject platform;


	static public bool restetTimer = false;
	public float delay;
	public float[] spawnpoints;
	public float initialDelay;
	System.Random rand = new System.Random();
	public int multiplayer = 1;
	Timer timer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
		yield return new WaitForSeconds(initialDelay);
		RegisterTimer();
    }

	void Update()
	{
		if (restetTimer)
		{
			restetTimer = false;
			timer.Cancel();
			RegisterTimer();
		}
	}

	void Spawn()
	{
		for (int i = 0; i < multiplayer; i++)
		{
			Instantiate(platform, new Vector2(transform.position.x, rand.Next(spawnpoints.Length)), transform.rotation);
		}
	}

	void RegisterTimer()
	{
		timer = Timer.Register(delay * GameHandler.gameSpeedModifier, onComplete: () => {
			Spawn();
			RegisterTimer();
		});
	}
}
