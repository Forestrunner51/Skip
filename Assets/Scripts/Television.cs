using UnityEngine;
using UnityEngine.Video;

public class Television : MonoBehaviour
{

    VideoPlayer videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying == false) 
        {
            videoPlayer.Play();
    }
    }
}
