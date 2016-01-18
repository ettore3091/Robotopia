using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace AssemblyCSharp {
	public class EndScript : MonoBehaviour {

		public GameObject gui;


		void Awake() {

			gui = GameObject.Find ("GameGUI");

		}

		void OnTriggerEnter2D (Collider2D other) {
			
			if(other.tag.Equals("Player")) {
				gui.GetComponent<GameGUIScript>().win();
			}
		}
	}
}