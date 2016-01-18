using UnityEngine;
using System.Collections;

namespace AssemblyCSharp {
	public class EnemyDeathCheck : MonoBehaviour {

		void OnTriggerEnter2D (Collider2D other) {
			
			if(other.tag.Equals("Player")) {
				if(other.transform.position.y > transform.position.y && other.attachedRigidbody.velocity.y < 0){
					gameObject.GetComponentInParent<EnemyController>().isDead();
					GameControl.control.kills++;
				}
			}
		}
	}
}