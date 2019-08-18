using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class playGallery8 : MonoBehaviour
{
    public static playGallery8 Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }
    public GameObject animator;
    Animator anim;
    private float timer = 0.0f;

    //public GameObject menu;

    GestureRecognizer recognizer;

    // Use this for initialization
    void Awake()
    {
        Instance = this;

        anim = animator.GetComponent<Animator>();
        anim.SetBool("gaze", false);
        anim.enabled = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        //GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

       


        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        if (FocusedObject.name == "cylinder8")
        {
            timer += Time.deltaTime;

            if (timer > 1.0f)
            {
                anim.SetBool("gaze", true);
                anim.enabled = true;
                timer = timer - 1.0f;
                Time.timeScale = 1.0f;
            }
            //anim.Play();
        }
        else
        {
            anim.SetBool("gaze", false);
            anim.enabled = false;
        }

    }
}