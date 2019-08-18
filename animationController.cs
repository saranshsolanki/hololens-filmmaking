using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;



public class animationController : MonoBehaviour
{
    public GameObject timeline;
    public GameObject play;
    public GameObject pause;
    public GameObject replay;
    public GameObject speedheader;
    public GameObject speedheader2;

    public GameObject small;
    public GameObject large;
    public GameObject normal;

    Vector3 trans = Vector3.zero;
    Vector3 transnew = Vector3.zero;

    public GameObject playall;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    float startTime;
    float endTime;

    public GameObject steps;



    void OnSelect(GameObject FocusedObject)
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();

        AudioSource audioData = GetComponent<AudioSource>();


        if (pd != null)
        {
            if (FocusedObject.name == "playall")
            {
                pd.Stop();
                audioData.Stop();
                playall.SetActive(false);
                step1.SetActive(true);
                step2.SetActive(true);
                step3.SetActive(true);
                step4.SetActive(true);
                steps.SetActive(false);
                pd.initialTime = checkWhichAnimationStart();


            }
            if (FocusedObject.name == "step1")
            {
                pd.Stop();
                audioData.Stop();
                playall.SetActive(true);
                step1.SetActive(false);
                step2.SetActive(true);
                step3.SetActive(true);
                step4.SetActive(true);
                steps.SetActive(false);

                pd.initialTime = checkWhichAnimationStart();

            }
            if (FocusedObject.name == "step2")
            {
                pd.Stop();
                audioData.Stop();
                
                playall.SetActive(true);
                step1.SetActive(true);
                step2.SetActive(false);
                step3.SetActive(true);
                steps.SetActive(false);
                step4.SetActive(true);
                pd.initialTime = checkWhichAnimationStart();

            }

            if (FocusedObject.name == "step3")
            {
                pd.Stop();
                audioData.Stop();
                
                playall.SetActive(true);
                step1.SetActive(true);
                step2.SetActive(true);
                step3.SetActive(false);
                step4.SetActive(true);
                steps.SetActive(false);
                pd.initialTime = checkWhichAnimationStart();

            }
            if (FocusedObject.name == "step4")
            {
                pd.Stop();
                audioData.Stop();
                playall.SetActive(true);

                step1.SetActive(true);
                step2.SetActive(true);
                step3.SetActive(true);
                step4.SetActive(false);
                steps.SetActive(false);
                pd.initialTime = checkWhichAnimationStart();

            }
        }


        
    }

    public float checkWhichAnimationStart()
    {
        if (!playall.activeSelf)
        {
            startTime = 0;
            endTime = 41.39f;
        }
        else if (!step1.activeSelf)
        {
            startTime = 0;
            endTime = 4.90f;
        }
        else if (!step2.activeSelf)
        {
            startTime = 4.38f;
            endTime = 18.76f;
        }
        else if (!step3.activeSelf)
        {
            startTime = 18.24f;
            endTime = 30.66f;
        }
        else if (!step4.activeSelf)
        {
            startTime = 30.00f;
            endTime = 41.39f;
        }

        return (startTime);
    }

}
