﻿/* 
 * 
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Defence defence_player;

    [SerializeField]
    private float velocity_punishment = 0.5f;
    public float velocidad = 0.3f;
    bool lastMovementWasLeft;
    bool notMoving;
    public int characterSpriteSize()
    {
        // Player looks right is positive, left is negative
        if (transform.localScale.x > 0) return 1;
        else return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    void leftMovement(Vector3 characterScale)
    {
        animator.SetInteger("Movement_x", 1);
        animator.SetInteger("Movement_y", 0);

        if (!lastMovementWasLeft || notMoving)
        {
            if (!lastMovementWasLeft) { characterScale.x = -characterScale.x; }
            notMoving = false;
        }
        lastMovementWasLeft = true;
    }
    void rightMovement(Vector3 characterScale) {

        animator.SetInteger("Movement_x", 1);
        animator.SetInteger("Movement_y", 0);
        if (lastMovementWasLeft || notMoving)
        {

            if (lastMovementWasLeft) { characterScale.x = -characterScale.x; }
            notMoving = false;

        }
        lastMovementWasLeft = false;

    }
    void upMovement()
    {
        animator.SetInteger("Movement_y", 1);
        animator.SetInteger("Movement_x", 0);

    }
    void noneMovement()
    {
        notMoving = true;
        animator.SetInteger("Movement_x", 0);
        animator.SetInteger("Movement_y", 0);

    }
    Vector3 SetCorrectAnimation(float movementX, float movementY, Vector3 characterScale)
    {
        
        if (movementX < 0)
        {
            leftMovement(characterScale);
        }
        else if (movementX > 0)
        { 
            rightMovement(characterScale);
        }
        else
        {
            if(movementY > 0)
            {
                upMovement();
            }
            else {
                noneMovement();
            }
           
        }
        return characterScale;
    }

void move(float movementX,float  movementY) {

        if (!defence_player.defenseActivated())
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocity_punishment * velocidad * Time.deltaTime);
            defence_player.updateDefenceSize();
        }
}

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

   
        Vector3 characterScale = transform.localScale;
        transform.localScale = SetCorrectAnimation( movementX, movementY, characterScale);
        move(movementX,movementY);
    }


    
    
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Defence defence_player;

    [SerializeField]
    private float velocity_punishment = 0.5f;
    public float velocidad = 0.3f;
    bool lastMovementWasLeft;
    bool notMoving;
    public int characterSpriteSize()
    {
        // Player looks right is positive, left is negative
        if (transform.localScale.x > 0) return 1;
        else return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        bool lastMovementWasLeft = false;
        bool notMoving = true;
    }

    Vector3 SetCorrectAnimation(float movementX, float movementY, Vector3 characterScale)
    {
        if (movementX < 0)
        {
            if (!lastMovementWasLeft || notMoving)
            {

                if (!lastMovementWasLeft) { characterScale.x = -characterScale.x; }
                notMoving = false;
                animator.SetInteger("Movement_x", 1);

            }
            lastMovementWasLeft = true;
        }
        else if (movementX > 0)
        {
            if (lastMovementWasLeft || notMoving)
            {

                if (lastMovementWasLeft) { characterScale.x = -characterScale.x; }
                notMoving = false;
                animator.SetInteger("Movement_x", 1);

            }
            lastMovementWasLeft = false;
        }
        else
        {
            notMoving = true;
            animator.SetInteger("Movement_x", 0);
        }
        return characterScale;
    }

    void move(float movementX, float movementY)
    {

        if (!defence_player.defenseActivated())
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(movementX, movementY, 0) * velocity_punishment * velocidad * Time.deltaTime);
            defence_player.updateDefenceSize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");


        Vector3 characterScale = transform.localScale;
        transform.localScale = SetCorrectAnimation(movementX, movementY, characterScale);
        move(movementX, movementY);
    }




}