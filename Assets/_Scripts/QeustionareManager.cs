using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QeustionareManager {
    private static QeustionareManager instance;

    private ArrayList currentQuestionare;

    private QeustionareManager()
    {

        currentQuestionare = DataBaseLayer.I.GetQuestionare();
    }

    public static QeustionareManager I
    {
        get
        {
            if (instance == null)
            {
                instance = new QeustionareManager();
            }
            return instance;
        }
    }

    public QeustionModel GetModelById(int id)
    {
        QeustionModel qm = new QeustionModel();
        qm = (QeustionModel) currentQuestionare[id];
        return qm;
    }
    

}
