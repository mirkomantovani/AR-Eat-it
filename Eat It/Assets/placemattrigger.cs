using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class placemattrigger : MonoBehaviour {

    public Animator smileUp;
    public Animator sadUp;
    public Animator openNutrition;
    public MeshRenderer nutritionalMeshRenderer;
    public Texture cerealNutritionTexture;
    public Texture cereal2NutritionTexture;
    public Texture drink1NutritionTexture;

    public AudioClip kettleAudioClip;
    public AudioClip cerealAudioClip;
    public AudioClip smokeAudioClip;
    public AudioClip laserAudioClip;

    public AudioSource drink;
    public AudioSource cereal;
    public AudioSource cereal2;
    public AudioSource nutritionFact;

    private static bool isCerealIn = false;
    private static bool isCereal2In = false;
    private static bool isCanIn = false;

    private static bool closeNutrition = false;

    public static void onLostTrackableSignal(TrackableBehaviour lostTrackable)
    {
        Debug.Log("Object lost and exited: " + lostTrackable.TrackableName);

        switch (lostTrackable.TrackableName)
        {
            case "cereal":
                isCerealIn = false;
                //openNutrition.Play("closenutritioninfoanim");
                closeNutrition = true;
                break;
            case "cereal2":
                isCereal2In = false;
                //openNutrition.Play("closenutritioninfoanim");
                break;
            case "drink1":
                isCanIn = false;
                //openNutrition.Play("closenutritioninfoanim");
                break;
            default:
                Debug.Log("Unidentified object lost");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered: "+other.name);

        switch (other.name)
        {
            case "collidercereal1":
                closeNutrition = false;
                isCerealIn = true;
                openNutrition.Play("opennutritioninfoanim");
                cereal.Play();
                nutritionFact.Play();
                nutritionalMeshRenderer.material.SetTexture("_MainTex", cerealNutritionTexture);
                break;
            case "collidercereal2":
                isCereal2In = true;
                openNutrition.Play("opennutritioninfoanim");
                cereal2.Play();
                nutritionFact.Play();
                nutritionalMeshRenderer.material.SetTexture("_MainTex", cereal2NutritionTexture);
                break;
            case "collidercan":
                isCanIn = true;
                openNutrition.Play("opennutritioninfoanim");
                drink.Play();
                nutritionFact.Play();
                nutritionalMeshRenderer.material.SetTexture("_MainTex", drink1NutritionTexture);
                break;
            default:
                Debug.Log("Unidentified object entered");
                break;
        }
        checkAnimation();
    }

    void checkAnimation(){
        if(isCanIn && ((isCerealIn && !isCereal2In) || (!isCerealIn && isCereal2In))){
            smileUp.Play("smileupanim");
            sadUp.Play("none");
        } else if(isCerealIn && isCereal2In){
            sadUp.Play("sadupanim");
            smileUp.Play("none");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited: "+other.name);

        switch (other.name)
        {
            case "collidercereal1":
                isCerealIn = false;
                openNutrition.Play("closenutritioninfoanim");
                break;
            case "collidercereal2":
                isCereal2In = false;
                openNutrition.Play("closenutritioninfoanim");
                break;
            case "collidercan":
                isCanIn = false;
                openNutrition.Play("closenutritioninfoanim");
                break;
            default:
                Debug.Log("Unidentified object exited");
                break;
        }
    }


    void Start () {
        smileUp.GetComponent<Animator>();
        sadUp.GetComponent<Animator>();
        openNutrition.GetComponent<Animator>();
        nutritionalMeshRenderer.GetComponent<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        if(closeNutrition){
            openNutrition.Play("closenutritioninfoanim");
        }
	}
}
