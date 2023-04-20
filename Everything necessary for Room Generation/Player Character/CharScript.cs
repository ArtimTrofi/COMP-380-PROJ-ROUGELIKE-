using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharScript : MonoBehaviour
{
    public float moveSpeed = 50F;

    public Rigidbody2D charRigidbody;

    public Animator charAnim;


    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponent<Animator>();
        charRigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        move();
    }



    private void move()
    {
        charRigidbody.velocity = new Vector2(0, 0); //resets velocity to 0 if none of the keys are held down

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            charRigidbody.velocity = new Vector2(-1 * moveSpeed, charRigidbody.velocity.y);
            charAnim.Play("LeftRun");
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            charRigidbody.velocity = new Vector2(1 * moveSpeed, charRigidbody.velocity.y);
            charAnim.Play("LeftRun");
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            charRigidbody.velocity = new Vector2(charRigidbody.velocity.x, 1 * moveSpeed);
            if (charRigidbody.velocity.x == 0)
                charAnim.Play("UpwardRun");
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            charRigidbody.velocity = new Vector2(charRigidbody.velocity.x, -1 * moveSpeed);
            if (charRigidbody.velocity.x == 0)
                charAnim.Play("DownwardRun");
        }

        //normalize diagonal movement (so it's not faster than cardinal movement)
        if (charRigidbody.velocity.magnitude > moveSpeed)  //should maybe also check if hitting a wall, to avoid dragging/reducing speed when moving diagonally against a wall.
        {
            charRigidbody.velocity = charRigidbody.velocity.normalized * moveSpeed; //approx root2 of x and y velocities
        }
        //Debug.Log("char velocity: " + charRigidbody.velocity);

        if (charRigidbody.velocity.magnitude == 0)
        {
            charAnim.Play("Idle");
        }
    }

    public void doingSomething()
    {
        Debug.Log("moved: " + transform.position);
    }
}
