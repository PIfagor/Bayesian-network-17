using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QeustionModel  {


    public int Identifier { get; set; }
    public int AncestorId { get; set; }
    public string MainQuestion { get; set; }
    public string AnswerA { get; set; }
    public string AnswerB { get; set; }
    public string AnswerC { get; set; }
    public string AnswerD { get; set; }
    public int CorectAnswer { get; set; }

    

    public QeustionModel(int identifier, int ancestorId, string mainQuestion, string answerA, string answerB,
        string answerC, string answerD, int corectAnswer)
    {
        Identifier = identifier;
        AncestorId = ancestorId;
        MainQuestion = mainQuestion;
        AnswerA = answerA;
        AnswerB = answerB;
        AnswerC = answerC;
        AnswerD = answerD;
        CorectAnswer = corectAnswer;
    }

    public QeustionModel():
           this(0, -1, "Test question", "A", "B", "C", "D", 0)
    {
     
    }
}
