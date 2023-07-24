using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;

        gameOver = false;

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        canDoubleJump = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        // make the player jump on space bar input
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            canDoubleJump = true;
            
        }

        // let the player double jump
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            canDoubleJump = false;
            Debug.Log("double jump");
        }





    }


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            if (gameOver == false)
            {
                dirtParticle.Play();
            }
        }

        // Make player fall over when collides with obstacle
        if (collision.gameObject.CompareTag("Obstacle")) {
            
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("game over");
        }
    }

}
