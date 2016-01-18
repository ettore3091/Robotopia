using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {	

		[SerializeField] private Transform m_Respawn;

        public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
        public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
        public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
        public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
        public float xOffset = 2f;
		public float yOffset = 2f;
		public float minY = 0f;
		public float maxY = 3f;

        private Transform m_Player; // Reference to the player's transform.


        private void Awake()
        {
            // Setting up the reference.
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

		private void Start() {

			transform.position = new Vector3(m_Respawn.position.x+xOffset, m_Respawn.position.y+yOffset, m_Respawn.position.z-10);

		}


        private bool CheckXMargin()
        {
            // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
			return Mathf.Abs(transform.position.x - m_Player.position.x+xOffset) > xMargin;
        }


        private bool CheckYMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
			return Mathf.Abs(transform.position.y - m_Player.position.y+yOffset) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
			float targetX = transform.position.x+xOffset;
			float targetY = transform.position.y+yOffset;

            // If the player has moved beyond the x margin...
            if (CheckXMargin())
            {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
				targetX = Mathf.Lerp(transform.position.x, m_Player.position.x+xOffset, xSmooth*Time.deltaTime);
            }

            // If the player has moved beyond the y margin...
            if (CheckYMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
				targetY = Mathf.Lerp(transform.position.y, m_Player.position.y+yOffset, ySmooth*Time.deltaTime);
            }

            // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
            //targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minY, maxY);

            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
