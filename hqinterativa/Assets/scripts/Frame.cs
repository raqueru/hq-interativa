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

    void Awake()
    {

        if (animated)
        {

            GameObject camera = GameObject.Find("Main Camera");


            videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();


            videoPlayer.playOnAwake = true;

            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

            videoPlayer.clip = videos[currentAnimation];
            videoPlayer.targetCameraAlpha = 0.5F;



            videoPlayer.frame = 0;

            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += EndReached;
        }


    }
    public void Play()
    {
        videoPlayer.clip = videos[currentAnimation];
        videoPlayer.Play();
    }
    public void Stop()
    {

        videoPlayer.Stop();
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
