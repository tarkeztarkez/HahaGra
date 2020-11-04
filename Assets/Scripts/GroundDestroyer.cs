using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
	public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
		Instantiate(ground,new Vector3(17.94f,-5f,-1f), transform.rotation);        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "PostApoGrass" || collision.gameObject.name == "PostApoGrass(Clone)")
		{
			Instantiate(ground, new Vector3(17f, -5f,-1f), transform.rotation);

		}
		Destroy(collision.gameObject,0);
	}
}
