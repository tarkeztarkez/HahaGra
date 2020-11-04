﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
	public float jumpForce;
	public float liftingForce;
	public Text text;

	public float points = 0;

	public bool jumped;
	public float maxSpeed;

	private Rigidbody2D rb;
	public float startingY;

    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		startingY = transform.position.y + 0.03F;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			jumped = false;
		}
		if (collision.gameObject.tag == "Coin")
		{
			jumped = false;
			Destroy(collision.gameObject, 0);
			points++;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(points.ToString() != text.text)
		{
			text.text = points.ToString();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!jumped)
			{
				rb.velocity = new Vector2(0f,jumpForce);
				jumped = true;
			}
		}

		float move = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
		Vector2 movement = new Vector2(move, 0);
		rb.AddForce(movement * maxSpeed);

		if (Input.GetMouseButton(0))
		{
			rb.AddForce(new Vector2(0f,liftingForce*Time.deltaTime));
		}
    }
}