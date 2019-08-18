using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SphereCommands : MonoBehaviour
{
    public GameObject timeline;
    public GameObject play;
    public GameObject pause;
    public GameObject replay;
    //public GameObject speedheader;
    //public GameObject speedheader2;

    public GameObject small;
    //public GameObject large;
    public GameObject normal;

    public GameObject slowspeed;
    public GameObject normalspeed;


    public GameObject playall;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    float startTime;
    float endTime;
    public bool pausedBefore;

    public GameObject time;
    public float timer = 0.0f;
    public GameObject gallery;

    public GameObject list;



    Vector3 trans = Vector3.zero;
    Vector3 transnew = Vector3.zero;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect(GameObject FocusedObject)
    {
        Debug.Log("step 2");
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();

        AudioSource audioData = GetComponent<AudioSource>();

        float rot = 0;


        Debug.Log("name:" + FocusedObject.name);
        Debug.Log("timeline:" + timeline);

        // If the sphere has no Rigidbody component, add one to enable physics.
        if (pd != null)
        {
            if (FocusedObject.name == "play")
            {
                Debug.Log("play");
                if (pausedBefore)
                {
                    pd.initialTime = checkWhichAnimationStart();
                    pd.Play();

                    audioData.Play();

                    play.SetActive(false);
                    pause.SetActive(true);
                    replay.SetActive(true);
                }
                else
                {
                    pd.initialTime = checkWhichAnimationStart();
                    pd.Play();
                    audioData.time = checkWhichAnimationStart();
                    audioData.Play();

                    play.SetActive(false);
                    pause.SetActive(true);
                    replay.SetActive(true);
                }

                //pd.initialTime = checkWhichAnimationStart();
                //pd.Play();
                //audioData.time = checkWhichAnimationStart();
                //audioData.Play();

                //play.SetActive(false);
                //pause.SetActive(true);
                //replay.SetActive(true);

            }
            if (FocusedObject.name == "pause")
            {
                Debug.Log("pause");
                pd.Pause();
                audioData.Pause();

                pause.SetActive(false);
                play.SetActive(true);
                pausedBefore = true;

            }


            if (FocusedObject.name == "replay")
            {
                Debug.Log("restart");


                pd.Stop();
                pd.initialTime = checkWhichAnimationStart();

                pd.Play();
                play.SetActive(false);
                pause.SetActive(true);
                audioData.Stop();
                audioData.time = checkWhichAnimationStart();
                audioData.Play();

                TextMesh textObject = time.GetComponent<TextMesh>();
                textObject.text = "0.0";
                timer = 0.0f;


            }
            if (FocusedObject.name == "slow")
            {


                Time.timeScale = 0.5f;
                audioData.pitch = 0.5f;

                slowspeed.SetActive(false);
                normalspeed.SetActive(true);
            }



            if (FocusedObject.name == "normal")
            {


                Time.timeScale = 1f;
                audioData.pitch = 1f;

                slowspeed.SetActive(true);
                normalspeed.SetActive(false);
            }



            if (FocusedObject.name == "rotate")
            {
                rot = transform.eulerAngles.y - 180;
                transform.rotation = Quaternion.Euler(0, rot, 0);
            }

            if (FocusedObject.name == "small")
            {
                trans = transform.localScale;
                trans.x = 0.1f;
                trans.y = 0.1f;
                trans.z = 0.1f;

                small.SetActive(false);
                normal.SetActive(true);
                //large.SetActive(true);

                transform.localScale = trans;
            }

            if (FocusedObject.name == "regular")
            {
                trans = transform.localScale;
                trans.x = 0.2f;
                trans.y = 0.2f;
                trans.z = 0.2f;

                small.SetActive(true);
                normal.SetActive(false);

                transform.localScale = trans;
            }

            if (FocusedObject.name == "steps")
            {

                list.SetActive(true);
                
            }

            //if (FocusedObject.name == "large")
            //{
            //    trans = transform.localScale;
            //    trans.x = 0.3f;
            //    trans.y = 0.3f;
            //    trans.z = 0.3f;

            //    small.SetActive(true);
            //    normal.SetActive(true);
            //    large.SetActive(false);

            //    transform.localScale = trans;
            //}

            //if (FocusedObject.name == "right")
            //{
            //    rot = transform.eulerAngles.y + 90;
            //    transform.rotation = Quaternion.Euler(0, rot, 0);
            //}
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

    public float checkWhichAnimationEnd()
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

        return (endTime);
    }


    void Update()
    {
        if (!play.activeSelf && (!gallery.activeSelf))
        {
            timer += Time.deltaTime;
            TextMesh textObject = GetComponent<TextMesh>();
            textObject.text = System.Math.Round(timer, 1).ToString();
        }


    }



}