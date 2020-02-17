using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMoose : MonoBehaviour
{
    private Vector2 target;
    public GameObject dialogPanel;

    public TalkBotRTalk talkBotRTalk;

    void Start()
    {

       target = transform.position;
        dialogPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Vector2.zero; // sets direction to 0,0

        bool notMoving = ((Vector2)transform.position == target); //if player position is the same as target, notMoving is true
        // player can only move if not moving is true and in the direction of target

        // responding to key press while down, setting speed
        if (Input.GetKeyDown(KeyCode.LeftArrow) && notMoving)
        {
            direction = new Vector2(-1, 0);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && notMoving)
        {
            direction = new Vector2(1, 0);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && notMoving)
        {
            direction = new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && notMoving)
        {
            direction = new Vector2(0, -1);

        }

        if (Input.GetKeyDown("r"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // raycasting
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        //Vector3 d = direction;

        Debug.DrawLine(transform.position, transform.position + (Vector3)direction, Color.yellow);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Dirt")
            {
                target = hit.transform.position;
            } else if (hit.collider.tag == "talkBot")
            {
                talkBotRTalk.pingedMe = true;
            }
        }

        // move
       transform.position = Vector2.Lerp(transform.position, target, 0.5f);// moving something over time, halfway from the position to the target (zeno's paradox)

    }


}
