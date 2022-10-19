using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercises : MonoBehaviour
{
    //public or private reference
    //Data type(strings, bools, float, int)
    //every variable needs a name
    //optional -- a value

    //variable for name
    //variable for age
    //variable location

    public string myName = "Christopher";
    public int myAge = 36;
    public string myLocation = "Boston";



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My name is: " + myName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
