using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class manager_video : MonoBehaviour {

    public GameObject planeCat;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public VideoClip videoToPlay;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void StartVideo()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    public IEnumerator playVideo()
    {
        videoPlayer = planeCat.AddComponent<VideoPlayer>();
        audioSource = planeCat.AddComponent<AudioSource>();
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        videoPlayer.source = VideoSource.VideoClip;

        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();
    }
}
