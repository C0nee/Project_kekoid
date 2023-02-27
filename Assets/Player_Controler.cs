using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controler : MonoBehaviour
{
    Vector2 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.up * movementVector.x));
        // transform.position = new Vector3(transform.position.x + movementVector.x * Time.deltaTime,
        //    0,
        //  transform.position.z + movementVector.y *Time.deltaTime);
        transform.Translate(  Vector3.forward * movementVector.y * Time.deltaTime);
    }
   void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();
        Debug.Log(movementVector.ToString());
    }
}
