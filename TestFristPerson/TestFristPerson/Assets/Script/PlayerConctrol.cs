using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConctrol : MonoBehaviour
{

    Character player;
    public GameObject force;
    CameraSport playerCamera;

	void Start ()
    {
        player = GetComponent<Character>();
        playerCamera = FindObjectOfType<CameraSport>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var movement = (v * playerCamera.transform.forward + h * playerCamera.transform.right).normalized;
        movement.y = 0;
        player.Move1(movement);//控制玩家移动


        if (Input.GetKeyDown(KeyCode.G))
        {
            player.GrabCheck();
        }//玩家抓取东西

        if (player.hasObject)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 5;
            player.grabObject.transform.Rotate(transform.up, -rotationX);

        }
      
    }
    
}
