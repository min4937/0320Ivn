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
        ATKText.text = $"공격력: {GameManager.Instance.Player.ATK}";
        DEFText.text = $"방어력: {GameManager.Instance.Player.DEF}";
        HPText.text = $"체력: {GameManager.Instance.Player.HP}";
        CriticalText.text = $"치명타: {GameManager.Instance.Player.Critical}";
    }

    public void RefreshUI()
    {
        SetCharacterInfo();
    }
}
