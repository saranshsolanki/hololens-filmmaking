using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDuration : MonoBehaviour
{
    float timer = 0.0f;

    public GameObject play;
    public GameObject pause;
    public GameObject gallery;

    // Start is called before the first frame update
    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {
        if(!play.activeSelf && (!gallery.activeSelf))
        {
            timer += Time.deltaTime;
            TextMesh textObject = GetComponent<TextMesh>();
            textObject.text = System.Math.Round(timer, 1).ToString();
        }
        

    }
}
