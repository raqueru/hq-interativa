using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{

    public VideoClip video;
    public bool animated;
    private VideoPlayer videoPlayer;
    public bool played = false;

    private RawImage image;
    RenderTexture renderTexture;

    void Awake()
    {


        if (animated)
        {
            image = GetComponentInParent<RawImage>();

            if (renderTexture == null)
                renderTexture = new RenderTexture(350, 300, 24);
            GameObject camera = GameObject.Find("Main Camera");


            videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

            image.texture = renderTexture;


            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

            videoPlayer.targetTexture = renderTexture;


            videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
            videoPlayer.clip = video;
            videoPlayer.targetCameraAlpha = 1F;


            videoPlayer.frame = 0;


            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += EndReached;


            Play();

        }


    }
    public void Play()
    {
        videoPlayer.clip = video;
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
