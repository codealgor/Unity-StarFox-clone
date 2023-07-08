using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Vector3 velocity;
    [SerializeField] Transform playerShip;

    [SerializeField][Range(0f, 1f)] float speed = 1f;

    void Update(){
        transform.position += velocity * Time.deltaTime;
        
        if(playerShip.position.x < transform.position.x) {
            ApplyForce(new Vector3(-speed, 0, 0));
        } else{
            ApplyForce(new Vector3(speed, 0, 0));
        } 

        if(playerShip.position.y < transform.position.y) {
            ApplyForce(new Vector3(0, -speed, 0));
        } else{
            ApplyForce(new Vector3(0, speed, 0));
        } 
    }

    void ApplyForce(Vector3 force){
        velocity += force;
    }
}
