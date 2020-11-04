using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
	public float speed;
	Vector2 offset;

    // Update is called once per frame
    void Update()
    {
		offset = new Vector2(speed * Time.time, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
