using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseLayer
{
    private static DataBaseLayer instance;
   

    private DataBaseLayer()
    {

    }

    public static DataBaseLayer I
    {
        get
        {
            if (instance == null)
            {
                instance = new DataBaseLayer();
            }
            return instance;
        }
    }


    public ArrayList GetQuestionare()
    {
        return DataBaseMimic.I.GetQuestionare();
    }

}
