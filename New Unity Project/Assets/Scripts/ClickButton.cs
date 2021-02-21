using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    //public DataController datacontroller;

    public void OnMouseDown()
    {
        //gold += goldPerClick;
        DataController.Instance.gold += DataController.Instance.goldPerClick;

    }
}

