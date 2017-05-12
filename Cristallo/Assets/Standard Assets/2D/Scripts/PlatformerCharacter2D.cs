using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        CrystalManager cm;
        private int jumpcount;
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = 2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .001f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        public bool canDoubleJump = true;
		public float greenSize = 0.5f;
		private bool isSprinting = false;
        private AudioSource walk;
        private AudioSource jumping;
        private AudioSource landing;
        private AudioSource emptypower;
        private bool small = false;
        private Vector3 defaultScale;

        private void Awake() 
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            cm = GameObject.FindGameObjectWithTag("CrystalManager").GetComponent<CrystalManager>();
            AudioSource[] audios = GetComponents<AudioSource>();
            walk = audios[0];
            jumping = audios[1];
            landing = audios[2];
            emptypower = audios[3];
            defaultScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        }


        private void FixedUpdate()
        {
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
       
        }
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && m_Grounded)
            {
				isSprinting = true;
                m_MaxSpeed = m_MaxSpeed * 1.5f;

            }
			if (Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
            {
					m_MaxSpeed = m_MaxSpeed / 1.5f;
				    isSprinting = false;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                if (m_Grounded)
                {
                    walk.Play();
                }
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                walk.Stop();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(PlayerStats.HasPower == false && cm.NearCrystal == false)
                {
                    emptypower.Play();
                }
                if (cm.NearCrystal == true)
                {
                    if (cm.red == true)
                    {
                        PlayerStats.HasRed = true;
                        print("got double jump");
                        cm.red = false;
                    }
                    else if(cm.yellow == true)
                    {
                        PlayerStats.HasYellow = true;
                        cm.yellow = false;
                    }
                    else if(cm.orange == true)
                    {
                        PlayerStats.HasOrange = true;
                        cm.orange = false;
                    }
                    else if(cm.green == true)
                    {
                        PlayerStats.HasGreen = true;
                        print("Got Shrink");
                        cm.green = false;
                    }
                    else if(cm.blue == true)
                    {
                        PlayerStats.HasBlue = true;
                        cm.blue = false;
                    }
                    else if(cm.purple == true)
                    {
                        PlayerStats.HasPurple = true;
                        cm.purple = false;
                    }
                   
                    cm.hasPower = true;
                }
                if(cm.NearCrystal == false && PlayerStats.HasGreen && small == false)
                {
                    transform.localScale -= new Vector3(transform.localScale.x * greenSize, transform.localScale.y * greenSize, transform.localScale.z * greenSize);
                    small = true;
                    PlayerStats.IsSmall = true;
                }
                else if (cm.NearCrystal == false && PlayerStats.HasGreen && small == true)
                {
                    transform.Translate(0f, 1f, 0f);
                    transform.localScale = defaultScale;
                    if (!m_FacingRight)
                    {
                        transform.localScale += new Vector3(-transform.localScale.x * 2, 0f, 0f);
                    }
                    small = false;
                    PlayerStats.IsSmall = false;
                }
            }
            if(m_Grounded && PlayerStats.HasRed)
            {
                jumpcount = 1;
            }
        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            //if (!crouch && m_Anim.GetBool("Crouch"))
            //{
                // If the character has a ceiling preventing them from standing up, keep them crouching
            //    if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
           //     {
           //         crouch = true;
           //     }
          //  }

            // Set whether or not the character is crouching in the animator
         //   m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                
                jumping.Play();
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                if (PlayerStats.HasRed)
                {
                    canDoubleJump = true;
                }
                jumpcount--;

            }
            else if (jump && canDoubleJump && PlayerStats.HasRed == true)
            {
                jumping.Play();
                canDoubleJump = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                jumpcount--;
            }
            else if (jump && !m_Grounded && jumpcount > 0)
            {
                
                jumping.Play();
                jumpcount--;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
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
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "MovingPlatform")
            {
                gameObject.transform.parent = col.gameObject.transform;
            }
        }
        public void OnTriggerExit2D(Collider2D col)
        {
            if(col.gameObject.tag == "MovingPlatform")
            {
                gameObject.transform.parent = null;
            }
        }
    }
}
