using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{

    public VideoClip[] videos;
    public bool animated;
    public int currentAnimation;
    private VideoPlayer videoPlayer;
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


            // videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;

            // videoPlayer.targetTexture = renderTexture;


            // videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
            videoPlayer.clip = videos[currentAnimation];
            videoPlayer.targetCameraAlpha = 0.5F;


            videoPlayer.frame = 0;


            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += EndReached;


            videoPlayer.playOnAwake = true;

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
