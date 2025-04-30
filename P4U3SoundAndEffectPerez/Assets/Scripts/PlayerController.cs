using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtParticale;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public bool doubleJumpUsed = false;
    public float doubleJumpForce;

    // Start iscalled before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticale.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            
        }
        else if (Input.GetKeyDown(KeyCode.Space)&&!isOnGround&&!doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_jump",3,0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
            doubleJumpUsed = false;
            dirtParticale.Play();
        }else if (collision.gameObject.CompareTag("Obstical"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionPartical.Play();
            dirtParticale.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }

}
