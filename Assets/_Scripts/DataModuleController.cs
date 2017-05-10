using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataModuleController : MonoBehaviour {

    


    [SerializeField]
    private DataModuleModel.TypeOfData typeData;
    
    [SerializeField] private GameObject childImg;

    private Object[] dataImg;
    


    void Start ()
    {
        SetupDataInformation();

    }

    private GameObject go;

    private void LoadAllDataFromPath(string path)
    {
        dataImg = Resources.LoadAll<Sprite>(path);
       
    }


    private void SetupDataInformation()
    {
        string path = "LS/LESSON/1";
        LoadAllDataFromPath(path);
        foreach (var img in dataImg)
        {
            Sprite timg = (Sprite)img;
            childImg.GetComponent<RectTransform>().sizeDelta = new Vector2(timg.rect.width, timg.rect.height);
            childImg.GetComponent<Image>().sprite = timg;
            var newImg = Instantiate(childImg);
            newImg.transform.SetParent(transform);

            // newImg.GetComponent<Image>().sprite = (Sprite)img;
        }

        childImg.SetActive(false);
    }
       
    

    // Update is called once per frame
    void Update () {
		
	}
}
