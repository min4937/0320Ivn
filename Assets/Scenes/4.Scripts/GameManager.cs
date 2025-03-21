using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }
    public Item itemPrefab;

    [SerializeField] private Sprite swordSprite;
    [SerializeField] private Sprite shieldSprite;
    [SerializeField] private Sprite bowSprite;
    [SerializeField] private Sprite bookSprite;
    [SerializeField] private Sprite helmetSprite;
    [SerializeField] private Sprite axeSprite;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        Player = new Character("Chad", 10, 20000, 100, 35, 40, 25, 9, 12);

        // 프리팹에서 Item을 로드하고 Icon 설정
        Item sword = Instantiate(itemPrefab);
        sword.SetData("Sword", "A basic sword", 10, 0, swordSprite);

        Item shield = Instantiate(itemPrefab);
        shield.SetData("Shield", "A basic shield", 0, 5, shieldSprite);

        Item bow = Instantiate(itemPrefab);
        bow.SetData("Bow", "A simple bow", 5, 0, bowSprite);

        Item book = Instantiate(itemPrefab);
        book.SetData("Book", "A magic book", 0, 0, bookSprite);

        Item helmet = Instantiate(itemPrefab);
        helmet.SetData("Helmet", "A steel helmet", 0, 10, helmetSprite);

        Item axe = Instantiate(itemPrefab);
        axe.SetData("Axe", "A powerful axe", 15, 0, axeSprite);


        Player.AddItem(sword);
        Player.AddItem(shield);
        Player.AddItem(bow);
        Player.AddItem(book);
        Player.AddItem(helmet);
        Player.AddItem(axe);
        Player.AddItem(null);
        Player.AddItem(null);
        Player.AddItem(null);

        sword.IsEquipped = false;
        shield.IsEquipped = false;
        bow.IsEquipped = false;
        book.IsEquipped = false;
        helmet.IsEquipped = false;
        axe.IsEquipped = false;

        //Destroy(sword.gameObject);
        //Destroy(shield.gameObject);
        //Destroy(bow.gameObject);
        //Destroy(book.gameObject);
        //Destroy(helmet.gameObject);
        //Destroy(axe.gameObject);

        UIManager.Instance.UIMainMenu.SetCharacterInfo();
        UIManager.Instance.UIStatus.SetCharacterInfo();
        UIManager.Instance.UIInventory.RefreshUI();
    }
}
