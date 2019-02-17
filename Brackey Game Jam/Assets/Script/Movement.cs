using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float GridSize = 1f;
    [SerializeField] private float RotationValue = 20f;
    [SerializeField] private GameObject HighLightPrefab;

    private enum Orientataion { Horizontal, Vecrical };

    private Orientataion _gridOrientation;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private Quaternion _toRotate;
    private float _time;
    private float _factor = 1f;
    private bool _isMoving = false;
    private Vector2 _input;
    
    void Update() {
        move();
    }

    // Method-> this method will let the player(heart) to move.
    private void move() {
        // is player(heart) is not moving and player has pressed key (W,A,S,D/Arrows key) only once, 
        // then perform the body of if block.
        if (!_isMoving && checkPressKeyDown()) {

            // get the input from user.
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // check if player is moving on x-axis or y-axis;
            if (Mathf.Abs(_input.x) > Mathf.Abs(_input.y)) {
                _gridOrientation = Orientataion.Horizontal;         // set orientation to horizontal mean player move on x-axis
                _input.y = 0;

                // setting the rotation of player(heart) to rotation value.
                if (_input.x > 0)
                    _toRotate = Quaternion.Euler(new Vector3(0f, 0f, -RotationValue));
                else
                    _toRotate = Quaternion.Euler(new Vector3(0f, 0f, RotationValue));
            }
            else {
                _gridOrientation = Orientataion.Vecrical;        // set orientation to vertical mean player move on y-axis
                _toRotate = Quaternion.identity;                 // moving up-down (y-axis) so no rotation.   
                _input.x = 0;
            }

            if (_input != Vector2.zero) {
                StartCoroutine(moveToGrid(transform.position));
            }
        }
    }

    // This method will return true if player press (W,A,S,D/Arrow keys) only one time.
    // will return false if press another key or hold the above mention keys.
    private bool checkPressKeyDown() {
        return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) 
               || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) 
               || Input.GetKeyDown(KeyCode.LeftArrow);
    }

    // This method will let the player to move to the approciate grid on (x/y) axis.
    IEnumerator moveToGrid(Vector3 position) {
        _isMoving = true;
        _startPosition = position;
        _time = 0f;

        // if player is moving on x-axis, set the next end position on x-axis. else vice versa
        if (_gridOrientation == Orientataion.Horizontal) {
            _endPosition = new Vector2(_startPosition.x + Mathf.Sign(_input.x) * GridSize, _startPosition.y);
        } else {
            _endPosition = new Vector2(_startPosition.x, _startPosition.y + Mathf.Sign(_input.y) * GridSize);
        }

        // instantiate/place the highlighter to next end position.
        var clone = Instantiate(HighLightPrefab, _endPosition, Quaternion.identity) as GameObject;

        while (_time < 1f) {
            _time += Time.deltaTime * (MoveSpeed / GridSize) * _factor;
            transform.position = Vector2.Lerp(_startPosition, _endPosition, _time);
            transform.rotation = Quaternion.Lerp(transform.rotation, _toRotate, _time);
            yield return null;
        }

        Destroy(clone.gameObject);                          // destroy the highligher as player is now on that position.
        transform.eulerAngles = new Vector3(0, 0, 0);       // reset the rotation of player.
        _isMoving = false;                                  // set moving to false. as player is not moving.
        yield return 0;
    }
}
