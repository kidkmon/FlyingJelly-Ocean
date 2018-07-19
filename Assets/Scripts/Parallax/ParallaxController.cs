using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

	private Renderer objectRender;
	private Material objectMaterial;
	private float offsetValue;

	public float contOffset;
	public float speed;
	public int ordenInLayer;

	// Use this for initialization
	void Start () {
		objectRender = GetComponent<Renderer>();
		objectRender.sortingOrder = ordenInLayer;
		objectMaterial = objectRender.material;
	}
	
	// Update is called once per frame
	void Update () {
		if(JellyController.gameStarted && !JellyController.isDead){
			offsetValue += contOffset;
			objectMaterial.SetTextureOffset("_MainTex", new Vector2(offsetValue * speed, 0));
		}
	}
}
