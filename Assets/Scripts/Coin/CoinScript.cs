using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private CircleCollider2D coinCollider;



    private void Awake()
    {
        coinCollider = GetComponent<CircleCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagManager.PLAYER_TAG)
        {
            coinCollider.isTrigger = true;
        }
    }
}//class    















