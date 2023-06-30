using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastView : MonoBehaviour
{
    public static bool lookingAtTable;
    public static Transform hitObjectTransform;
    public static GameObject currentObject;
    public GameObject playerHands;
    public GameObject Player;

    private Rigidbody currentObjectRB;
    private GameObject hitObject;
    private Rigidbody hitObjectRB;

    private bool carryingSmthn = false;

    private Rigidbody thingOnTableRB;

 

    private Outline previousOutline;
    private Outline currentOutline;
    private bool checkpoints;

    //private GameObject currentObjectGO;




    

    void Start()
    {
        playerHands = PlayerHandsManager.instance.playerHands;

    }

    void Update()
    {
        Vector3 feetLevelRay = transform.position - new Vector3(0f, 0.5f, 0f);
        bool footRay = Physics.Raycast(feetLevelRay, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 2.0f);
        if (footRay)
        {

            hitObject = hitInfo.collider.gameObject;
            hitObjectTransform = hitObject.transform;

            if (hitObject.tag == "placeable")
            {
                print("current object " + currentObject );

                lookingAtTable = true;
                TableStatus tableStatus = hitObject.GetComponent<TableStatus>();
                print(hitObject);
                bool isStuffOnTable = tableStatus.IsStuffOnTable();

                //putting on table
                if (!Pickup.pickUpRequest && !Pickup.handsEmpty && isStuffOnTable==false )
                {
                    print("putting on tabel");
                    carryingSmthn = false;
                    isStuffOnTable = true;
                    currentObjectRB.isKinematic = true;
                    Transform plateHolder = hitObject.transform.Find("Idk");
                    currentObjectRB.position = plateHolder.transform.position;
                    Pickup.handsEmpty = true;

                }

                
                //put ingredient on plate thats on table
                if (!Pickup.pickUpRequest && !Pickup.handsEmpty && isStuffOnTable==true && currentObject.tag != "object")
                {
                    print("doing dumb stuff");
                    print("current object when doing dumb stuff" + currentObject);
                   
                    Rigidbody plateOnTable = tableStatus.thingOnTable.GetComponent<Rigidbody>();
                    GameObject plateOnTableGO = plateOnTable.gameObject;
                    PlateStatus plateStatus = plateOnTableGO.GetComponent<PlateStatus>(); 
                    
                        
                    print ("plate on table" + plateOnTableGO);
                    if(plateOnTableGO.tag == "object")
                    {    
                        if(currentObject.tag == "rice"){
                            print("holding rice");
                            plateStatus.rice = true;
                            plateStatus.checkStatus();

                            
                        }
                        
                        else if(currentObject.tag == "seaweed"){
                            print("holding seaweed");
                            plateStatus.seaweed = true;
                            plateStatus.checkStatus();

                        }
                        
                        else if(currentObject.tag == "fish"){
                            print("holding fish");
                            plateStatus.fish = true;
                            plateStatus.checkStatus();


                        }


                        bool plateCheck = plateStatus.isValid();
                        print("plate check value " + plateCheck);
                        print("before plate check");
                        if (plateCheck== true){
                            print("working???");
                            Destroy(currentObject);
                            Pickup.handsEmpty = true;
                            carryingSmthn = false;
                            currentObject = null;
                            currentObjectRB = null;
                            isStuffOnTable = true;


                        }
                        
                    }
                    
                      

                }
                
                //pickup if something on table
                if (Pickup.pickUpRequest && Pickup.handsEmpty && isStuffOnTable == true)
                {
                    print("check 2");
 
                   //print("table status thing" + tableStatus.thingOnTable.GetComponent<Rigidbody>());
                    currentObjectRB = tableStatus.thingOnTable.GetComponent<Rigidbody>();

                    currentObjectRB.isKinematic = true;

                    currentObjectRB.position = playerHands.transform.position;
                    print("wants to pick up from table" + currentObjectRB);
                    currentObjectRB.isKinematic = true;
                    Pickup.handsEmpty = false; 
                    isStuffOnTable = false;
                    
                    carryingSmthn = true;
                    print("this is currentobject rb when picking up from table adjklfaj" + currentObjectRB);



                }


                //if holding plate and food on table
                if (!Pickup.pickUpRequest && !Pickup.handsEmpty && isStuffOnTable==true && currentObject.tag == "object")
                {

                    print("plz mother");
                    
                    PlateStatus plateStatus = currentObject.GetComponent<PlateStatus>(); 
                    
                    Rigidbody foodOnTable = tableStatus.thingOnTable.GetComponent<Rigidbody>();
                    GameObject foodOnTableGO = foodOnTable.gameObject;


                    if(foodOnTableGO.tag == "rice"){
                        print("rice on table");
                        plateStatus.rice = true;
                        plateStatus.checkStatus();

                        
                    }
                    
                    if(foodOnTableGO.tag == "seaweed"){
                        print("seaweed on table");
                        plateStatus.seaweed = true;
                        plateStatus.checkStatus();

                    }
                    
                    if(foodOnTableGO.tag == "fish"){
                        print("fish on table");
                        plateStatus.fish = true;
                        plateStatus.checkStatus();


                    }              


                    bool plateCheck = plateStatus.isValid();
                    if (plateCheck== true){
                        
                        print("working???" + currentObject);
                        Destroy(foodOnTableGO);
                        currentObjectRB.isKinematic = true;
                        Transform plateHolder = hitObject.transform.Find("Idk");
                        currentObjectRB.position = plateHolder.transform.position;
                        //currentObject = null;
                        //currentObjectRB = null;
                        Pickup.handsEmpty = true;
                        carryingSmthn = false;
                        isStuffOnTable = true;



                    }
                    
           
                    
                      

                }

                
                


                    
                
            }

            
            
            
            if (hitObject.tag == "object" || hitObject.tag == "rice"  || hitObject.tag == "seaweed" || hitObject.tag == "fish")
                {
                    
                    //pick up from floor
                    if (Pickup.pickUpRequest && Pickup.handsEmpty)
                    {
                        print("check 3");

                        //print("pick up from floor");
                        hitObjectRB = hitObject.GetComponent<Rigidbody>();
                        hitObjectRB.isKinematic = true;
                        Pickup.handsEmpty = false;
                        hitObjectRB.position = playerHands.transform.position;
                        currentObjectRB = hitObjectRB;
                        currentObject= hitObjectRB.gameObject;

                        carryingSmthn = true;
                      
                          
                            
                    }
                }


        



            
            
            
        currentOutline = hitObjectTransform.GetComponent<Outline>();

        if (currentOutline != null && currentOutline != previousOutline)
        {
            if (previousOutline != null)
            {
                previousOutline.enabled = false;
            }
            currentOutline.enabled = true;
            currentOutline.OutlineColor = Color.gray; // You can customize the outline color if desired
            previousOutline = currentOutline;
        }
        }
        else
        {
            if (previousOutline != null)
            {
                previousOutline.enabled = false;
                previousOutline = null;
            }
        

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        if (carryingSmthn)
        {
            currentObjectRB.position = playerHands.transform.position;
            //drop
            if (Pickup.pickUpRequest == false){
                
                print("check 4");
                currentObjectRB.position = Player.transform.position;
                currentObjectRB.isKinematic = false;
                Pickup.handsEmpty = true;
                carryingSmthn = false;
                Pickup.handsEmpty = true;
                //print("dropping" + currentObjectRB);

                currentObject = null;
                currentObjectRB = null;
                //print("currentobject rb is when dropping" + currentObjectRB);

            }

        
        
        
        }

}
}
    

