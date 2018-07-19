using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyController : MonoBehaviour {

	public GameObject gameStart;
	public GameObject gameOver;
	public GameObject restartButton;
	public GameObject scoreTxt;

	private Rigidbody2D jellyRg;
	private Animator jellyAnimator;
	public float jumpForce;

	public static bool isDead;
	public static bool gameStarted;

	// Use this for initialization
	void Start () {
		jellyRg = GetComponent<Rigidbody2D>();
		jellyAnimator = GetComponent<Animator>();
		jellyRg.isKinematic = true;
		isDead = false;
		gameStarted = false;
		gameStart.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameStarted && Input.GetMouseButtonDown(0)){
			gameStart.SetActive(false);
			scoreTxt.SetActive(true);
			gameStarted = true;
			jellyRg.isKinematic = false;
			jellyAnimator.SetBool("isBegin", false);	
		}

		if(gameStarted){
			if(Input.GetMouseButtonDown(0) && !isDead){
				jellyAnimator.SetBool("isJumping", true);
				jellyRg.AddForce(new Vector2(0, jumpForce));
				GetComponents<AudioSource>()[0].Play();
			}

			if(Input.GetMouseButtonUp(0) && !isDead){
				jellyAnimator.SetBool("isJumping", false);
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D	collision){
		if(!collision.gameObject.CompareTag("Bounds") && !isDead){
			StartCoroutine("JellyDead");
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		scoreTxt.GetComponent<Text>().text =  (int.Parse(scoreTxt.GetComponent<Text>().text) + 1).ToString();
		GetComponents<AudioSource>()[2].Play();
	}

	IEnumerator JellyDead(){
		scoreTxt.SetActive(false);
		gameOver.SetActive(true);
		restartButton.SetActive(true);
		isDead = true;
		jellyAnimator.SetBool("isDead", true);
		GetComponents<AudioSource>()[1].Play();
		yield return new WaitForSeconds(0.25f);
		gameObject.SetActive(false);
	}

}
