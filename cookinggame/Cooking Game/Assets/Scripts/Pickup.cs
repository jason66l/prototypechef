using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    
    public static bool pickUpRequest; 
    public static bool handsEmpty;


    void Start(){

        handsEmpty = true;
        pickUpRequest = false;
    }
    
    void Update()
    {
        //wants to pick up
        if (handsEmpty == true && Input.GetKeyDown("space"))
        {
            print("space presed");
            pickUpRequest = true;
            
            
        }

        //wants to drop
        if (handsEmpty == false && Input.GetKeyDown("space")){
            
            pickUpRequest = false;
            
        }
    }
}
