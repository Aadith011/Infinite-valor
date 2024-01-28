using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead01 : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    [SerializeField]
    private Rigidbody2D charBody;
    void Awake(){
        charBody = GetComponent<Rigidbody2D>();

        speed = 5;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        charBody.velocity = new Vector2(speed, charBody.velocity.y);
    }
}// class Undead-01
