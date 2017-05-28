using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QeustionareController : MonoBehaviour
{


    [SerializeField]
    private GameObject mainQuestion;
    [SerializeField] private GameObject btnA;
    [SerializeField]
    private GameObject btnB;
    [SerializeField]
    private GameObject btnC;
    [SerializeField]
    private GameObject btnD;

    private QeustionModel qm;

    private Text mainQuestionText;
    private Text answerAText;
    private Text answerBText;
    private Text answerCText;
    private Text answerDText;

    // Use this for initialization
    void Start ()
    {

        mainQuestionText = mainQuestion.GetComponent<Text>();
        answerAText = btnA.GetComponentInChildren<Text>();
        answerBText = btnB.GetComponentInChildren<Text>();
        answerCText = btnC.GetComponentInChildren<Text>();
        answerDText = btnD.GetComponentInChildren<Text>();

        SetupUi();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitQm()
    {
        qm = new QeustionModel();
    }

    private void GetQm()
    {
        
    }

    private void SetupUi()
    {
        if (qm == null)
        {
            InitQm();
            SetupUi();
        }
        else
        {
            mainQuestionText.text = qm.MainQuestion;

            answerAText.text = qm.AnswerA;
            answerBText.text = qm.AnswerB;
            answerCText.text = qm.AnswerC;
            answerDText.text = qm.AnswerD;
        }
    }


    public void NextTest()
    {
        
    }
}


