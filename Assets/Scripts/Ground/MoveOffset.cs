using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {


	private Material currentMaterial;
	private float offset;
	public float speed;
	
	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<SpriteRenderer>().material;	
	}
	
	// Update is called once per frame
	void Update () {
		offset += 0.001f;

		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
	}
}
