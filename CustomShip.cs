using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomShip : MonoBehaviour
{
    // Gets each part of the ship and changes the materials
    [Header("Customizables")]
    [SerializeField] Color[] shipPaint = new Color[3];
    [SerializeField] Material[] paintables = new Material[3];
    
    // A list of preset designs that change the colors
    public enum CustomPallet{
        RandomColors,
        Monotone
    }

    public CustomPallet c_Pallet;

    void Start()
    {
        int index = 0;
        switch(c_Pallet){
            case CustomPallet.RandomColors: //Randomizes the color of each part of the ship
                foreach(var paints in paintables){
                    RandomizeColorsAt(index);
                    index++;
                }
                break;
            case CustomPallet.Monotone: //Makes the ship greyscale
                paintables[0].color = Color.grey;
                paintables[1].color = Color.black;
                paintables[2].color = Color.white;
                break;
            default: //If the ship pallet doesn't work as intended
                Debug.Log("Error");
                break;
        }
    }

    void RandomizeColorsAt(int index){
        paintables[index].color = new Color(Random.value, Random.value, Random.value);
    }
}
