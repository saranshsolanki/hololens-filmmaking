using UnityEngine;

public class TapToPlaceParent : MonoBehaviour
{
    bool placing = false;
    Vector3 trans = Vector3.zero;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect(GameObject FocusedObject)
    {
        // On each Select gesture, toggle whether the user is in placing mode.


        if (FocusedObject.name == "maincharacter")
        {
            placing = !placing;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.
        if (placing)
        {

            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;

            Physics.Raycast(headPosition, gazeDirection, out hitInfo);

            // Move the cursor to the point where the raycast hit.
            trans = transform.localScale;

            //if(trans.x == 0.1f)
            //{
            //    this.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y - 0.15f, this.transform.position.z);
            //}
            //else if (trans.x == 0.2f)
            //{

            this.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y - 0.18f, this.transform.position.z);


            //}
            //else if (trans.x == 0.3f)
            //{
            //    this.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y - 0.55f, this.transform.position.z);
            //}



            //this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Quaternion toQuat = Camera.main.transform.localRotation;
            toQuat.x = 0;
            toQuat.z = 0;
            this.transform.rotation = toQuat;


        }

    }
}