using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
	public float jumpForce;
	public Text text;
	public Animator animator;

	bool freezed = false;
	bool jumped = false;

	public float points = 0;
	public float horizontalSpeed;

	private bool clickable = true;
	private Rigidbody2D rb;
	public GameHandler gameHandler;
	private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.green;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			animator.SetBool("jumped", false);
			spriteRenderer.color = Color.green;
			jumped = false;

		}
		if (collision.gameObject.tag == "Coin")
		{
			gotCoin(collision);
		}
		if (collision.gameObject.tag == "SlowTime")
		{
			gotCoin(collision);
			GameHandler.slowTimeActivated = true;
		}
		if (collision.gameObject.tag == "Immortality")
		{
			gotCoin(collision);
			GameHandler.immortalityActivated = true;
		}

		if (collision.gameObject.tag == "Killer")
		{
			if (!GameHandler.immortalityActivated)
			{
				gameHandler.lives += -1;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		float move = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(move * horizontalSpeed, rb.velocity.y);
		Vector2 movement = new Vector2(move, 0);
		rb.AddForce(movement * horizontalSpeed);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!jumped)
			{
				rb.velocity = (new Vector2(0f, jumpForce));
				jumped = true;
				spriteRenderer.color = Color.white;
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			freezed = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			freezed = false;
		}

		if (freezed)
		{
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			spriteRenderer.color = Color.blue;
		}
		else
		{
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			if (jumped)
			{
				spriteRenderer.color = Color.white;
			}
			else
			{
				spriteRenderer.color = Color.green;
			}
			
		}
	}

	public void gotCoin(Collision2D collision)
	{
		Destroy(collision.gameObject, 0);
		points++;
		animator.SetBool("jumped", false);
		spriteRenderer.color = Color.green;
		jumped = false;
		if (gameHandler.lives <= 3) gameHandler.lives += 1;
	}
}