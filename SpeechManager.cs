using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Playables;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    TextMesh textmesh;
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

    Vector3 trans = Vector3.zero;
    Vector3 transnew = Vector3.zero;

    public GameObject playall;
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;

    
    //public GameObject step4;

    float startTime;
    float endTime;

    public GameObject list;


    public GameObject time;
    public float timer = 0.0f;
    public GameObject gallery;


    public bool pausedBefore;

    // Use this for initialization
    void Start()
    {
        
        textmesh = gameObject.GetComponentInChildren<TextMesh>();
        keywords.Add("play", Play);
        keywords.Add("start", Play);

        keywords.Add("pause", Pause);
        keywords.Add("stop", Pause);

        keywords.Add("restart", Replay);
        keywords.Add("replay", Replay);

        keywords.Add("slow", Slow);
        keywords.Add("normal", NormalSpeed);

        keywords.Add("flip", Rotate);
        keywords.Add("rotate", Rotate);

        keywords.Add("small size", Small);
        keywords.Add("normal size", Normal);

        keywords.Add("steps", SList);

        //keywords.Add("large", Large);




        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

        trans = transform.localScale;
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        Debug.Log("saransh this isiis");
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
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


private void Play()
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();

        

        if (pd != null)
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
            

        }

    }


    private void Pause()
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();
        if (pd != null)
        {
            pd.Pause();
            audioData.Pause();
            pause.SetActive(false);
            pausedBefore = true;


            play.SetActive(true);

        }
    }

    private void Replay()
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();
        if (pd != null)
        {
            pd.Stop();
            pd.initialTime = checkWhichAnimationStart();

            pd.Play();
            play.SetActive(false);
            pause.SetActive(true);
            audioData.Stop();
            audioData.time = checkWhichAnimationStart();
            audioData.Play();

            TextMesh textObject = time.GetComponent<TextMesh>();
            timer = 0.0f;
            textObject.text = "0.0";
            

        }
    }

    private void Slow() {
        AudioSource audioData = GetComponent<AudioSource>();

        Time.timeScale = 0.5f;
        audioData.pitch = 0.5f;

        slowspeed.SetActive(false);
        normalspeed.SetActive(true);

        //if (Time.timeScale >0.2f){
        //     Time.timeScale = Time.timeScale - 0.2f;
        //    audioData.pitch = audioData.pitch - 0.2f;
        //}

        //if(Time.timeScale == 1.0f)
        //{
        //    speedheader.SetActive(false);
        //    speedheader2.SetActive(true);
        //    speedheader2.GetComponent<TextMesh>().text = "Speed: Normal";
        //}
        //else
        //{

        //    speedheader2.SetActive(true);
        //    speedheader2.GetComponent<TextMesh>().text = "Speed: " + Time.timeScale + "x";
        //}
    }

    private void NormalSpeed()
    {
        AudioSource audioData = GetComponent<AudioSource>();

        Time.timeScale = 1f;
        audioData.pitch = 1f;

        slowspeed.SetActive(true);
        normalspeed.SetActive(false);

        //if (Time.timeScale < 1.8f)
        //{
        //    Time.timeScale = Time.timeScale + 0.2f;
        //    audioData.pitch = audioData.pitch + 0.2f;
        //}

        //if (Time.timeScale == 1.0f)
        //{
        //    speedheader.SetActive(false);
        //    speedheader2.SetActive(true);
        //    speedheader2.GetComponent<TextMesh>().text = "Speed: Normal";
        //}
        //else
        //{

        //    speedheader2.SetActive(true);
        //    speedheader2.GetComponent<TextMesh>().text = "Speed: "+ Time.timeScale + "x";

        //}
    }


    private void Normal()
    {

        trans = transform.localScale;
        trans.x = 0.2f;
        trans.y = 0.2f;
        trans.z = 0.2f;

        small.SetActive(true);
        normal.SetActive(false);
        //large.SetActive(true);

        transform.localScale = trans;
    }

    private void Small()
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

    private void Large()
    {

        trans = transform.localScale;
        trans.x = 0.3f;
        trans.y = 0.3f;
        trans.z = 0.3f;

        small.SetActive(true);
        normal.SetActive(true);
        //large.SetActive(false);

        transform.localScale = trans;
    }

    private void SList()
    {
        list.SetActive(true);
    }
    //private void Left()
    //{
    //    PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
    //    AudioSource audioData = GetComponent<AudioSource>();
    //    float rot = 0;

    //    if (pd != null)
    //    {
    //        rot = transform.eulerAngles.y - 90;
    //        transform.rotation = Quaternion.Euler(0, rot, 0);
    //    }
    //}

    //private void Right()
    //{
    //    PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
    //    AudioSource audioData = GetComponent<AudioSource>();
    //    float rot = 0;

    //    if (pd != null)
    //    {
    //        rot = transform.eulerAngles.y + 90;
    //        transform.rotation = Quaternion.Euler(0, rot, 0);
    //    }
    //}

    private void Rotate()
    {
        PlayableDirector pd = timeline.GetComponent<PlayableDirector>();
        AudioSource audioData = GetComponent<AudioSource>();
        float rot = 0;

        if (pd != null)
        {
            rot = transform.eulerAngles.y - 180;
            transform.rotation = Quaternion.Euler(0, rot, 0);
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



}