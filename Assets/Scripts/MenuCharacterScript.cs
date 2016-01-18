using UnityEngine;
using System.Collections;

public class MenuCharacterScript : MonoBehaviour {

	public const float RANGE = 5;
	
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	
	private Transform player;
	private float initialPosition;
	private float minX;
	private float maxX;
	
	private float move = -1f;
	
	void Awake()
	{
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();	
			
	}
	
	void Start() {
		
		initialPosition = transform.position.x;				
		minX = initialPosition-RANGE;
		maxX = initialPosition+RANGE;
		
	}
	
	
	private void FixedUpdate()
	{

		if(transform.position.x < minX+0.3*RANGE && m_FacingRight){
			move = 1f;
			Flip();
		}
		else if(transform.position.x > maxX-0.3*RANGE && !m_FacingRight) {
			move = -1f;
			Flip ();
		}
		
		m_Anim.SetFloat("Speed", Mathf.Abs(move));
		m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);

		
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
}
