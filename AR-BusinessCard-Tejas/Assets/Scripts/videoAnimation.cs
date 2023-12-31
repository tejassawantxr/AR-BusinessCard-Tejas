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
    Animator SkillsBodyAnim;
    Animator ProjectBodyAnim;
    Animator ProfileBodyAnim;
    Animator SocialBodyAnim;
    Animator CarCustomiserAnim;
    Animator Project2Anim;
    Animator Project4Anim;
    Animator Project5Anim;
    Animator Project3Anim;
    Animator WebsiteAnim;



    VideoPlayer IntroVideo;
    VideoPlayer SkillVideo;
    VideoPlayer ProjectVideo;
    VideoPlayer ProfileVideo;
    VideoPlayer SocialAndOutroVideo;

    GameObject IntroVideoGameObject;
    GameObject SkillVideoGameObject;
    GameObject ProjectVideoGameObject;
    GameObject ProfileVideoGameObject;
    GameObject SocialVideoGameObject;
    
    public GameObject Skills;
    public GameObject Project;
    public GameObject Profile;
    public GameObject Social;

    float frame; 
    float frameCount;

   

    void Start()
    {
        IntroVideoGameObject = GameObject.FindWithTag("IntroVideo");
        IntroAnim = IntroVideoGameObject.GetComponent<Animator>();
        IntroVideo = IntroVideoGameObject.GetComponent<VideoPlayer>();

        SkillVideoGameObject = GameObject.FindWithTag("SkillVideo");
        SkillAnim = SkillVideoGameObject.GetComponent<Animator>();
        SkillVideo = SkillVideoGameObject.GetComponent<VideoPlayer>();

        ProjectVideoGameObject = GameObject.FindWithTag("ProjectVideo");
        ProjectAnim = ProjectVideoGameObject.GetComponent<Animator>();
        ProjectVideo = ProjectVideoGameObject .GetComponent<VideoPlayer>();

        ProfileVideoGameObject = GameObject.FindWithTag("ProfileVideo");
        ProfileAnim = ProfileVideoGameObject.GetComponent<Animator>();
        ProfileVideo = ProfileVideoGameObject.GetComponent<VideoPlayer>();

        SocialVideoGameObject = GameObject.FindWithTag("SocialAndOutroVideo");
        SocialAndOutroAnim = SocialVideoGameObject.GetComponent<Animator>();
        SocialAndOutroVideo = SocialVideoGameObject.GetComponent<VideoPlayer>();
        
        SkillsBodyAnim = Skills.GetComponent<Animator>();
        ProjectBodyAnim = Project.GetComponent<Animator>();
        ProfileBodyAnim = Profile.GetComponent<Animator>();
        SocialBodyAnim = Social.GetComponent<Animator>();

        CarCustomiserAnim = Project.transform.Find("Project1").GetComponentInChildren<Animator>();
        Project2Anim =  Project.transform.Find("Project2").GetComponentInChildren<Animator>();
        Project4Anim =  Project.transform.Find("Project4").GetComponentInChildren<Animator>();
        Project5Anim =  Project.transform.Find("Project5").GetComponentInChildren<Animator>();
        Project3Anim =  Project.transform.Find("Project3").GetComponentInChildren<Animator>();
        WebsiteAnim = Profile.transform.Find("Website").GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        frame = IntroVideo.frame;
        frameCount = IntroVideo.frameCount;  
        // Debug.Log("Introframe===>"+ frame);
        // Debug.Log("IntroframeCount-3===>"+ (frameCount-3));
        // Debug.Log("IntroframeCount===>"+ frameCount);
        if(frame >= frameCount-3 & IntroVideo.isPlaying){  //.isPlaying flag used to stop skillVideo to play every frame
            // Debug.Log("FadeInIntro");
            IntroAnim.SetBool("IsFadeInIntro",true);
            SkillVideo.Play();
            SkillAnim.SetBool("IsFadeOutSkills", true);
            SkillsBodyAnim.SetBool("isFOutSkillsBody", true);
        }

        frame = SkillVideo.frame;
        frameCount = SkillVideo.frameCount;   
    
        if(frame >= 215 && frame <= 220){
            SkillsBodyAnim.SetBool("isFOutInSkillARCore", true);
        }
        if(frame >= frameCount-3 && SkillVideo.isPlaying){
            SkillVideo.Pause();   //Because, when video stops white plane occurs while Intro Animation transitioning to fadeIn
            SkillAnim.SetBool("IsFadeOutSkills", false);
            SkillsBodyAnim.SetBool("isFOutSkillsBody", false);
            ProjectVideo.Play();
            ProjectAnim.SetBool("IsFadeOutProject", true);
            ProjectBodyAnim.SetBool("FOutProjectBody",true);
            if(IntroVideoGameObject != null){
                IntroVideoGameObject.SetActive(false);
            }           
        }

        // Debug.Log("ProjectVideoframe===>"+ frame);
        // Debug.Log("ProjectVideoframeCount-1===>"+ (frameCount-1));
        // Debug.Log("ProjectVideoframeCount===>"+ frameCount);

        frame = ProjectVideo.frame;
        frameCount = ProjectVideo.frameCount;   
       
        if(frame >=120 && frame <= 493){
            Project3Anim.SetBool("isFOutProject3", true);
        }else{
            Project3Anim.SetBool("isFOutProject3", false);
        }

        if(frame >= 494 && frame <= 774){
            Project2Anim.SetBool("isFOutProject2", true);
        }else{
            Project2Anim.SetBool("isFOutProject2", false);
        } 

        if(frame >= 775 && frame <= 1060){
            CarCustomiserAnim.SetBool("IsFOutCarCustom", true);
        }else{
            CarCustomiserAnim.SetBool("IsFOutCarCustom", false);
        }

        if(frame >= 1061 && frame <= 1415){
           Project5Anim.SetBool("isFOutProject5", true);
        }else{
           Project5Anim.SetBool("isFOutProject5", false);
        }

        if(frame >= 1416 && frame <= 1750){
            Project4Anim.SetBool("isFOutProject4", true);
        }else{
            Project4Anim.SetBool("isFOutProject4", false);
        }

        if(frame >= frameCount-3 && ProjectVideo.isPlaying){
            ProjectVideo.Pause();
            ProjectAnim.SetBool("IsFadeOutProject", false);
            ProjectBodyAnim.SetBool("FOutProjectBody",false);
            ProfileVideo.Play();
            ProfileAnim.SetBool("IsFadeOutProfile", true);
            ProfileBodyAnim.SetBool("isFOutProfileBody", true);
            if(SkillVideoGameObject != null){
                SkillVideoGameObject.SetActive(false);
            }    
        }

        // Debug.Log("Profileframe===>"+ frame);
        // Debug.Log("ProfileframeCount-1===>"+ (frameCount-1));
        // Debug.Log("ProfileframeCount===>"+ frameCount);

        frame = ProfileVideo.frame;
        frameCount = ProfileVideo.frameCount;  
       
        if(frame >= 175 && frame <= 275){
            WebsiteAnim.SetBool("isFOutWebsiteAnim", true);
        }else{
            WebsiteAnim.SetBool("isFOutWebsiteAnim", false);
        } 
        if(frame >= frameCount-3 && ProfileVideo.isPlaying){
            ProfileBodyAnim.SetBool("isFOutProfileBody", false);
            ProfileAnim.SetBool("IsFadeOutProfile", false);
            SocialAndOutroVideo.Play();
            SocialAndOutroAnim.SetBool("IsFadeOutSocialOutro", true);
            SocialBodyAnim.SetBool("isFOutSocialBody", true);
            if(ProjectVideoGameObject != null){
                ProjectVideoGameObject.SetActive(false);
            }    
        }

        // Debug.Log("Socialframe===>"+ frame);
        // Debug.Log("SocialframeCount-1===>"+ (frameCount-1));
        // Debug.Log("SocialframeCount===>"+ frameCount);

        frame = SocialAndOutroVideo.frame;
        frameCount = SocialAndOutroVideo.frameCount;   
        if(frame >= 185 && frame <= 195){
            SocialBodyAnim.SetBool("isFOutInSocialLinkedin", true);
        }
        Debug.Log("SocialAndOutroVideo===>"+ frame);
        if(frame >= frameCount-3 && SocialAndOutroVideo.isPlaying){
            SocialAndOutroAnim.SetBool("IsFadeOutSocialOutro", false);
            SocialBodyAnim.SetBool("isFOutSocialBody", false);
            if(ProfileVideoGameObject != null){
                ProfileVideoGameObject.SetActive(false);
            }
        }
    }
}
