using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseMimic  {

    private static DataBaseMimic instance;


    private DataBaseMimic() {

    }

    public static DataBaseMimic I
    {
        get
        {
            if (instance == null)
            {
                instance = new DataBaseMimic();
            }
            return instance;
        }
    }


    public ArrayList GetQuestionare()
    {
        ArrayList questionare = new ArrayList();

        QeustionModel qm = new QeustionModel();
        qm.AncestorId = 1;
        qm.Identifier = 0;
        qm.MainQuestion = "";
        qm.AnswerA = "";
        qm.AnswerB = "";
        qm.AnswerC = "";
        qm.AnswerD = "";
        qm.CorectAnswer = 1;
        questionare.Add(qm);

        QeustionModel qm1 = new QeustionModel();
        qm1.AncestorId = 1;
        qm1.Identifier = 1;
        qm1.MainQuestion = "";
        qm1.AnswerA = "";
        qm1.AnswerB = "";
        qm1.AnswerC = "";
        qm1.AnswerD = "";
        qm1.CorectAnswer = 1;
        questionare.Add(qm1);

        QeustionModel qm2 = new QeustionModel();
        qm2.AncestorId = 1;
        qm2.Identifier = 2;
        qm2.MainQuestion = "";
        qm2.AnswerA = "";
        qm2.AnswerB = "";
        qm2.AnswerC = "";
        qm2.AnswerD = "";
        qm2.CorectAnswer = 1;
        questionare.Add(qm2);

        return questionare;
    }


}
