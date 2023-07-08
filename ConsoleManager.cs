using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    StartScreen ss;
    [Header("References")]
    [SerializeField] Text consoleWrite;

    [SerializeField] string[] functions = new string[3];
    [SerializeField] string[] classes = new string[6];

    void Start(){
        //Functions
        functions[0] = "def func1():\n \tdmg = 10\n \thealth = 3\n \tfireRate = 2\n\n";
        functions[1] = "def func2():\n \tdmg = 5\n \thealth = 7\n \tfireRate = 1\n\n";
        functions[2] = "def func3():\n \tdmg = 3\n \thealth = 2\n \tfireRate = 0.5\n\n";

        //Classes
        classes[0] = "class Class1:\n\t" + functions[0];
        classes[1] = "class Class2:\n\t" + functions[1];
        classes[2] = "class Class3:\n\t" + functions[2];
        classes[3] = "class Class4:\n\t" + functions[0] + "\t" + functions[1];
        classes[4] = "class Class4:\n\t" + functions[2] + "\t" + functions[1];
        classes[5] = "class Class4:\n\t" + functions[0] + "\t" + functions[2];
        int funcIndex = Random.Range(0, functions.Length);
        int classIndex = Random.Range(0, classes.Length);

        switch(ss.m_DifState){
            case StartScreen.Difficulty.F:
                consoleWrite.text = functions[funcIndex];
                Debug.Log(functions[funcIndex]);
                break;
            case StartScreen.Difficulty.FP:
                consoleWrite.text = functions[funcIndex];
                break;
            case StartScreen.Difficulty.C:
                Debug.Log("Working");
                consoleWrite.text = classes[classIndex / 2];
                break;
            case StartScreen.Difficulty.CP:
                consoleWrite.text = classes[classIndex];
                break;
            case StartScreen.Difficulty.N:
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
