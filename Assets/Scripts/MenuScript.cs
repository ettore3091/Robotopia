using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button playButton;
	public Button recordsButton;
	public Button settingsButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {

		quitMenu = quitMenu.GetComponent<Canvas>();
		playButton = playButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button>();
		quitMenu.enabled = false;

	}

	public void exitPressed() {

		quitMenu.enabled = true;
		exitButton.enabled = false;
		playButton.enabled = false;
		recordsButton.enabled = false;
		settingsButton.enabled = false;

	}

	public void noPressed() {
		
		quitMenu.enabled = false;
		exitButton.enabled = true;
		playButton.enabled = true;
		recordsButton.enabled = true;
		settingsButton.enabled = true;

	}

	public void playGame() {
		
		SceneManager.LoadScene(1);
	
	}

	public void recordsPressed() {

		SceneManager.LoadScene(2);

	}

	public void settingsPressed() {

		SceneManager.LoadScene(4);

	}

	public void yesPressed() {

		Application.Quit();

	}
}
