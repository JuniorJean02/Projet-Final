using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get => (instance == null) ? instance = FindObjectOfType<UIManager>() : instance; }

    // [SerializeField] private Text currentPlayerExpTxt;
    [SerializeField] private TMP_Text currentPlayerExpTxt_TMP;
    [SerializeField] private TMP_Text currentPlayerLevelTxt_TMP;
    [SerializeField] private int paddedZerosForPlayerExp;

    public TMP_Text CurrentPlayerExpTxt_TMP { get => currentPlayerExpTxt_TMP; set => currentPlayerExpTxt_TMP = value; }
    public TMP_Text CurrentPlayerLevelTxt_TMP { get => currentPlayerLevelTxt_TMP; set => currentPlayerLevelTxt_TMP = value; }

    [SerializeField] private Canvas playerPanel;
    [SerializeField] private GameObject[] UICanvas;
    [SerializeField] private GameObject[] GameOverPanel;

    public Canvas PlayerPanel { get => playerPanel; set => playerPanel = value; }


    // private PlayerStats playerStats = PlayerStats.Instance;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCanvasActive();
        UpdateLevelCount();
        UpdateExperienceCount();
        // CurrentPlayerExpTxt_TMP.text = PlayerStats.Instance.experience.ToString($"D{paddedZerosForPlayerExp}");
        // currentPlayerLevelTxt_TMP.SetText("D");

        // currentPlayerExpTxt.text = PlayerStats.Instance.experience.ToString();

    }

    public void GameOverPanelActive()
    {
        GameOverPanel[0].SetActive(true);
    }

    private void PlayerCanvasActive()
    {
        PlayerPanel.gameObject.SetActive(true);
        for (int i = 0; i < UICanvas.Length; i++)
        {
            UICanvas[i].SetActive(false);
        }
        for (int i = 0; i < GameOverPanel.Length; i++)
        {
            GameOverPanel[i].SetActive(false);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UpdateLevelCount()
    {
        currentPlayerLevelTxt_TMP.SetText(PlayerStats.Instance.level.ToString("D3"));
        // throw new NotImplementedException();
    }

    public void UpdateExperienceCount()
    {
        currentPlayerExpTxt_TMP.SetText(PlayerStats.Instance.experience.ToString($"D{paddedZerosForPlayerExp}"));
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if ((CurrentPlayerExpTxt_TMP != null ? CurrentPlayerExpTxt_TMP.text : null) != PlayerStats.Instance.experience.ToString())
    //         UpdateExperienceCount();

    //     if ((CurrentPlayerLevelTxt_TMP.text != ) != PlayerStats.Instance.level.ToString())
    //         UpdateLevelCount()
    //     // {
    //     //     Debug.Log(PlayerStats.Instance.experience.ToString());
    //     //     Debug.Log("Changed EXP Points");
    //     //     CurrentPlayerExpTxt_TMP.SetText(PlayerStats.Instance.experience.ToString($"D{paddedZerosForPlayerExp}"));
    //     //     // currentPlayerExpTxt.text = PlayerStats.Instance.experience.ToString();
    //     //     // currentPlayerExpTxt_TMP.text = PlayerStats.Instance.experience.ToString();
    //     // }
    // }
}
