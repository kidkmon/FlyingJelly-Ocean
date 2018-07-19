using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JellyController : MonoBehaviour {

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
		if(!gameStarted && Input.GetButtonDown("Jump")){
			gameStart.SetActive(false);
			scoreTxt.SetActive(true);
			gameStarted = true;
			flappyRg.isKinematic = false;
			flappyAnimator.SetBool("isBegin", false);	
		}

		if(gameStarted){
			if(Input.GetButtonDown("Jump") && !isDead){
				flappyAnimator.SetBool("isJumping", true);
				flappyRg.AddForce(new Vector2(0, jumpForce));
				GetComponents<AudioSource>()[0].Play();
			}

			if(Input.GetButtonUp("Jump") && !isDead){
				flappyAnimator.SetBool("isJumping", false);
			}

			if(Input.GetButtonDown("Jump") && isDead){
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D	collision){
		if(!collision.gameObject.CompareTag("Bounds") && !isDead){
			scoreTxt.SetActive(false);
			gameOver.SetActive(true);
			isDead = true;
			flappyAnimator.SetBool("isDead", true);
			GetComponents<AudioSource>()[1].Play();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		scoreTxt.GetComponent<Text>().text =  (int.Parse(scoreTxt.GetComponent<Text>().text) + 1).ToString();
		GetComponents<AudioSource>()[2].Play();
	}
}
