using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp {
	public class GameGUIScript : MonoBehaviour {

		public Text pages;
		public Text killed;
		public Button stop;
		public Button restart;
		public Canvas stopMenu;
		public Canvas restartMenu;
		public Canvas loserWindow;
		public Canvas winnerWindow;
		public GameObject player;

		void Awake() {

			player = GameObject.FindGameObjectWithTag("Player");

		}

		// Use this for initialization
		void Start () {

			stopMenu.enabled = false;
			restartMenu.enabled = false;
			loserWindow.enabled = false;
			winnerWindow.enabled = false;

		}
		
		// Update is called once per frame
		void Update () {

			pages.text = "x "+GameControl.control.pages;
			killed.text = "Killed: "+GameControl.control.kills;

		}

		public void loss() {

			loserWindow.enabled=true;
			stop.enabled = false;
			restart.enabled = false;
			player.GetComponent<PlayerUserControl>().enabled = false;

		}

		public void win() {

			winnerWindow.enabled=true;
			stop.enabled = false;
			restart.enabled = false;
			player.GetComponent<PlayerUserControl>().enabled = false;

		}

		public void lossPressed() {

			SceneManager.LoadScene(0);

		}

		public void winPressed() {

			SceneManager.LoadScene(3);

		}

		public void stopPressed() {
			
			stopMenu.enabled = true;
			stop.enabled = false;
			restart.enabled = false;
			
		}

		public void stopNoPressed() {
			
			stopMenu.enabled = false;
			stop.enabled = true;
			restart.enabled = true;
			
		}
		
		public void stopYesPressed() {

			SceneManager.LoadScene(0);
			
		}

		public void restartPressed() {

			restartMenu.enabled = true;
			stop.enabled = false;
			restart.enabled = false;

		}

		public void restartNoPressed() {

			restartMenu.enabled = false;
			stop.enabled = true;
			restart.enabled = true;

		}

		public void restartYesPressed(int level) {

			GameControl.control.pages = 0;
			GameControl.control.kills = 0;
			SceneManager.LoadScene(level);

		}
	}
}
