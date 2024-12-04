using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PLayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;

    private void Awake(){
        playerControls = new PLayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        AdjustPLayerFacingDirection();
        Move();
    }

    private void PlayerInput(){
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPLayerFacingDirection(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerSreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < playerSreenPoint.x){
            mySpriteRender.flipX = true;
        }
        else{
            mySpriteRender.flipX = false;
        }
    }
    
}
