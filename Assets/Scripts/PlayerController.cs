using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text countText;
    // Note: Variables must be initialized in order for them to be recognized. 

    public float speed; // empty now, will be used to store speed data of the object based on user input

    public Text WinText;

    private Rigidbody rb; // Data of the Rigidbody type, empty now, will be used to store Rigidbody data

    private int count;



    void Start()  // runs on startup
    {
        rb = GetComponent<Rigidbody>(); // finds and attached the reference to RigidBody that we've enabled in the Inspector Window

        count = 0;
        SetCountText();
        WinText.text = "";
    }

    void FixedUpdate()  // is continually updated??
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // Receives movement info from the character in the horizontal direction
        float moveVertical = Input.GetAxis("Vertical"); // Likewise, with vertical

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Applies a vector force in the direction of x, y, z... y is z because we don't want to move "up" at all!

        rb.AddForce(movement * speed); // Adds a force to the rb object
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You win!";
        }
    }

}