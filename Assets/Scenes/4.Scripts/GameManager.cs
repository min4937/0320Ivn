using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
     public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

    public Item sword;
    public Item shield;
    public Item bow;
    public Item book;
    public Item helmet;
    public Item axe;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new Character("Chad", 1, 20000, 100, 35, 40, 25, 9, 12);

        // 테스트용으로 특정 슬롯에 아이템 할당 
        Player.Inventory[0] = sword;
        Player.Inventory[1] = shield;
        Player.Inventory[2] = bow;
        Player.Inventory[3] = book;
        Player.Inventory[4] = helmet;
        Player.Inventory[5] = axe;

        UIManager.Instance.UIInventory.RefreshUI();
        UIManager.Instance.UIStatus.RefreshUI();
        UIManager.Instance.UIMainMenu.SetCharacterInfo();
    }
}
