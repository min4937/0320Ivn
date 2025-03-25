using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Text ATKText;
    [SerializeField] private Text DEFText;
    [SerializeField] private Text HPText;
    [SerializeField] private Text CriticalText;
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(OpenMainMenu);
        gameObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.UIMainMenu.OpenButton();
        gameObject.SetActive(false);
    }

    public void SetCharacterInfo()
    {
        var player = GameManager.Instance.Player;
        Debug.Log("SetCharacterInfo Called!");
        Debug.Log("ATK: " + player.ATK + ", DEF: " + player.DEF);
        ATKText.text = $"공격력: {player.ATK}";
        DEFText.text = $"방어력: {player.DEF}";
        HPText.text = $"체력: {player.HP}";
        CriticalText.text = $"치명타: {player.Critical}";
    }

    public void RefreshUI()
    {
        SetCharacterInfo();
    }
}
