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
    Animator CarAnimator;
    public MeshRenderer Alt;
    public MeshRenderer Neu;
    public MeshRenderer Strom;
    public MeshRenderer Druck;
    public MeshRenderer Explo;

    public Material active;
    public Material inactive;
    public Material blocked;

    public VideoClip caro;
    public VideoClip benno;
    public VideoClip timon;
    public VideoClip marleen;
    public VideoClip amelie;
    public VideoClip finn;

    private Vector2 mousePosition;

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

        CarAnimator = GameObject.Find("Auto").GetComponent<Animator>();

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

                if (hit.transform.name == "Target Representation Explo" && !CarAnimator.GetBool("Druck") && !CarAnimator.GetBool("Stromlinien"))
                {
                    Debug.Log(CarAnimator.GetBool("Druck"));
                    Debug.Log(CarAnimator.GetBool("Strom"));
                    CarAnimator.SetBool("Explo", !CarAnimator.GetBool("Explo"));
                    if (CarAnimator.GetBool("Explo"))
                    {
                        Explo.material = active;
                        Druck.material = blocked;
                        Strom.material = blocked;
                    } else
                    {
                        Explo.material = inactive;
                        Strom.material = inactive;
                        Druck.material = inactive;
                    }
                }
                else if (hit.transform.name == "Target Representation Alt")
                {
                    CarAnimator.SetBool("Alt", true);
                    Alt.material = active;
                    Neu.material = inactive;
                }
                else if (hit.transform.name == "Target Representation Neu")
                {
                    CarAnimator.SetBool("Alt", false);
                    Alt.material = inactive;
                    Neu.material = active;
                }
                else if (hit.transform.name == "Target Representation Strom" && !CarAnimator.GetBool("Explo"))
                {
                    CarAnimator.SetBool("Stromlinien", !CarAnimator.GetBool("Stromlinien"));
                    if (CarAnimator.GetBool("Stromlinien"))
                    {
                        Explo.material = blocked;
                        Strom.material = active;
                    }
                    else
                    {
                        if (!CarAnimator.GetBool("Druck"))
                        {
                            Explo.material = inactive;
                        }
                        Strom.material = inactive;
                    }
                }
                else if (hit.transform.name == "Target Representation Druck" && !CarAnimator.GetBool("Explo"))
                {
                    CarAnimator.SetBool("Druck", !CarAnimator.GetBool("Druck"));
                    if (CarAnimator.GetBool("Druck"))
                    {
                        Explo.material = blocked;
                        Druck.material = active;
                    }
                    else
                    {
                        if (!CarAnimator.GetBool("Stromlinien"))
                        {
                            Explo.material = inactive;
                        }
                        Druck.material = inactive;
                    }
                }
                else if (hit.transform.name.Contains("Target Representation"))
                {
                    Names personClicked = getPersonFromClick(hit.transform.name);
                    setVideoSourceFromName(personClicked);

                    Video.SetActive(true);
                    VideoPlayer.frame = 10;
                    VideoPlayer.Play();
                    VideoPlayer.Pause();
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
