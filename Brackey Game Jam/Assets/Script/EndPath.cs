using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPath : MonoBehaviour {
    public static int CircleCount = 2;
    private int _temp = CircleCount;

    private void OnTriggerEnter2D(Collider2D other) {
        _temp--;
        print("count: " + _temp);
        if (CircleCount == 0)
            print("level clear");
    }


    private void LateUpdate() {
       _temp = CircleCount;
    }
}
