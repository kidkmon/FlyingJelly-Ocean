using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour {

	private Rigidbody2D flappyRg;
	public float jumpForce;

	public static bool isDead;

	// Use this for initialization
	void Start () {
		flappyRg = GetComponent<Rigidbody2D>();
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && !isDead){
			flappyRg.AddForce(new Vector2(0, jumpForce));
		}
	}

	void OnCollisionEnter2D(Collision2D	collision){
		isDead = true;
	}
}
