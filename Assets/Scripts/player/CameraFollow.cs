using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;   // value needs to be changed for new map
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }// Start

    // Update is called once per frame
    void Update()
    {

    }// Update
    void LateUpdate(){
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x < minX){   // check if camera goes out of bounds
            tempPos.x = minX;
        }else if(tempPos.x > maxX){
            tempPos.x = maxX;
        }
        transform.position = tempPos;
    }// LateUpdate

}// CameraFollow
