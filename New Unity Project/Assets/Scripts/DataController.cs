using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    //어디서든 불러오는 싱글턴을 만듬
    private static DataController instance;

    public static DataController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataController>();

                if (instance == null)
                {
                    GameObject container = new GameObject("DataController");

                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }
    }


    public int goldPerClick
    {
        get
        {
            return PlayerPrefs.GetInt("GoldPerClick" ,1);

        }

        set
        {
            PlayerPrefs.SetInt("GoldPerClick", value);
        }
    }

    //아이템버튼을 다 가져옴
    private ItemButton[] itemButtons;



    public long gold
    {
        get
        {
            if(!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string tmpGold =  PlayerPrefs.GetString("Gold");
            return long.Parse(tmpGold);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    //저장된거 불러오기
    void Awake()
    {
        //저장된 모든데이타를 초기화시키는문장
        //PlayerPrefs.DeleteAll();
        //m_gold = PlayerPrefs.GetInt("Gold");
        //m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    /*
    //저장하기
    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    //저장하기전에 골드더하기
    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    //저장하기전에 골드빼기
    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    //골드 가져오기
    public int GetGold()
    {
        return m_gold;
    }
         
    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

 
    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

        public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    */

    public void LoadUpgradeButton(UpGradeButton upGradeButton)
    {
        string key = upGradeButton.upGradeName;

        upGradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upGradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade",
        upGradeButton.startGoldByUpgrade);
        upGradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upGradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpGradeButton upGradeButton)
    {
        string key = upGradeButton.upGradeName;

        PlayerPrefs.SetInt(key + "_level", upGradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upGradeButton.startGoldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upGradeButton.currentCost);

    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");

        if (PlayerPrefs.GetInt(key + "_isPurchsed") == 1)
        {
            //아이템을 구매했으면1, 1이면 참으로 저장
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.startCurrentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchased == true)
        {
            //아이템을 구매하면 1을 주고
            PlayerPrefs.SetInt(key + "_isPurchsed", 1);
        }
        else
        {
            //아이템을 구매하지않았으면 0를 준다.
            PlayerPrefs.SetInt(key + "_isPurchsed", 0);
        }

    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for (int i = 0; i < itemButtons.Length; i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }
        return goldPerSec;
    }

}
