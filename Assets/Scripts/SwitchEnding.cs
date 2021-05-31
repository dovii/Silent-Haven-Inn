using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class SwitchEnding : MonoBehaviour
{
    public GameObject goodEnd;
    public GameObject badEnd;

    public int scoreThreshold = 6; //score at which the conditions change
    int score; //total score from conversations

    void Start()
    {
        goodEnd.SetActive(false);
        badEnd.SetActive(false);

        score = DialogueLua.GetVariable("CandleElf").asInt;
        score += DialogueLua.GetVariable("CandleHuman").asInt;
        score += DialogueLua.GetVariable("CandleOrc").asInt;
        score += DialogueLua.GetVariable("CandleDwarf").asInt;
        score += DialogueLua.GetVariable("CandleGoblin").asInt;
        Debug.Log("Total Score:" + score);
        Debug.Log("Score Threshold:" + scoreThreshold);

        if (score >= scoreThreshold)
        {
            goodEnd.SetActive(true);
        }

        else
        {
            badEnd.SetActive(true);
        }

    }
}