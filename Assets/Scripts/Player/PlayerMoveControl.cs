using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private GatherInput gI;
    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;
    public int additinalJumps = 2;
    private int resetJumpNumber;


    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform wallPoint;
    public bool grounded = true;
    private bool facingWall = false;

    public AudioClip[] footStepClip;
    public AudioClip jumpClip;
    private AudioSource audioSource;

    public ParticleSystem Dust;

    public bool knockBack = false;
    public bool hasControl = true;

    public bool onLadders;
    public float climbSpeed;
    public float climbHorizontalSpeed;

    private float startGravity;

    // Start is called before the first frame update
    void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        resetJumpNumber = additinalJumps;
        startGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        CheckStatus();
        if (!knockBack || hasControl)
        {
            Move();
            JumpPlayer();
        }
        SetAnimatorValues();
    }

    private void Move()
    {
        Flip();
        rb.velocity = new Vector2(speed * gI.valueX, rb.velocity.y);

        if(onLadders)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(climbHorizontalSpeed * gI.valueX, climbSpeed * gI.valueY);
        }

    }

    public void ExitLadders()
    {
        rb.gravityScale = startGravity;
        onLadders = false;
    }

    private void JumpPlayer()
    {
        if(gI.jumpInput)
        {

            if (grounded || onLadders)
            {
                ExitLadders();
                CreateDust();

                rb.velocity = new Vector2(speed * gI.valueX, jumpForce);

                audioSource.clip = jumpClip;
                audioSource.Play();
            }
            else if(additinalJumps > 0)
            {
                ExitLadders();
                CreateDust();

                rb.velocity = new Vector2(speed * gI.valueX, jumpForce);
                additinalJumps -= 1;

                audioSource.clip = jumpClip;
                audioSource.Play();
            }
        }

        gI.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D wallCheckHit = Physics2D.Raycast(wallPoint.position, Vector2.right * direction, rayLength, groundLayer);

        if (wallCheckHit)
        {
            facingWall = true;
        }
        else
        {
            facingWall = false;
        }

        if (leftCheckHit || rightCheckHit)
        {
            grounded = true;
            additinalJumps = resetJumpNumber;
        }
        else
        {
            grounded = false;
        }

        SeeRay(leftCheckHit, rightCheckHit, wallCheckHit);
    }

    private void SeeRay(RaycastHit2D leftCheckHit, RaycastHit2D RightCheckHit, RaycastHit2D wallCheckHit)
    {
        Color color1 = leftCheckHit ? Color.red : Color.green;
        Color color2 = RightCheckHit ? Color.red : Color.green;
        Color color3 = wallCheckHit ? Color.red : Color.green;

        Debug.DrawRay(leftPoint.position, Vector2.down * rayLength, color1);
        Debug.DrawRay(rightPoint.position, Vector2.down * rayLength, color2);
        Debug.DrawRay(wallPoint.position, Vector2.right * direction * rayLength, color3);
    }

    private void Flip()
    {
        if(gI.valueX * direction < 0)
        {
            if(grounded)
            {
                CreateDust();
            }

            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Climb", onLadders);
    }

    public void RandomFootStepAudio()
    {
        audioSource.clip = footStepClip[Random.Range(0, footStepClip.Length)];
        audioSource.Play();
    }

    public void CreateDust()
    {
        Dust.Play();
    }

    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
    {
        int knockBackDirection;
        if (transform.position.x < otherObject.position.x) knockBackDirection = -1;
        else knockBackDirection = 1;

        knockBack = true;
        rb.velocity = Vector2.zero;
        Vector2 theForce = new Vector2(knockBackDirection * forceX, forceY);
        rb.AddForce(theForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockBack = false;
        rb.velocity = Vector2.zero;
    }
}
