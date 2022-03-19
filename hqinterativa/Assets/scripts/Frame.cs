using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Frame : MonoBehaviour
{

    public VideoClip[] videos;
    public bool animated;
    public int currentAnimation;
    private VideoPlayer videoPlayer;

    void Start()
    {

        if (videos.Length > 0)
        {

            GameObject camera = GameObject.Find("Main Camera");


            videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();


            videoPlayer.playOnAwake = false;

            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

            videoPlayer.clip = videos[currentAnimation];
            videoPlayer.targetCameraAlpha = 0.5F;



            videoPlayer.frame = 100;

            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += EndReached;
            Play();
        }


    }
    public void Play()
    {
        videoPlayer.clip = videos[currentAnimation];
        videoPlayer.Play();
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
