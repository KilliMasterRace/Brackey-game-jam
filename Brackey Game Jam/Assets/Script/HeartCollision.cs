using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    [SerializeField] private GameObject MaleHeartPrefab;
    [SerializeField] private Transform EyePosition;
    [SerializeField] private LayerMask TargetMaks;
    [SerializeField] private float Distance = 0.5f;
   
    private bool _facingEachOther = false;
    private SpriteRenderer _spriteRender;
    private Vector2 _direction;
    private RaycastHit2D _hit;

    private void Start() {
        _spriteRender = GetComponentInChildren<SpriteRenderer>();

        if (_spriteRender.flipX)
            _direction = Vector2.left;
        else
            _direction = Vector2.right;
    }

    private void Update() {
        _hit = Physics2D.Raycast(EyePosition.position, _direction, Distance, TargetMaks);
        var upDir = Physics2D.Raycast(EyePosition.position, Vector2.up, Distance, TargetMaks);
        var downDir = Physics2D.Raycast(EyePosition.position, Vector2.down, Distance, TargetMaks);

        Debug.DrawRay(EyePosition.position, _direction, Color.blue);
        Debug.DrawRay(EyePosition.position, Vector2.up, Color.blue);
        Debug.DrawRay(EyePosition.position, Vector2.down, Color.blue);

        if (_hit.collider != null || upDir || downDir) {
            _facingEachOther = true;
             this.GetComponent<CircleCollider2D>().enabled = false;
             this.GetComponent<CapsuleCollider2D>().enabled = true;
        } 
            
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Male" && _facingEachOther) {
            Instantiate(MaleHeartPrefab, GetComponent<Movement>().getEndPosition(), Quaternion.identity);
            Destroy(other.gameObject, 0.1f);
            Destroy(this.gameObject, 0.1f); 
        }
    }

}
