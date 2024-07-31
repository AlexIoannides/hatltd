using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarPlayer : MonoBehaviour
{
    public float moveSpeed = 6.0f; //The f at the end of the number says it is a floating-point number
    public float rotateSpeed = 0.65f;
    public int stars = 0; // An integer whole number
    public TMP_Text starText;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starText.SetText("Stars: " + stars);
        if (stars < 3)
        {
            timeText.SetText("Time: " + Mathf.Round(Time.time));
        }
        
        float speed = Input.GetAxis("Vertical");

        //Set animations
        Animator anim = gameObject.GetComponent<Animator>();

        if (speed != 0) // Is moving
        {
            anim.SetBool("forward", true);
        }
        else // Idle
        {
            anim.SetBool("forward", false);
        }

        // Rotate around y-axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Forward is the forward direction for this character
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        //You need the Character Controller so you can use SimpleMove
        CharacterController controller = GetComponent<CharacterController>();
        controller.SimpleMove(forward * speed * moveSpeed);
       
    }
}
