using UnityEngine;
using System.Collections;

public class PageScript : MonoBehaviour {

	private Transform player;

	void Awake() {

		player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	/*
	void FixedUpdate() {

		if (player.position.x > transform.position.x+1)
			Destroy(gameObject);

	}
	*/
	void OnTriggerEnter2D (Collider2D other) {
		
		if(other.tag.Equals("Player")) {
			GameControl.control.pages++;
			Destroy(gameObject);
		}
	}
}
