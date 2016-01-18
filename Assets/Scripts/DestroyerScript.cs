using UnityEngine;
using System.Collections;

namespace AssemblyCSharp {
	public class DestroyerScript : MonoBehaviour {

		public GameObject gui;
		
		
		void Awake() {
			
			gui = GameObject.Find ("GameGUI");
			
		}

		void OnTriggerEnter2D (Collider2D other) {
		
			if(other.tag.Equals("Player")) {
				gui.GetComponent<GameGUIScript>().loss();
				other.attachedRigidbody.gravityScale = 0;
				other.attachedRigidbody.velocity=new Vector2(0,0);
			}
			else if(!(other.tag == "Terrain") || !(other.tag== "Enemy")) {
				Destroy(other.gameObject);
			}
		}
	}
}