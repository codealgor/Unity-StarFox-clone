using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehavior : MonoBehaviour
{
    [Header("Correct Code")]
    [SerializeField] bool isCorrect;
    [SerializeField] GameObject codeBits;
    [SerializeField] Color Good, Bad;
    
    [Space]
    [Header("Other Settings")]
    [SerializeField] float velocityRange = 1f;
    [SerializeField] float destroyTime = 1f;

    Material g_Code, b_Code;

    void Start(){
        g_Code.color = Good;
        b_Code.color = Bad;
    }

    public void SpewCode(float chance){
        GameObject code = Instantiate(codeBits, transform.position, new Quaternion(Random.value, Random.value, Random.value, Random.value)) as GameObject;
        Rigidbody rb_Code = code.GetComponent<Rigidbody>();
        rb_Code.AddForce(transform.up * (Random.Range(-velocityRange, velocityRange)) * Time.deltaTime);
        Destroy(code.gameObject, destroyTime);
    }
}
