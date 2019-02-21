using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTheSide : MonoBehaviour {

    private enum Gender { Male, Female};
    [SerializeField] private Gender GenderType;

    private string _genderTag;

    private void Start() {
        if (GenderType == Gender.Male) {
            _genderTag = "Detect_Male";
        } else {
            _genderTag = "Detect_Female";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == _genderTag) {
            
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
        if (collision.tag == _genderTag) {
            collision.GetComponentInParent<Movement>().MoveToRight = true;
            collision.GetComponentInParent<Movement>().MoveToLeft = true;

            GetComponent<Movement>().MoveToLeft = true;
            GetComponent<Movement>().MoveToRight = true;
        }
     
    }
}


