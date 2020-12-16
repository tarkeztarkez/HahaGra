using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
	public GameObject[] powerUps;



	public float delay;
	public float[] spawnpoints;
	public float initialDelay;
	System.Random rand = new System.Random();
	public int multiplayer = 1;

	// Start is called before the first frame update
	IEnumerator Start()
	{
		yield return new WaitForSeconds(initialDelay);
		RegisterTimer();
	}

	// Update is called once per frame
	void Spawn()
	{
		for (int i = 0; i < multiplayer; i++)
		{
			Instantiate(powerUps[rand.Next(powerUps.Length)], new Vector2(transform.position.x, rand.Next(spawnpoints.Length)), transform.rotation);
		}
	}

	void RegisterTimer()
	{
		Timer.Register(delay * GameHandler.gameSpeedModifier, onComplete: () => {
			Spawn();
			RegisterTimer();
		});
	}
}
