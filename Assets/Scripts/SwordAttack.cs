using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsAttack : MonoBehaviour
{
    // public enum AttackDirection{
    //     left, right
    // }
    
    // public AttackDirection attackDirection;


    Vector2 rightAttackOffset;
    Collider2D swordCollider;

    private void Start(){
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    // public void Attack(){
    //     switch(attackDirection){
    //         case AttackDirection.left:
    //             AttackLeft();
    //             break;
    //         case AttackDirection.right:
    //             AttackRight();
    //             break;
    //     }
    // }

    public void AttackRight(){
        print("Attack right");
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft(){
        print("Attack left");
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack(){  
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        
    }
}
