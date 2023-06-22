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
        Flag, // Location based
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
            case CustomPallet.Flag: //Changes the color of the ship to the 3 primary colors of the user's current flag
                paintables[0].color = Color.red;
                paintables[1].color = Color.white;
                paintables[2].color = Color.blue;
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
        if(randomColors) paintables[index].color = new Color(Random.value, Random.value, Random.value);
        else paintables[index].color = shipPaint[index];
    }
}
