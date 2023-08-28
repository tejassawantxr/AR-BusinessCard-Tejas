using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    Animator IntroAnim;
    Animator SkillAnim;
    Animator ProjectAnim;
    Animator ProfileAnim;
    Animator SocialAndOutroAnim;
    VideoPlayer IntroVideo;
    VideoPlayer SkillVideo;
    VideoPlayer ProjectVideo;
    VideoPlayer ProfileVideo;
    VideoPlayer SocialAndOutroVideo;
    float frame; 
    float frameCount;

    void Start()
    {
        IntroAnim = GameObject.FindWithTag("IntroVideo").GetComponent<Animator>();
        SkillAnim = GameObject.FindWithTag("SkillVideo").GetComponent<Animator>();
        ProjectAnim = GameObject.FindWithTag("ProjectVideo").GetComponent<Animator>();
        ProfileAnim = GameObject.FindWithTag("ProfileVideo").GetComponent<Animator>();
        SocialAndOutroAnim = GameObject.FindWithTag("SocialAndOutroVideo").GetComponent<Animator>();

        IntroVideo = GameObject.FindWithTag("IntroVideo").GetComponent<VideoPlayer>();
        SkillVideo = GameObject.FindWithTag("SkillVideo").GetComponent<VideoPlayer>();
        ProjectVideo = GameObject.FindWithTag("ProjectVideo").GetComponent<VideoPlayer>();
        ProfileVideo = GameObject.FindWithTag("ProfileVideo").GetComponent<VideoPlayer>();
        SocialAndOutroVideo = GameObject.FindWithTag("SocialAndOutroVideo").GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        frame = IntroVideo.frame;
        frameCount = IntroVideo.frameCount;   
        if(frame == frameCount-1 & IntroVideo.isPlaying){  //.isPlaying flag used to stop skillVideo to play every frame
            // Debug.Log("FadeInIntro");
            IntroAnim.SetBool("IsFadeInIntro",true);
            SkillAnim.SetBool("IsFadeOutSkills", true);
            SkillVideo.Play();
        }

        frame = SkillVideo.frame;
        frameCount = SkillVideo.frameCount;   
        if(frame == frameCount-1 && SkillVideo.isPlaying){
            SkillVideo.Pause();   //Because, when video stops white plane occurs while Intro Animation transitioning to fadeIn
            SkillAnim.SetBool("IsFadeOutSkills", false);
            ProjectAnim.SetBool("IsFadeOutProject", true);
            ProjectVideo.Play();
        }

        frame = ProjectVideo.frame;
        frameCount = ProjectVideo.frameCount;   
        if(frame == frameCount-1 && ProjectVideo.isPlaying){
            ProjectVideo.Pause();
            ProjectAnim.SetBool("IsFadeOutProject", false);
            ProfileAnim.SetBool("IsFadeOutProfile", true);
            ProfileVideo.Play();
        }

        frame = ProfileVideo.frame;
        frameCount = ProfileVideo.frameCount;   
        if(frame == frameCount-1 && ProfileVideo.isPlaying){
            ProfileAnim.SetBool("IsFadeOutProfile", false);
            SocialAndOutroAnim.SetBool("IsFadeOutSocialOutro", true);
            SocialAndOutroVideo.Play();
        }

        frame = SocialAndOutroVideo.frame;
        frameCount = SocialAndOutroVideo.frameCount;   
        if(frame == frameCount-1 && SocialAndOutroVideo.isPlaying){
            SocialAndOutroAnim.SetBool("IsFadeOutSocialOutro", false);
        }
    }
}
