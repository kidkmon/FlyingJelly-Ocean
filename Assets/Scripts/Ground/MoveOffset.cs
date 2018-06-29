using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {

	private Renderer _renderer;

	public float scrollSpeed = 0.5F;

	void Start() {
        _renderer = GetComponent<Renderer>();
    }
    void Update() {
        if(!FlappyMovement.isDead){
            float offset = Time.time * scrollSpeed;
            _renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
