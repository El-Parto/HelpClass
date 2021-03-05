using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /* needs jump.  practice double jump (not necessary), and hit detection */


    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float doubleJumpHeight; //this is not necessary but would like to practice


    private float horizontalMove;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float y = Input.GetAxisRaw("Vertical");
        horizontalMove = Input.GetAxis("Horizontal"); //horizontalMove = variable
        // why input? think procedures. what would you need in order for a character to move?
        /*
         How to move a character in a game:
        you need a controller
        what's the controller?
        Keyboard
        What type of keyboard?
        generic english keyboard
        what key's will move  character?
        WADS or Arrow keys. One or the other, but Unity can do both
        can the character jump? Yes.
        What button? Space
        with programming, how will it function?
        Press button, happens.
        A press is usually referred to as an "input" perhaps try looking up "character input for unity"
        Input.GetKeyDown
        Input refers to ... the press of a button
        then it needs an..arguement? what type of input?
        in this case, GetKeyDown. GetKeyDown is when you press a key down.
        Okay so what key are we pressing?
        Space (to jump)
        when you highlight GetKeyDown, it describes itself, it comes with KeyCode...as a flag?
        KeyCode itself needs a tag...flag, so what key?
        Space
        Soo Input.GetKeyDown(KeyCode.Space)
        So what happens now, space is now assigned as an input.
        okay, but it's an input. how does it know when it's doing something?
        if key is pressed, do this.
        If statement.
        so it ends up being
        
        if (Input.GetKeyDown(KeyCode.Space))
        
        then we need to call the variable that we declared earlier.
        that would be " jump "

        now it comes down to assigning jump true or false.

        Well, you jump when space is pressed so true
        then it comes to being;
        
        if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                print("Jump");
            }

         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            jump = true;
        }
    }


    /* why fixed update?
     Easier for physics to handle on a timely basis,it costs a lot to run physic checks every frame
      
     */


    private void FixedUpdate()
    {
        // movement with rigid body.
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        /* rb.velocity = the variable.
         = new vector2 
        not sure what the new is exactly but vector2 refers to the vectors of movement e.g axis of movement new probably 
        means a new instance of vector2
        inside Vector2, we now need to do math.
        math.
        how is it moving? 
        we know that it moves with WADS or < ^ > V but this statement will determine how fast it's moving
        we have our declared variable for that!
        horizontalMove, moveSpeed.
        However! rb.velocity can come into play too!
        velocity.y velocity refers to....velocity. acceleration or rather, how fast it accelerates.
        .y is the direction of the velocity
        so;
        horizontalMove * moveSpeed
        now we need it to affect a direction because we declared Vector2. sooo rb.velocity.y Y direction just so happens to be left and right

        */

        
        if (jump == true)
        {
            rb.AddForce(Vector2.up * jumpHeight);
            jump = false;
        }

        /* */
    }
}
