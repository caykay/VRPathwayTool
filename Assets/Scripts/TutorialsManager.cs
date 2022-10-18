using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialsManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    public GameObject graph;
    public VideoPlayer videoPlayer;
    public GameObject leftHandRayInteractor;
    public GameObject rightHandRayInterator;

    private int videoClipIndex;

    private void Awake()
    {
        //videoPlayer = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    // Play first tutorial upon startup
    void Start()
    {
        videoPlayer.clip = videoClips[0];
    }

    // hide graph and enable ray hand interactors whenver tutorials are open
    private void OnEnable()
    {
        graph.GetComponent<VRige.VRige_Graph_Creator>().hideNodes(true);
        leftHandRayInteractor.SetActive(true);
        rightHandRayInterator.SetActive(true);
    }

    private void OnDisable()
    {
        graph.GetComponent<VRige.VRige_Graph_Creator>().hideNodes(false);
        leftHandRayInteractor.SetActive(false);
        rightHandRayInterator.SetActive(false);
    }

    // Show tutorial video and info for a given index, graph is disabled.
    public void PlayVideo(int index) {
        this.gameObject.SetActive(true);
        videoClipIndex = index;
        videoPlayer.clip = videoClips[videoClipIndex];
    }

    public void PlayNext()
    {
        videoClipIndex++;
        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        //videoPlayer.clip = videoClips[videoClipIndex];
        PlayVideo(videoClipIndex);
    }

    public void PlayPrev()
    {
        videoClipIndex--;
        if (videoClipIndex >= videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }

        //videoPlayer.clip = videoClips[videoClipIndex];
        PlayVideo(videoClipIndex);
    }

    public void CloseTutorial()
    {
        videoPlayer.Stop();
        this.gameObject.SetActive(false);
        
    }
}