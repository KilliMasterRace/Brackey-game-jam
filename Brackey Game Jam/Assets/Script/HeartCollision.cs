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
    private RaycastHit2D _hit;
    private int _triggerCount = 1;
    private string _genderTag;

    private void Start() {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();
        var childTransform = transform.GetChild(1).transform;

        if (GenderType == Gender.Male)
            _genderTag = "Male";
        else
            _genderTag = "Female";

        if (_spriteRender.flipX) {
            _direction = Vector2.left;
            childTransform.localPosition = new Vector3(0.6f, 0f, 0f);
        } else {
            _direction = Vector2.right;
            childTransform.localPosition = new Vector3(-0.6f, 0f, 0f);
        }
    }

    private void Update() {
        _hit = Physics2D.Raycast(EyePosition.position, _direction, Distance, TargetMaks);
        var upDir = Physics2D.Raycast(EyePosition.position, Vector2.up, Distance, TargetMaks);
        var downDir = Physics2D.Raycast(EyePosition.position, Vector2.down, Distance, TargetMaks);


        if (_hit.collider != null || upDir || downDir) {
            _canCollide = true;
             this.GetComponent<CircleCollider2D>().enabled = false;
             this.GetComponent<CapsuleCollider2D>().enabled = true;
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
