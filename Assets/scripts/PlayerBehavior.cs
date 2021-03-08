using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    bool hasTriangle = false;
    bool hasDiamond = false;
    bool hasHexagon = false;
    bool hasCross = false;


    //references to components
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    float moveDir = 1;
    bool onFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (onFloor && myBody.velocity.y >= 1)
        {
            onFloor = false;
        }
        CheckKeys();
        HandleMovement();



    }

    void CheckKeys()
    {

        if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            moveDir = -1;

        }

        else
        {
            moveDir = 0;

        }
        

        if (Input.GetKey(KeyCode.Space) && onFloor)
        {
            //myBody.velocity is a reference to my character's rigid body's velocity(speed)
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
        }


    }

    void HandleMovement()
    {
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

        if(collisionInfo.gameObject.tag == "Button")
        {
            GameObject.Find("Game Manager").GetComponent<Manager>().spawnPlatform();
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Tri Check")
        {
            hasTriangle = true;
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Tri Check HUD"));
            Destroy(GameObject.Find("Chest Lock HUD"));


        }

        if(other.tag == "Dia Check")
        {
            hasDiamond = true;
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Dia Check HUD"));
            Destroy(GameObject.Find("Diamond Lock HUD"));
            Debug.Log("get hit idiot");

        }

        if (other.tag == "Hex Check")
        {
            hasHexagon = true;
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Hex Check HUD"));
            Destroy(GameObject.Find("Hexagon Lock HUD"));

            //buff the player's jump
            jumpHeight = 25;


        }

        if(other.tag == "Cross Check")
        {
            hasCross = true;
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Cross Check HUD"));
            Destroy(GameObject.Find("Cross Lock HUD"));

        }
        
        if(other.tag == "Chest Lock" && hasTriangle == true)
        {
            Destroy(GameObject.Find("top"));
            Destroy(GameObject.Find("Chest Lock"));
            
            GameObject.Find("Game Manager").GetComponent<Manager>().spawnCross();


        }

        /*if (other.tag == "Button")
        {
            GameObject.Find("Game Manager").GetComponent<Manager>().spawnPlatform();

        }*/

        if (other.tag == "Door Lock" && hasTriangle == true && hasDiamond == true && hasHexagon == true && hasCross == true)
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Hexagon Lock"));
            Destroy(GameObject.Find("Cross Lock"));
            Destroy(GameObject.Find("Diamond Lock"));
            Destroy(GameObject.Find("Door Block"));

        }

        if(other.tag == "Black Door")
        {
            GameObject.Find("Game Manager").GetComponent<Manager>().spawnText();
            Debug.Log("You're home idiot");
        }
        

    }

}
    






