using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 5.0f; // Normal hız
    public float boostMultiplier = 2.0f; // Shift'e basıldığında hızı artıracak çarpan

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A ve D tuşları
        float moveVertical = Input.GetAxis("Vertical"); // W ve S tuşları

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, -1* moveVertical);
        Vector3 movement = new Vector3(1* moveVertical, 0.0f, 1*moveHorizontal);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movement *= boostMultiplier; // Shift basılıyken hızı artır
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }
}

