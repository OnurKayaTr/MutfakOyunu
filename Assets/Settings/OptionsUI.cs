using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance {  get; private set; }

    [SerializeField] private Button MusicButton;
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI SoundeffText;
    [SerializeField] private TextMeshProUGUI musicText;


    private void Awake()
    {
        Instance = this;
        soundEffectButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolume();
            UpdateViusal();
        });
        MusicButton.onClick.AddListener(() => { 
        MusicManager.Instance.ChangeVolume();
            UpdateViusal();
        });
        closeButton.onClick.AddListener(() => {
            Hide();
        });


    }
    private void Start()
    {
        GameManager.Instance.GamePaused += GameManager_GamePaused;
        UpdateViusal();
        Hide();
    }

    private void GameManager_GamePaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateViusal()
    {
        SoundeffText.text = "Sound Effects :" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music :" + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide() {
        gameObject.SetActive(false);

    }
}
