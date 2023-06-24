using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaserCannons : MonoBehaviour
{
    [SerializeField] shootKey = KeyCode.Space; //Shooting key
    [SerializeField] GameObject laserObj; //The laser prefab
    [Header("Settings")]
    [SerializeField] float cooldown = 1.0f; //Time before shooting again
    [SerializeField] float dmg, distance; //The damage of lasers and the 
    [SerializeField] bool firing, joystick; //The firing input and joystick controls

    void Start(){
        
    }

    void FixedUpdate(){
        //Ternary for how the firing is going to work
        firing = joystick ? Input.GetButtonDown("Fire1") : Input.GetKeyDown(shootKey);
        if(firing) Shoot();
    }

    //The functionality for how the shooting will work
    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, distance) { //Ray based laser shot
            Instantiate(laserObj);
            laserObj.GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
