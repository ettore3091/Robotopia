using UnityEngine;

namespace AssemblyCSharp
{
    [RequireComponent (typeof(PlayerController))]
	public class PlayerUserControl : MonoBehaviour {

		public float maxSpeed = 10f;
		private PlayerController player;
		bool jump = false;
		Vector3 acc;
		
		void Start () {

			player = GetComponent<PlayerController>();
			
		}
		
		void Update () {

			jump = false;
			float move = 0f;
			if (Application.isMobilePlatform) {
				if (Input.accelerationEventCount > 0) {
					acc = Input.acceleration;
					move = acc.x;
					if (move > -0.1f && move < 0.1f)
						move = 0f;
				}
				if (Input.touchCount > 0) {
					if (Input.GetTouch(0).phase.Equals(TouchPhase.Began))
						jump = true;
				}
			}
			else {
				if (Input.GetKey(KeyCode.RightArrow))
					move = 0.5f;
				else if (Input.GetKey(KeyCode.LeftArrow))
					move = -0.5f;

				if (Input.GetKeyDown(KeyCode.Space))
					jump = true;
			}

			player.Move(move*3, jump);
			
		}
	}
}
