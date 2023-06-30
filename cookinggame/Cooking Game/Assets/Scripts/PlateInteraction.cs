using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlateInteraction : MonoBehaviour
{
    public static bool inRange = false;
    private GameObject playerHands;
    private Rigidbody objectRB;



    void Start(){
        playerHands = PlayerHandsManager.instance.playerHands;

    }
    
    void FixedUpdate() {
        

        

        
        pickup();
        drop();
   
    }

    private void OnTriggerEnter(Collider other) {
       
        if (other.tag == ("Player"))
        {
            print("can pick up");
            inRange = true;
            
            objectRB = GetComponent<Rigidbody>();
            print(objectRB);
   

        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.tag == ("Player"))
        {
            print("can pick up");
            inRange = false;
            

        }
    }


    private void pickup(){
        
        if (Pickup.pickUp && inRange){
            
           transform.position = playerHands.transform.position;
           objectRB.isKinematic = true;
           Pickup.handsEmpty = false;
           print("picked up");
           
        }

    }


    private void drop(){
        
        if (!(Pickup.handsEmpty)){
            if (RaycastView.lookingAtTable){
                Vector3 plateHolderPosition = RaycastView.hitObjectTransform.position;
                plateHolderPosition += new Vector3(0.2f, 2.0f, -0.6f);
                transform.position = plateHolderPosition;
                objectRB.isKinematic = true;
                Pickup.handsEmpty = true;
                print("dropped on table");
                RaycastView.lookingAtTable = false;
            }
            else{
                objectRB.isKinematic = false;
                Pickup.handsEmpty = true;
                print("dropped");
                RaycastView.lookingAtTable = false;
            }
        }
}
    
}
    
    */

