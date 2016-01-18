using System;
using UnityEngine;



namespace AssemblyCSharp
{
	public class EnemyController : MonoBehaviour
	{	
		public const float RANGE = 5;
		public float initialDir = 1f;
		public bool isAlive = true;

		[SerializeField] private float m_MaxSpeed = 4f;            // The fastest the player can travel in the x axis.
		[SerializeField] private LayerMask m_WhatIsGround;         // A mask determining what is ground to the character

		private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		private bool m_Grounded;            // Whether or not the player is grounded.
		private Animator m_Anim;            // Reference to the player's animator component.
		private Rigidbody2D m_Rigidbody2D;
		private bool m_FacingRight = true;  // For determining which way the player is currently facing.

		private Transform player;
		private float initialPosition;
		private float minX;
		private float maxX;

		private bool returning = false;

		private float move = 1f;

		void Awake()
		{
			// Setting up references.
			player = GameObject.FindGameObjectWithTag("Player").transform;
			m_GroundCheck = transform.Find("GroundCheck");
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();


		}

		void Start() {
			
			initialPosition = transform.position.x;				
			minX = initialPosition-RANGE;
			maxX = initialPosition+RANGE;
			move *= initialDir;
			if(move < 0)
				Flip ();

		}
		
		
		private void FixedUpdate()
		{

			if(isAlive) {
			m_Grounded = false;
			
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
					m_Grounded = true;
			}
			m_Anim.SetBool("Ground", m_Grounded);
			
			// Set the vertical animation
			m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

			float dist = transform.position.x - player.position.x;

			if(!returning) {
				if(Mathf.Abs(dist) > RANGE){
					patrol ();
				}
				else {
					follow (dist);
				}
			}
			else 
				comeBack();
			}
			else {
				Destroy(gameObject, 4.0f);
			}

		}

		private void patrol() {

			if(transform.position.x < minX+0.3*RANGE && !m_FacingRight){
				move = 1f;
				Flip();
			}
			else if(transform.position.x > maxX-0.3*RANGE && m_FacingRight) {
				move = -1f;
				Flip ();
			}

			m_Anim.SetFloat("Speed", Mathf.Abs(move));
			m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);

		}

		private void follow(float dist) {

			if(transform.position.x < minX) {
				move = 1f;
				returning = true;
			}
			else if(transform.position.x > maxX) {
				move = -1f;
				returning = true;
			}

				if(!returning) {
					if(transform.position.x==Mathf.Max(transform.position.x, player.position.x) && m_FacingRight)
						move = -1f;				
					else if(player.position.x==Mathf.Max(transform.position.x, player.position.x) && !m_FacingRight)
						move = 1f;
				}


			if((move < 0 && m_FacingRight) || (move>0 && !m_FacingRight))
				Flip ();

			m_Anim.SetFloat("Speed", Mathf.Abs(move*m_MaxSpeed));
			m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

		}
		  
		private void comeBack() {

			if((move>0 && transform.position.x >= minX+0.3*RANGE) || move<0 && transform.position.x <=maxX-0.3*RANGE)
				returning = false;

		}
		
		
		private void Flip()
		{
			// Switch the way the player is labelled as facing.
			m_FacingRight = !m_FacingRight;
			
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

		public void isDead() {

			isAlive = false;
			m_Anim.SetTrigger("Dead");
			gameObject.layer=11;

		}

	}
}
