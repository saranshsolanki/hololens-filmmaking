using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    float speed = 1;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start(){
    	controller = GetComponent<CharacterController> ();
    	anim = GetComponent<Animator>();
    	anim.SetInteger ("condition", 0);
    }

    void Update(){
    	Movement();
    	GetInput();
    }

    void Movement(){
    	if(controller.isGrounded){
    		if(Input.GetKey(KeyCode.W)){

				if(anim.GetBool ("attacking") == true){
					return;
				}

				else if (anim.GetBool ("attacking") == false){
					anim.SetBool ("running", true);
					anim.SetInteger ("condition", 1);

					moveDir = new Vector3(0,0,1);
					moveDir = moveDir*speed;
					moveDir = transform.TransformDirection(moveDir);
				}
			}

			if(Input.GetKeyUp (KeyCode.W)){
				anim.SetBool ("running", false);
				anim.SetInteger ("condition", 0);
				moveDir = new Vector3(0,0,0);
			}
    	}

    	rot = rot + Input.GetAxis("Horizontal")*rotSpeed*Time.deltaTime;
    	transform.eulerAngles = new Vector3(0, rot, 0);


    	moveDir.y = moveDir.y - gravity* Time.deltaTime;
    	controller.Move(moveDir * Time.deltaTime);
    }

    void Attacking(){
    	StartCoroutine(AttackRoutine());
    }

    void GetInput(){
    	if(controller.isGrounded){
    		if(Input.GetMouseButtonDown (0)){
    			if(anim.GetBool("running") == true){
    				anim.SetBool ("running", false);
    				anim.SetInteger ("condition", 0);
    			}
    			if(anim.GetBool("running") == false){
    				Attacking();
    			}
    			
    		}
    	}
    }

    IEnumerator AttackRoutine(){
    	anim.SetBool ("attacking", true);
    	anim.SetInteger ("condition", 2);
    	yield return new WaitForSeconds(1);
    	anim.SetInteger ("condition", 0);
    	anim.SetBool ("attacking", false);
    }

}
