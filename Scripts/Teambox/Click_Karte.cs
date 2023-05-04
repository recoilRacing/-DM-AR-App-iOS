using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Click_Karte : MonoBehaviour
{
    GameObject Video;
    GameObject VideoPlayerObject;
    VideoPlayer VideoPlayer;
    GameObject PlayButton;
    Animator VideoAnimator;

    public VideoClip caro;
    public VideoClip benno;
    public VideoClip timon;
    public VideoClip marleen;
    public VideoClip amelie;
    public VideoClip finn;

    public enum Names
    {
        AMELIE, TIMON, CAROLINE, BENNO, MARLEEN, FINN, UNKNOWN
    }

    // Start is called before the first frame update
    void Start()
    {
        VideoPlayerObject = GameObject.Find("VideoPlayer");

        Debug.Log(VideoPlayerObject is not null);


        if (VideoPlayerObject != null)
        {
            VideoPlayer = VideoPlayerObject.GetComponent<VideoPlayer>();
        }

        PlayButton = GameObject.Find("PlayButton");

        Video = GameObject.Find("Video");
        VideoAnimator = Video.GetComponent<Animator>();
        Video.SetActive(false);
    }

    private void handleOnDisapear()
    {
        Video.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);


                if (hit.transform.name.Contains("Target Representation"))
                {
                    Names personClicked = getPersonFromClick(hit.transform.name);
                    setVideoSourceFromName(personClicked);

                    Video.SetActive(true);
                    VideoPlayer.Play();
                    VideoPlayer.Pause();
                    VideoPlayer.frame = 10;

                    VideoAnimator.SetInteger("Teammitglied", (int)personClicked + 1);

                    PlayButton.SetActive(true);
                }
                else if (hit.transform.name == "Video Collider")
                {
                    if (VideoPlayer.isPlaying == false)
                    {
                        VideoPlayer.Play();
                        PlayButton.SetActive(false);
                    }
                    else
                    {
                        VideoPlayer.Pause();
                        PlayButton.SetActive(true);
                    }
                }
                // else if (hit.transform.name == "Auto Container")
                // {
                //     Debug.Log("Auto Container");
                // }
            }
            else
            {
                VideoAnimator.SetInteger("Teammitglied", 0);
                Video.SetActive(false);
            }
        }

    }

    protected Names getPersonFromClick(string elementName)
    {
        switch (elementName.Split(" ")[elementName.Split(" ").Length - 1])
        {
            case "Caroline":
                return Names.CAROLINE; break;
            case "Amelie":
                return Names.AMELIE; break;
            case "Benno":
                return Names.BENNO; break;
            case "Marleen":
                return Names.MARLEEN; break;
            case "Timon":
                return Names.TIMON; break;
            case "Finn":
                return Names.FINN; break;
            default:
                return Names.UNKNOWN;
        }
    }

    private void setVideoSourceFromName(Names name)
    {
        switch (name)
        {
            case Names.CAROLINE:
                VideoPlayer.clip = caro; break;
            case Names.AMELIE:
                VideoPlayer.clip = amelie; break;
            case Names.BENNO:
                VideoPlayer.clip = benno; break;
            case Names.FINN:
                VideoPlayer.clip = finn; break;
            case Names.MARLEEN:
                VideoPlayer.clip = marleen; break;
            case Names.TIMON:
                VideoPlayer.clip = timon; break;
        }
    }
}
