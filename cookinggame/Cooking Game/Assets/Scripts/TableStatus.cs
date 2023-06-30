using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStatus : MonoBehaviour
{
    public bool stuffOnTable = false; // Flag to indicate if the plate is on the table
    public GameObject thingOnTable;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "object"|| other.gameObject.tag == "rice"  || other.gameObject.tag == "seaweed"|| other.gameObject.tag == "fish")        
        {
            stuffOnTable = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "object"|| other.gameObject.tag == "rice"  || other.gameObject.tag == "seaweed"|| other.gameObject.tag == "fish")       
        {
            stuffOnTable = false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "object"|| other.gameObject.tag == "rice"  || other.gameObject.tag == "seaweed"|| other.gameObject.tag == "fish")
        {
            stuffOnTable = true;
            print("something is on the table" + other.gameObject + gameObject);
            thingOnTable = other.gameObject;
            print(stuffOnTable);
        }
    }

    public bool IsStuffOnTable()
    {
        return stuffOnTable;
    }

    
}

