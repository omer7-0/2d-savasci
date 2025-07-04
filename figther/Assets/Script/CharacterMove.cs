using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed;
    private Animator anim;

    private Rigidbody2D rb2d;
    float moveHorizontal;

    public bool faceingRight;


    void Start()
    {
        moveSpeed = 5;
        moveHorizontal = Input.GetAxis("Horizontal");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        CharacterAnimation();
    }
    void CharacterMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveHorizontal * moveSpeed, rb2d.linearVelocity.y);

    }

  
    void CharacterAnimation()
    {
        if (moveHorizontal > 0)
        {
            anim.SetBool("isRunning", true);
        }
        if (moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        if (moveHorizontal < 0)
        {
            anim.SetBool("isRunning", true);
        }
        if (faceingRight==false && moveHorizontal>0)
        {
            CharacterFlip();
        }
        if (faceingRight == true && moveHorizontal < 0)
        {
            CharacterFlip();
        }
    }
    void CharacterFlip()
    {
        faceingRight = !faceingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }




}
