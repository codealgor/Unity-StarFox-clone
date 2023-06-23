using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 50.0f; //Speed of Gameplane

    // Update is called once per frame
    void Update()
    {
        float currentForward = transform.position.z;
        transform.position += -transform.forward * speed * Time.deltaTime;
        if(currentForward <= -100) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -currentForward); 
        }
    }
}
