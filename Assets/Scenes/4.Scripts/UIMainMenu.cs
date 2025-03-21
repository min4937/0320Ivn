using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Text idText;
    [SerializeField] private Text levelText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Text expText;
    [SerializeField] private Text goldText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }
    public void OpenButton()
    {
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }
    public void OpenStatus()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        UIManager.Instance.UIStatus.gameObject.SetActive(true);
    }

    public void OpenInventory()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.gameObject.SetActive(true);
    }

    public void SetCharacterInfo()
    {
        idText.text = $"Chad";
        levelText.text = $"Lv. {GameManager.Instance.Player.Level}";
        expSlider.maxValue = GameManager.Instance.Player.MaxEXP;
        expSlider.value = GameManager.Instance.Player.EXP;
        expText.text = $"{GameManager.Instance.Player.EXP} / {GameManager.Instance.Player.MaxEXP}";
        goldText.text = $"{GameManager.Instance.Player.Gold:N0}";  // Format with commas
        descriptionText.text = "코딩의 노예가 된지 10년 째 되는 미승입니다. 오늘도 밤샘일이 남아서 치킨을 시킬 지도 모른다는 생각에 배민을 키고 있네요.";
    }
}
