using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public GameObject[] objs;
	private Transform player;

	private int furthestSector=1;

	private int[] platforms = {2, 3, 4, 5};

	private int[] times = {0, 0, 0};
	private float[] levels = {-2f, 0.5f, 3f};
	private int lastLevel;
	private bool isPreviousSectorEmpty = false;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").transform;
		lastLevel = 0;

	}

	void FixedUpdate () {

		float distance = transform.position.x - player.position.x;
		if(distance < 25.5f) {
			for(int i=0; i<3; i++) {
				if(times[i]>0) {
					times[i]--;
				}
			}
			Spawn ();
			transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
			furthestSector++;
		}

	}

	void Spawn() {

		int r, l=lastLevel;
		bool spawn = false;

		if(isPreviousSectorEmpty) {
			r = Random.Range(0,4);
			if(lastLevel>0)
				l = lastLevel-1+Random.Range(0,2);
			else
				l=0;
			spawn = true;
			isPreviousSectorEmpty = false;
		}
		else {
			r=Random.Range(0,5);
			if(r<4) {
				l = Random.Range(0, 3);
				if(l==lastLevel){
					if(times[l] == 0) {
						l=lastLevel;
						spawn = true;
						isPreviousSectorEmpty = false;
					}
				}
				else {
					spawn = true;
					isPreviousSectorEmpty = false;
				}
			}
		}

		if(spawn) {
			times[l] = platforms[r];
			Instantiate(objs[r], new Vector3(furthestSector*2.5f+28f, levels[l], 0f), Quaternion.identity);
			isPreviousSectorEmpty=false;
		}

	}
}
