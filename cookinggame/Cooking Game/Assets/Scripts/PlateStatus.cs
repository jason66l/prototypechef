using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStatus : MonoBehaviour
{
    
    public bool hasRice;
    public bool hasSeaweed;
    public bool hasFish;

    public bool rice;
    public bool seaweed;
    public bool fish;

    public bool valid;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        valid = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void checkStatus()
    {
        print("plate status" + hasRice);


        if (rice == true){    
            
            //empty plate
            if (hasRice == false && hasFish == false && hasSeaweed ==false)
            {
                
                GameObject childObject = gameObject.transform.Find("Rice")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasRice = true;
            }
            
            //plate with only seaweed
            else if (hasRice == false && hasFish == false && hasSeaweed ==true)
            {
                GameObject childObject = gameObject.transform.Find("Rice")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasRice = true;

            }
            
            //plate with only fish
            else if (hasRice == false && hasFish == true && hasSeaweed ==false)
            {
                GameObject childObject = gameObject.transform.Find("Rice")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasRice = true;
            }

            //plate with fish and seaweed
            else if (hasRice == false && hasFish == true && hasSeaweed ==true)
            {
                GameObject childObject = gameObject.transform.Find("Rice")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasRice = true;
            }
            
            else
            {
                
                valid = false;
            }
        }



        else if (seaweed == true){    
            
            //empty plate
            if (hasRice == false && hasFish == false && hasSeaweed ==false)
            {
                
                GameObject childObject = gameObject.transform.Find("Seaweed")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasSeaweed = true;
            }
            
            //plate with only rice
            else if (hasRice == true && hasFish == false && hasSeaweed ==false)
            {
                GameObject childObject = gameObject.transform.Find("Seaweed")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasSeaweed = true;

            }
            
            //plate with only fish
            else if (hasRice == false && hasFish == true && hasSeaweed ==false)
            {
                GameObject childObject = gameObject.transform.Find("Seaweed")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasSeaweed = true;
            }

            //plate with fish and rice
            else if (hasRice == true && hasFish == true && hasSeaweed ==false)
            {
                GameObject childObject = gameObject.transform.Find("Seaweed")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasSeaweed = true;
            }
            
            else
            {
                
                valid = false;
            }
        }


        else if (fish == true){    
            
            //empty plate
            if (hasRice == false && hasFish == false && hasSeaweed ==false)
            {
                
                GameObject childObject = gameObject.transform.Find("Fish")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasFish = true;
            }
            
            //plate with only rice
            else if (hasRice == true && hasFish == false && hasSeaweed ==false)
            {
                GameObject childObject = gameObject.transform.Find("Fish")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasFish = true;

            }
            
            //plate with only seaweed
            else if (hasRice == false && hasFish == false && hasSeaweed ==true)
            {
                GameObject childObject = gameObject.transform.Find("Fish")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasFish = true;
            }

            //plate with seaweed and rice
            else if (hasRice == true && hasFish == false && hasSeaweed ==true)
            {
                GameObject childObject = gameObject.transform.Find("Fish")?.gameObject;
                MeshRenderer childRenderer = childObject.GetComponent<MeshRenderer>();
                childRenderer.enabled = true; 
                valid = true;
                hasFish = true;
                print("has seaweed and rice");
            }
            
            else
            {
                
                valid = false;
            }
        }
}
    
    public bool isValid (){
        print("going through isvalid");
        fish = false;
        seaweed = false;
        rice = false;
        return valid;
    }
    
    
}

