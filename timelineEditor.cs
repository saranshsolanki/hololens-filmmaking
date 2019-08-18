using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineEditor : MonoBehaviour
{
	float speed = 1;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0;

    Vector3 moveDir = Vector3.zero;
    Vector3 trans = Vector3.zero;


    CharacterController controller;
    Animator anim;

    public AudioSource audioData;



    public GameObject timeline;

    // Start is called before the first frame update
    void Start()
    {
    	
        
    }

    
    void Update()
    {
        getInput();
    }

    void getInput(){

    	PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
    	if(pd != null){
    		
    		//play and pause
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				pd.Play();
			}

			if(Input.GetKeyDown(KeyCode.DownArrow)){
				pd.Pause();
			}


			// change speed

			if(Input.GetKeyDown(KeyCode.RightArrow)){

				if(Time.timeScale < 1.8f){
					Time.timeScale = Time.timeScale + 0.2f;
				}
				Debug.Log("time: " + Time.timeScale);
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){

				if(Time.timeScale > 0.2f){
					Time.timeScale = Time.timeScale - 0.2f;
				}
				Debug.Log("time: " + Time.timeScale);
			}
    		


			// replay
			if(Input.GetKeyDown(KeyCode.Space)){
				pd.Stop	();
				pd.Play();

			}

			// scale
			if(Input.GetKeyDown(KeyCode.W	)){
				trans = transform.localScale;
				trans.x = 2;
				trans.y = 2;
				trans.z = 2;

				transform.localScale = trans; 
			}
			if(Input.GetKeyDown(KeyCode.S	)){
				trans = transform.localScale;
				trans.x = 0.5F;
				trans.y = 0.5F;
				trans.z = 0.5F;

				transform.localScale = trans; 
			}
			if(Input.GetKeyDown(KeyCode.X)){
				trans = transform.localScale;
				trans.x = 1F;
				trans.y = 1F;
				trans.z = 1F;

				transform.localScale = trans; 
			}


			// rotate
			if(Input.GetKeyDown(KeyCode.A)){
				rot = transform.eulerAngles.y - 90;
				transform.rotation = Quaternion.Euler(0, rot, 0);
               
			}

			if(Input.GetKeyDown(KeyCode.D)){
                rot = transform.eulerAngles.y + 90;
                transform.rotation = Quaternion.Euler(0, rot, 0);
			}

    		
    	}

    	
    }
}
