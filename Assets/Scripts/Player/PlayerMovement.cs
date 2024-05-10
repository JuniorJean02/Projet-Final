using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    [HideInInspector]
    public float lasthorizonvector;
    public float lastverticvector;  
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector; 
    //refrences
    Rigidbody2D rb;
    public CharacterScriptableObject characterData;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

     void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;    

        if(moveDir.x != 0)
        {
            lasthorizonvector = moveDir.x;
            lastMovedVector = new Vector2(lasthorizonvector, 0f);
        }
        if(moveDir.y !=0)
        {
            lastverticvector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastverticvector);
        }

        if (moveDir.x != 0 &&  moveDir.y != 0) 
        {
            lastMovedVector = new Vector2(lasthorizonvector, lastverticvector);
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x *characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);
        
    }
}
