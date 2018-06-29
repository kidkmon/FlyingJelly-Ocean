using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	public Rigidbody2D obstacleRb;
	public float obstacleSpeed;

	// Update is called once per frame
	void Update () {
		obstacleRb.velocity = new Vector2(obstacleSpeed * Time.deltaTime, obstacleRb.velocity.y);
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
