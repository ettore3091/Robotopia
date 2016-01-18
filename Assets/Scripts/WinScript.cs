using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScript : MonoBehaviour {

	public Text score;
	public int pos;
	public float s;
	// Use this for initialization
	void Start () {

		score = score.gameObject.GetComponent<Text>();

		GameControl.control.checkPlayerScore();

	}

	// Update is called once per frame
	void Update () {
		
		pos = GameControl.control.lastPos;
		if(pos > 0) {
			s = GameControl.control.score ;
			score.text = "You're #"+pos+"   Score: "+s;
		}
		else
			score.text = "Score: "+s;
	}


}
