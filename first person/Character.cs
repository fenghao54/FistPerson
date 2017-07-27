using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float moveSpeed;
    CharacterController playerBody;
    Vector3 playerVelocity;
    CameraSport playerCamera;

    public Transform grabObject;
    public Transform grabSocket;

    public bool hasObject=false;

	void Start ()
    {
        playerBody = GetComponent<CharacterController>();
        playerCamera = FindObjectOfType<CameraSport>();
    }
	
	
	void Update ()
    {
        playerBody.Move(playerVelocity * Time.deltaTime);
        playerVelocity.y += playerBody.isGrounded ? 0f : Physics.gravity.y * 10f * Time.deltaTime;
	}

  
    public void Move1(Vector3 v)
    {
        transform.position += v * moveSpeed * Time.deltaTime;

    }
    public void GrabCheck()
    {
        if (grabObject != null)
        {
            grabObject.transform.SetParent(null);
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            grabObject = null;
            hasObject = false;
        }
        else
        {
            RaycastHit hit;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red, 5f);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5f))
            {
                if (hit.collider.CompareTag("Box"))
                {
                    grabObject = hit.transform;
                    grabObject.SetParent(grabSocket);
                    grabObject.localPosition = Vector3.zero;
                    grabObject.localRotation = Quaternion.identity;
                    grabObject.GetComponent<Rigidbody>().isKinematic = true;
                    hasObject = true;
                }
            }

        }

    }
   
}
