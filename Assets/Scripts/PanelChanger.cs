using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject backArrow;

    enum Panel
    {
        Panel0,
        Panel1,
        Panel2,
        Panel3,
        Panel4,
        Panel5,
        Panel6,
        Panel7,
        Panel8,
    }

    private void Start()
    {
        Init();
    }

    Panel currentPanel;

    void HideArrows()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        backArrow.SetActive(false);
    }
    
    public void OnRightButton() // ‰E–îˆó‚ð‰Ÿ‚µ‚½‚Æ‚«
    {
        switch (currentPanel)
        {
            case Panel.Panel0:
                ShowPanel(Panel.Panel1);
                break;
            case Panel.Panel1:
                ShowPanel(Panel.Panel2);
                break;
            case Panel.Panel6:
                ShowPanel(Panel.Panel7);
                break;
            case Panel.Panel7:
                ShowPanel(Panel.Panel8);
                break;
        }
    }
    public void OnLeftButton() // ¶–îˆó‚ð‰Ÿ‚µ‚½‚Æ‚«
    {
        switch (currentPanel)
        {
            case Panel.Panel1:
                ShowPanel(Panel.Panel0);
                break;
            case Panel.Panel2:
                ShowPanel(Panel.Panel1);
                break;
            case Panel.Panel7:
                ShowPanel(Panel.Panel6);
                break;
            case Panel.Panel8:
                ShowPanel(Panel.Panel7);
                break;
        }
    }
    public void OnBackButton() // –ß‚é–îˆó‚ð‰Ÿ‚µ‚½‚Æ‚«
    {
        // Panel3 -> 0
        // Panel4 -> 1
        // Panel5 -> 2
        switch (currentPanel)
        {
            case Panel.Panel3:
                ShowPanel(Panel.Panel0);
                break;
            case Panel.Panel4:
                ShowPanel(Panel.Panel1);
                break;
            case Panel.Panel5:
                ShowPanel(Panel.Panel2);
                break;
        }
    }

    public void OnLocker()
    {
        ShowPanel(Panel.Panel3);
    }

    public void OnPig()
    {
        ShowPanel(Panel.Panel4);
    }

    public void OnBucket()
    {
        ShowPanel(Panel.Panel5);
    }

    public void OnHall2()
    {
        ShowPanel(Panel.Panel6);
    }

    public void OnHall6()
    {
        ShowPanel(Panel.Panel2);
    }

    void Init()
    {
        HideArrows();
        MessageManager.instance.HidePanel();
        currentPanel = Panel.Panel0;
        rightArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 0);
    }

    void ShowPanel(Panel panel)
    {
        MessageManager.instance.HidePanel();
        SoundManager.instance.PlaySE(SoundManager.SE.OnButton);
        HideArrows();
        currentPanel = panel;
        switch (panel)
        {
            case Panel.Panel0:
                rightArrow.SetActive(true);
                transform.localPosition = new Vector2(0, 0);
                break;
            case Panel.Panel1:
                rightArrow.SetActive(true);
                leftArrow.SetActive(true);
                transform.localPosition = new Vector2(-1000, 0);
                break;
            case Panel.Panel2:
                leftArrow.SetActive(true);
                transform.localPosition = new Vector2(-2000, 0);
                break;
            case Panel.Panel3:
                backArrow.SetActive(true);
                transform.localPosition = new Vector2(0, 1500);
                break;
            case Panel.Panel4:
                backArrow.SetActive(true);
                transform.localPosition = new Vector2(-1000, 1500);
                break;
            case Panel.Panel5:
                backArrow.SetActive(true);
                transform.localPosition = new Vector2(-2000, 1500);
                break;
            case Panel.Panel6:
                rightArrow.SetActive(true);
                transform.localPosition = new Vector2(0, 3000);
                break;
            case Panel.Panel7:
                rightArrow.SetActive(true);
                leftArrow.SetActive(true);
                transform.localPosition = new Vector2(-1000, 3000);
                break;
            case Panel.Panel8:
                leftArrow.SetActive(true);
                transform.localPosition = new Vector2(-2000, 3000);
                break;
        }
    }
}
