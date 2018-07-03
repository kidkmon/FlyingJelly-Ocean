using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyMovement : MonoBehaviour {

	public GameObject gameStart;
	public GameObject gameOver;
	public GameObject scoreTxt;

	private Rigidbody2D flappyRg;
	private Animator flappyAnimator;
	public float jumpForce;

	public static bool isDead;
	public static bool gameStarted;

	// Use this for initialization
	void Start () {
		flappyRg = GetComponent<Rigidbody2D>();
		flappyAnimator = GetComponent<Animator>();
		flappyRg.isKinematic = true;
		isDead = false;
		gameStarted = false;
		gameStart.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") && !isDead){
			gameStart.SetActive(false);
			scoreTxt.SetActive(true);
			gameStarted = true;
			flappyRg.isKinematic = false;
			flappyRg.AddForce(new Vector2(0, jumpForce));
		}
		if(Input.GetButtonDown("Jump") && isDead){
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}

	void OnCollisionEnter2D(Collision2D	collision){
		if(!collision.gameObject.CompareTag("Bounds")){
			scoreTxt.SetActive(false);
			gameOver.SetActive(true);
			isDead = true;
			flappyAnimator.SetBool("isDead", true);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		scoreTxt.GetComponent<Text>().text =  (int.Parse(scoreTxt.GetComponent<Text>().text) + 1).ToString();
	}
}
