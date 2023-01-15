using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 tempPos;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<Transform>();
    }

    private void Update()
    {
        Follow();
    }
    void Follow()
    {
        tempPos = transform.position;
        tempPos.x = playerTransform.position.x + 1f;
        tempPos.y = playerTransform.position.y;
        transform.position = tempPos;
    }
}//class
