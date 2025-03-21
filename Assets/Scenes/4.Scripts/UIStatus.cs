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
        ATKText.text = $"���ݷ�: {GameManager.Instance.Player.ATK}";
        DEFText.text = $"����: {GameManager.Instance.Player.DEF}";
        HPText.text = $"ü��: {GameManager.Instance.Player.HP}";
        CriticalText.text = $"ġ��Ÿ: {GameManager.Instance.Player.Critical}";
    }

    public void RefreshUI()
    {
        SetCharacterInfo();
    }
}
