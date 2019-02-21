using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTheSide : MonoBehaviour {

  
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Detect_Male" || collision.tag == "Detect_Female") {
            
            var direction = collision.transform.position - transform.position;
 
            if (direction.x < 0) {
                collision.GetComponentInParent<Movement>().MoveToRight = false;
                GetComponent<Movement>().MoveToLeft = false;
            } else {
                collision.GetComponentInParent<Movement>().MoveToLeft = false;
                GetComponent<Movement>().MoveToRight = false;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Detect_Male" || collision.tag == "Detect_Female") {
            collision.GetComponentInParent<Movement>().MoveToRight = true;
            collision.GetComponentInParent<Movement>().MoveToLeft = true;

            GetComponent<Movement>().MoveToLeft = true;
            GetComponent<Movement>().MoveToRight = true;
        }
     
    }
}


