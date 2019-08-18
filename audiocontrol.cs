using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class audiocontrol : MonoBehaviour
{
    public GameObject timeline;
    public GameObject play;
    public GameObject pause;

    public GameObject playall;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    float startTime;
    float endTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();

        if(pd.time > checkWhichAnimationEnd())
        {
            pd.Stop();
        }
        pd.stopped += OnPlayableDirectorStopped;

        
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();

        if (pd == aDirector)
        {
            audioData.Stop();
            pause.SetActive(false);
            play.SetActive(true);
        }
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


}
