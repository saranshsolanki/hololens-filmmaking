using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.Playables;

public class editControl : MonoBehaviour
{
    public static editControl Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // other variables
    float speed = 1;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0;

    Vector3 moveDir = Vector3.zero;
    Vector3 trans = Vector3.zero;

    CharacterController controller;
    Animator anim;
    public GameObject timeline;

    public AudioSource audioData;

    // Use this for initialization
    void Awake()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
      
        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                Debug.Log("step 1");
                Debug.Log("tapped");
                Instance.SendMessageUpwards("OnSelect", FocusedObject);
                Debug.Log("works");
            }
        };
        recognizer.StartCapturingGestures();

        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();


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

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
            Debug.Log("step 1.5");
        }
    }
}