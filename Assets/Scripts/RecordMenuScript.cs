using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RecordMenuScript : MonoBehaviour {

	public Text records;
	public InputField input;
	public Button ok;
	public Button back;

	private string[] rec;
	private string[] bestPlayers;
	private float[] bestScores;


	// Use this for initialization
	void Start () {

		bestPlayers = GameControl.control.bestPlayers;
		bestScores = GameControl.control.bestScores;
		rec = new string[bestPlayers.GetLength(0)];
		buildRecords();
		presentRecords();

	}

	void presentRecords () {

		records.text = "";
		for(int i=0; i<rec.GetLength(0); i++) {
			records.text += rec[i];
		}

	}

	private void buildRecords() {

		for(int i=bestPlayers.GetLength(0)-1; i>=0; i--) {
			rec[9-i] = (i>0) ? (" #"+(10-i)+"     "+bestPlayers[i]+"    "+bestScores[i]+"\n") :(" #"+(10-i)+"   "+bestPlayers[i]+"    "+bestScores[i]+"\n");
		}

	}

	public void okPressed() {

		GameControl.control.updateBestScores(input.text);
		buildRecords();
		presentRecords();

	}

	public void backPressed() {

		GameControl.control.updateBestScores("---");
		SceneManager.LoadScene(0);

	}

}
