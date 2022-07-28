using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class MovingObjects : MonoBehaviour
{
//     private GameObject heldObject; 
//     public Transform holdParent; 
//     public float pickUpRange = 15; 
//     public float moveForce = 250; 


//     // Update is called once per frame
//     void Update()
//     {
//         if(Touchscreen.current.primaryTouch.press.isPressed)
//         {
//             if (heldObject != null)
//             {
//                 RaycastHit hit; 
//                 if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, pickUpRange))
//                 {
//                     PickupObject(hit.transform.gameObject); 
//                 }
//             }
//             else
//             {
//                 DropObject(); 
//             }

//         }

//         if (heldObject != null)
//         {
//             MoveObject();
//         }

//     }
//     void MoveObject()
//     {
//         if(Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
//         {
//             Vector3 moveDirection = (holdParent.position - heldObject.transform.position); 
//             heldObject.GetComponent<Rigidbody>().AddForce(moveDirection*moveForce); 
//         }
//     }
//     void PickupObject(GameObject pickObject)
//     {
//         if(pickObject.GetComponent<Rigidbody>())
//         {
//             Rigidbody objRigid = pickObject.GetComponent<Rigidbody>(); 
//             objRigid.useGravity = false;                 
//             objRigid.drag = 10; 
//             objRigid.transform.parent = holdParent; 
//             heldObject = pickObject; 
//         }
//     }
    
//     void DropObject()
//     {
//         Rigidbody objRigid2 = heldObject.GetComponent<Rigidbody>(); 
//         objRigid2.useGravity = true; 
//         objRigid2.drag = 1;

//         heldObject.transform.parent = null; 
//         heldObject = null; 
//     }
}
