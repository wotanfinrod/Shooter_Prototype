using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float positionY = 21.8f;
    
    private float playerSpeed;
    private float mouseSensivity;

    void Start()
    {
        playerSpeed = 75f;
        mouseSensivity = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
        MouseControl();
        
    }

    void CharacterMovement()
    {
        float zAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        transform.Translate(xAxis * Time.deltaTime * playerSpeed, 0, zAxis * Time.deltaTime * playerSpeed);
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z); //To freeze Y position        
    }

    void MouseControl()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotPlayer = gameObject.transform.rotation.eulerAngles;
        rotPlayer.x -= mouseY;
        rotPlayer.y += mouseX;

        gameObject.transform.rotation = Quaternion.Euler(rotPlayer);


    }


}
