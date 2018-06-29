using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

	public float rateSpawn;

	public GameObject[] obstaclesPrefab;
	
	// Use this for initialization
	void Start () {
		StartCoroutine("spawnObstacles");
	}
	
	IEnumerator spawnObstacles(){
		yield return new WaitForSeconds(rateSpawn);
		int randomNumber = Random.Range(0, obstaclesPrefab.Length);
		if(!FlappyMovement.isDead){
			Instantiate(obstaclesPrefab[randomNumber], new Vector3(transform.position.x, obstaclesPrefab[randomNumber].transform.position.y, transform.position.z), transform.rotation);
			StartCoroutine("spawnObstacles");
		}
	}

}
