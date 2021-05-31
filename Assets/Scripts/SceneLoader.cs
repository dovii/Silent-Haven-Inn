using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;


    void Update()
    {
        int sceneLoaded = SceneManager.GetActiveScene().buildIndex; //keep track of scene number/index

        bool ElfDone = DialogueLua.GetVariable("ElfHasTalked").asBool;
        bool HumanDone = DialogueLua.GetVariable("HumanHasTalked").asBool;
        bool DwarfDone = DialogueLua.GetVariable("DwarfHasTalked").asBool;
        bool GoblinDone = DialogueLua.GetVariable("GoblinHasTalked").asBool;
        bool OrcDone = DialogueLua.GetVariable("OrcHasTalked").asBool;

        //if (sceneLoaded == 0){ //if in Intro scene, switch to Main
        //if (Input.GetKeyDown(KeyCode.E)){
        //loadNextScene();
        //}
        //}

        if (sceneLoaded == 2){ //if in Main scene, switch to end
           if (ElfDone && HumanDone && DwarfDone && GoblinDone && OrcDone) 
          // if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log(ElfDone && HumanDone && DwarfDone && GoblinDone && OrcDone);
                loadNextScene();
            }
        }
    }

    public void loadNextScene()
    {
        StartCoroutine(sceneAnimation(SceneManager.GetActiveScene().buildIndex + 1)); //Loads next scene

    }

    IEnumerator sceneAnimation(int sceneIndex)
    {
        transition.SetTrigger("Start"); //Play animation

        yield return new WaitForSeconds(transitionTime); //Wait for animation to stop playing

        SceneManager.LoadScene(sceneIndex); //Load scene

    }
}


