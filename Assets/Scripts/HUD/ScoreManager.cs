using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public GameObject finalScore;
	public GameObject bestScore;

	void Start(){
		bestScore.GetComponent<Text>().text = PlayerPrefs.GetInt("BestScore", 0).ToString();
	}

	void Update () {
		if(JellyController.isDead){
			finalScore.GetComponent<Text>().text = score.text;

			if(int.Parse(finalScore.GetComponent<Text>().text.ToString()) > int.Parse(bestScore.GetComponent<Text>().text.ToString())){
				bestScore.GetComponent<Text>().text = finalScore.GetComponent<Text>().text;
			}

			PlayerPrefs.SetInt("BestScore", int.Parse(bestScore.GetComponent<Text>().text));
			bestScore.SetActive(true);
			finalScore.SetActive(true);
		}		
	}
}
