using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectSpawner : MonoBehaviour
{
	public GameObject platform;

	public float delay;
	float timeFromSpawn;
	public int min;
	public int max;
	public float initialDelay;
	bool running = false;
	System.Random rand = new System.Random();
	public int multiplayer = 1;

    // Start is called before the first frame update
    void Start()
    {
		running = false;
		StartCoroutine(waiter());
		timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
		if (running)
		{
			if (timeFromSpawn >= delay)
			{
				for (int i = 0; i < multiplayer; i++)
				{
					Instantiate(platform, new Vector2(transform.position.x, rand.Next(min, max)), transform.rotation);
				}
				timeFromSpawn = 0;
			}
			timeFromSpawn += Time.deltaTime;
		}
    }

	IEnumerator waiter()
	{
		yield return new WaitForSeconds(initialDelay);
		running = true;
	}
}
