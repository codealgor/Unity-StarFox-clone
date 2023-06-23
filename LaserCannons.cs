using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannons : MonoBehaviour
{
    [Header("Cannon Positions")]
    [SerializeField] Transform cannon;
    [SerializeField] Vector3 globalMousePos;

    [Space]

    [Header("Stats")]
    [SerializeField] LayerMask damagable;
    [SerializeField] GameObject laserObj;
    [SerializeField] Material laser_C;
    [SerializeField] bool firing;
    [SerializeField] int ammo;
    [SerializeField] float cooldown, damage;
    [SerializeField] float laserSpeed;

    [Space]

    [Header("Color")]
    [SerializeField] CustomShip laserColor;

    void Awake(){
        laserColor = GetComponent<CustomShip>();
    }

    void Start(){
        switch(laserColor.c_Pallet){
            case CustomShip.CustomPallet.RandomColors:
                Debug.Log("Random Colors");
                break;
            default:
                laser_C.color = new Color(1f, 0.5f, 0f);
                break;
        }
    }

    void FixedUpdate(){
        if(firing) ShootBullet();
    }

    void ShootBullet(){
        RaycastHit hit;
        

        
    }

    void Cooldown(){

    }
}
