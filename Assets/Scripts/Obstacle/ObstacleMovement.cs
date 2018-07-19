using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	public Rigidbody2D obstacleRb;
	public float obstacleSpeed;

	// Update is called once per frame
	void Update () {
		if(!JellyController.isDead){
			obstacleRb.velocity = new Vector2(obstacleSpeed * Time.deltaTime, obstacleRb.velocity.y);
		}
		else{
			obstacleRb.velocity = Vector2.zero;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Bounds")){
			Destroy(gameObject);
		}
	}

}
