using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float musicVolume;
	public float soundsVolume;
	public int diff;
	public int pages;
	public int kills;
	public float score;
	public int lastPos;
	public float cDamage;
	public float fShot;
	public float cScore;
	public string sDiff;
	public float ignorance;
	public string[] bestPlayers = new string[10] ;
	public float[] bestScores = new float[10];

	private string[] difficulties = {"Easy", "Medium", "Hard"};
	private float[] damageCoeffs = {3f, 4f, 5f};
	private float[] shotFrequences = {1f, 1.5f, 2f};
	private int[] scoreCoeffs = {2, 5, 7};

	// Use this for initialization
	void Awake () {
	
		if(control == null) {
			DontDestroyOnLoad(gameObject);
			musicVolume = 10f;
			soundsVolume = 10f;
			diff = 0;
			pages = 0;
			kills = 0;
			score = 0;
			ignorance = 0;
			cDamage = damageCoeffs[diff];
			fShot = shotFrequences[diff];
			cScore = scoreCoeffs[diff];
			sDiff = difficulties[diff];
			for(int i=0; i<bestScores.GetLength(0); i++) {
				bestPlayers[i] = "---";
				bestScores[i] = (i+1)*100;
			}
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}

	}

	public void changeDifficulty(int d) {

		if(diff == d)
			return;

		diff = d;
		cDamage = damageCoeffs[diff];
		fShot = shotFrequences[diff];
		cScore = scoreCoeffs[diff];
		sDiff = difficulties[diff];

	}

	void calculateScore() {

		score = pages*cScore+kills*2f*cScore;

	}

	public void checkPlayerScore() {

		calculateScore();

		int i=0;
		int n=bestScores.GetLength(0);

		while(i<n && bestScores[i]>=score) {
			i++;
		}
		if(i<n)
			lastPos = i+1;

		lastPos = -1;
	}

	public void updateBestScores(string name) {

		if(lastPos>0) {
			string n = name;
			float s = score;

			for(int i=lastPos-1; i<bestScores.GetLength(0); i++) {
				string tname = bestPlayers[i];
				float tscore = bestScores[i];

				bestPlayers[i] = n;
				bestScores[i] = s;

				n=tname;
				s=tscore;
			}
		}
	}
	
}
