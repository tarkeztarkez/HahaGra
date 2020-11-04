using System.Collections;
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
		if (Input.GetMouseButtonDown(0))
		{
			if (!jumped)
			{
				rb.velocity = new Vector2(0f,jumpForce);
				jumped = true;
			}
		}
		if (Input.GetMouseButton(0))
		{
			rb.AddForce(new Vector2(0f,liftingForce*Time.deltaTime));
		}
    }
}