using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class gazeControlMenu : MonoBehaviour
{
    public static gazeControlMenu Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }


    public GameObject menu;
    public GameObject closedmenu;

    private float timer;

    GestureRecognizer recognizer;

    // Use this for initialization
    void Awake()
    {
        Instance = this;

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

        if (FocusedObject.name == "menuclosed")
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                menu.SetActive(true);
                closedmenu.SetActive(false);
                
                timer = timer - 1.0f;
                Time.timeScale = 1.0f;
            }

            //anim.Play();
        }
        else
        {
            menu.SetActive(false);
            closedmenu.SetActive(true);
        }

    }
}