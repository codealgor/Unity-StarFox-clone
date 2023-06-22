using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipMove : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float movementSpeed = 10.0f; //movement speed of Player
    public int inverse = 1; //Determine Inverse Controls 
    public float rotationSpeed = 50.0f;    //Rotation Speed of Player  

    [Space] 

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem trail;
    [SerializeField] ParticleSystem circle, barrel, stars;

    [Space]

    [Header("Interactable Layers")]
    [SerializeField] LayerMask consumableLayers;
    [SerializeField] LayerMask dangerousLayers;

    [Space]

    [Header("Other")]
    [SerializeField] Rigidbody rb;

    Tricks _tricks;     //Reference to Tricks 
    AudioSource _hit;   //Audio Source for Hit sound

    //The initialization code
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _hit = GetComponent<AudioSource>();
        _tricks = FindObjectOfType<Tricks>();
    }

    void Update()
    {
        MoveShip();
    }

    // The code to move the ship using the WASD keys
    void MoveShip(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Where the ship is supposed to move
        Vector3 direction = new Vector3(horizontal, (inverse) * vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, (inverse) * vertical, 1.0f);

        //Changing position and rotation to match the input
        transform.position += direction * movementSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * rotationSpeed);
    }

    // The collision detection system
    // Currently in charge of the health system
    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;
        if (_tricks.inTrick == false)
        {
            _tricks.inTrick = true;
            if (otherGO.tag == "Enemy" || otherGO.layer == dangerousLayers)
            {
                _hit.Play();
                Destroy(otherGO);
                HealthManager.Instance.ChangeHealth(-10.0f);
            }
            else if (otherGO.tag == "Terrain")
            {
                _hit.Play();
                HealthManager.Instance.ChangeHealth(-5.0f);
            }
            Invoke("TurnOnCollider", 2.0f);
        }
    }

    // Gives invincibility frames when hit for 2 seconds
    void TurnOnCollider()
    {
        _tricks.inTrick = false;
    }
}
