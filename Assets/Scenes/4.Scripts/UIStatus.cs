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
        ATKText.text = $"���ݷ�: {player.ATK}";
        DEFText.text = $"����: {player.DEF}";
        HPText.text = $"ü��: {player.HP}";
        CriticalText.text = $"ġ��Ÿ: {player.Critical}";
    }

    public void RefreshUI()
    {
        SetCharacterInfo();
    }
}
