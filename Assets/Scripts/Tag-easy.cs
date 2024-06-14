using System.Collections;           //Libaries
using System.Collections.Generic;   //
using UnityEngine;                  //
using UnityEngine.UI;               //

public class Tag1 : MonoBehaviour   //Klasse Tag1
{
    public GameObject[] objectsToChange;    //Array objectsToChange

    void Start()    //Methode Start
    {
        Button btn = GetComponent<Button>();    //btn wird auf Button gesetzt
        btn.onClick.AddListener(ChangeTags);    //btn wird ein EventListener hinzugefügt
    }

    void ChangeTags()   //Methode ChangeTags
    {
        foreach (GameObject obj in objectsToChange) //Für jedes GameObject in objectsToChange
        {
                obj.tag = "Wall";   //Setze Tag auf Wall
        }
    }
}
