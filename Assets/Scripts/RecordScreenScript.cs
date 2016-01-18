using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RecordScreenScript : MonoBehaviour {

	public Button back;
	
	private string[] rec;
	private string[] bestPlayers;
	private float[] bestScores;

	public Text ranks;
	public Text names;
	public Text points;
	
	void Awake() {

		bestPlayers = GameControl.control.bestPlayers;
		bestScores = GameControl.control.bestScores;
	}
	// Use this for initialization
	void Start () {		

		rec = new string[bestPlayers.GetLength(0)];
		//buildRecords();
		presentRecords();	
	}
	
	void presentRecords () {
		
		ranks.text = "";
		names.text = ""	;
		points.text = "";

		for(int i=bestPlayers.GetLength(0)-1; i>=0; i--) {
			ranks.text += "# "+(10-i)+"\n";
			names.text += bestPlayers[i]+"\n";
			points.text += bestScores[i]+"\n";
		}
	}
	
	private void buildRecords() {

		for(int i=bestPlayers.GetLength(0); i>0; i--) {

		}

		for(int i=bestPlayers.GetLength(0)-1; i>=0; i--) {
			rec[9-i] = (i>0) ? (" #"+(10-i)+"     "+bestPlayers[i]+"    "+bestScores[i]+"\n") :(" #"+(10-i)+"   "+bestPlayers[i]+"    "+bestScores[i]+"\n");
		}		
	}
	
	public void backPressed() {

		SceneManager.LoadScene(0);		
	}
}
