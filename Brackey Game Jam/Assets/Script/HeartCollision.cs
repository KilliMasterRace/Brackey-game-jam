using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    private enum Gender { Male, Female};
    
    [SerializeField] private GameObject HeartPrefab;
    [SerializeField] private Transform EyePosition;
    [SerializeField] private LayerMask TargetMaks;
    [SerializeField] private float Distance = 0.5f;
    [SerializeField] private Gender GenderType;

    private bool _canCollide = false;
    private SpriteRenderer _spriteRender;
    private Vector2 _direction;
    private int _triggerCount = 1;
    private string _genderTag;
    private int count = 0;
    private Movement _refOwnParent, _refColliderParent;

    private RaycastHit2D _hit, _hitTop, _hitBottom;

    private void Start() {
        _refOwnParent = GetComponent<Movement>();
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        var childTransform = transform.GetChild(1).transform;

        if (GenderType == Gender.Male)
            _genderTag = "Male";
        else
            _genderTag = "Female";

        if (_spriteRender.flipX) {
            _direction = Vector2.left;
            childTransform.localPosition = new Vector3(0.6f, 0f, 0f);
            var offSet = this.GetComponent<CapsuleCollider2D>().offset;
            this.GetComponent<CapsuleCollider2D>().offset = new Vector2(Mathf.Abs(offSet.x), offSet.y);
        }
        else {
            _direction = Vector2.right;
            childTransform.localPosition = new Vector3(-0.6f, 0f, 0f);
        }
    }

    private void Update() {
        _hit = Physics2D.Raycast(EyePosition.position, _direction, Distance, TargetMaks);
        _hitTop = Physics2D.Raycast(EyePosition.position, Vector2.up, Distance, TargetMaks);
        _hitBottom = Physics2D.Raycast(EyePosition.position, Vector2.down, Distance, TargetMaks);

        checkTopBottomCollision();
        Debug.DrawRay(EyePosition.position, Vector2.up, Color.blue);
        Debug.DrawRay(EyePosition.position, Vector2.down, Color.blue);

        if (_hit.collider != null) {
            _canCollide = true;
             this.GetComponent<CircleCollider2D>().enabled = false;
             this.GetComponent<CapsuleCollider2D>().enabled = true;
        } 
            
    }

    private void checkTopBottomCollision() {
        if (_hitTop.collider != null) {
            count++;
            setReference();
            _refOwnParent.MoveToTop = false;
            _refColliderParent.MoveToBottom = false; 
        }
        else if (_hitBottom.collider != null) {
             count++;
             setReference();
            _refOwnParent.MoveToBottom = false;
            _refColliderParent.MoveToTop = false;
        } else {
            _refOwnParent.MoveToBottom = true;
            _refOwnParent.MoveToTop = true;

            if (_refColliderParent != null) {
                _refColliderParent.MoveToTop = true;
                _refColliderParent.MoveToBottom = true;
            }
        }
    }

    private void setReference() {
        if (count == 1) {
            if (_hitTop.collider != null) { _refColliderParent = _hitTop.transform.GetComponentInParent<Movement>(); print("ref set"); }
                
            else if (_hitBottom.collider != null) { _refColliderParent = _hitBottom.transform.GetComponentInParent<Movement>(); print("ref set"); }
                
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == _genderTag && _canCollide && _triggerCount == 1) {
            _triggerCount--;
            Instantiate(HeartPrefab, GetComponent<Movement>().getEndPosition(), Quaternion.identity);
            Destroy(other.gameObject, 0.1f);
            Destroy(this.gameObject, 0.1f); 
        }
    }

}
