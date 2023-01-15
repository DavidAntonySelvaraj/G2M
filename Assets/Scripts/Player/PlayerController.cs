using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    private float moveVector;

    private Rigidbody2D PlayerRb;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private GameObject footPos;

    private bool isGrounded;

    private int totalCoins=0;

    private int getTotalCoin = 0;
    private void Awake()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        PlayerJump();
        CalculateAgainTheCoins();
        JumpPhysics();
    }

    private void Update()
    {
        moveVector = Input.GetAxis(TagManager.HORIZONTAL_TAG);
        PlayerMove();
        CheckIfGrounded();
        
    }

    void PlayerMove()
    {
        PlayerRb.velocity = new Vector2(moveSpeed * moveVector,PlayerRb.velocity.y);
    }

    void PlayerJump()
    {
        if (totalCoins > 0)
        {
            JumpAndSpecialJump(jumpForce + 2);
        }
        else
        {
            JumpAndSpecialJump(jumpForce);
        }

    }


    void JumpAndSpecialJump(float forceValue)
    {
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, forceValue);

        }
        else
            return;
    }



    void JumpPhysics()
    {
        if (PlayerRb.velocity.y < 0 || PlayerRb.velocity.y>0)
        {
            moveSpeed = 3f;
        }
        if (PlayerRb.velocity.y == 0)
        {
            moveSpeed = 5f;
        }
    }


    void CheckIfGrounded()
    {
        float raycastLength = .3f;
        RaycastHit2D hit = Physics2D.Raycast(footPos.transform.position, -transform.up, raycastLength, 3 << LayerMask.NameToLayer(TagManager.GROUND_TAG));

        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded=false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagManager.COIN_TAG)
        {
            Destroy(collision.gameObject);
            CalculateNoOfCoinsCollected();
            Debug.Log(totalCoins);
        }
    }

    public int CalculateNoOfCoinsCollected()
    {
        totalCoins += 1;
        getTotalCoin = totalCoins;
        return getTotalCoin;
        
    }

    public void CalculateAgainTheCoins()
    {
        if (PlayerRb.velocity.y < -1f && PlayerRb.velocity.y >=-1.06f && totalCoins>0)
        {
            totalCoins= totalCoins -1;
        }
    }
  

    

}//class



















