using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModuleModel
{


    public enum TypeOfData { LESSON, EXAMPLE }


    private List<DataModuleModel> nextNodes;

    private List<DataModuleModel> prewNodes;



    public TypeOfData modulType { get; set; }

    public string Name { get; set; }

    public int DataID { get; set; }

    public int TimeTolearn { get; set; }


    public DataModuleModel()
    {
        nextNodes = null;
        prewNodes = null;
    }

    public void AddNewNextNode(DataModuleModel next)
    {
        nextNodes.Add(next);
    }


}
