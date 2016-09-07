using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 5f;
	Vector2 playerMovement;
	bool facingRight = true;

	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		playerMovement.Set (h, 0f);
		playerMovement = playerMovement.normalized * movementSpeed * Time.deltaTime;
		if (playerMovement.x < 0 && facingRight) {
			facingRight = false;
			Flip();
		}
		if (playerMovement.x > 0 && !facingRight) {
			facingRight = true;
			Flip();
		}
		GetComponent<Rigidbody2D>().MovePosition ((Vector2)transform.position + playerMovement);
	}

	void Flip()
	{
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

//	void OnTriggerEnter
}
