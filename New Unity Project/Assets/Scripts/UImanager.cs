using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    //골드표시
    public Text goldDisplayer;

    //클릭골드표시
    public Text goldPerClickDisplayer;

    public Text goldPerSecDisplayer;

    //골드변수를 가져오기위한 데이타콘트롤러
    //public DataController dataController;



    void Update()
    {
        goldDisplayer.text = "GOLD : " + DataController.Instance.gold;
        goldPerClickDisplayer.text = "GOLD PER CLICK : " + DataController.Instance.goldPerClick;
        goldPerSecDisplayer.text = "GOLD PER SEC: " + DataController.Instance.GetGoldPerSec();
    }

}
