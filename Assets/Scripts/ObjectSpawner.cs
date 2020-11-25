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
	System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
		timeFromSpawn = Time.fixedTime;        
    }

    // Update is called once per frame
    void Update()
    {
		if (timeFromSpawn >= delay)
		{
			Instantiate(platform, new Vector2(transform.position.x,rand.Next(min,max)), transform.rotation);
			timeFromSpawn = 0;
		}
		timeFromSpawn += Time.deltaTime;
    }
}
