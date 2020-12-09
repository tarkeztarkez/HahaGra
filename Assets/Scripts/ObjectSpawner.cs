﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectSpawner : MonoBehaviour
{
	public GameObject platform;



	public float delay;
	float timeFromSpawn;
	public float[] spawnpoints;
	public float initialDelay;
	bool running = false;
	System.Random rand = new System.Random();
	public int multiplayer = 1;

    // Start is called before the first frame update
    IEnumerator Start()
    {
		yield return new WaitForSeconds(initialDelay);
		running = true;
		timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
		if (running)
		{
			if(GameHandler.gameSpeed == 4)
			{
				delay = 3;
			}
			if(GameHandler.gameSpeed == 2)
			{
				delay = 6;
			}
			if (timeFromSpawn >= delay)
			{
				for (int i = 0; i < multiplayer; i++)
				{
					Instantiate(platform, new Vector2(transform.position.x, rand.Next(spawnpoints.Length)), transform.rotation);
				}
				timeFromSpawn = 0;
			}
			timeFromSpawn += Time.deltaTime;
		}
    }
}
