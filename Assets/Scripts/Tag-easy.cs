using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tag1 : MonoBehaviour
{
    public GameObject[] objectsToChange;

    void Start()
    {
        Button btn = GetComponent<Button>();
            btn.onClick.AddListener(ChangeTags);
    }

    void ChangeTags()
    {
        foreach (GameObject obj in objectsToChange)
        {
                obj.tag = "Wall";
        }
    }
}
