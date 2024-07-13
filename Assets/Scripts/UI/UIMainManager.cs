﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIMainManager : MonoBehaviour
{
    private IMenu[] m_menuList;

    private GameManager m_gameManager;
    
    [Serializable]
    public struct Canvases {
        public GameManager.eStateGame correspondState;
        public Canvas canvas;
    }

    private void Awake()
    {
        m_menuList = GetComponentsInChildren<IMenu>(true);
    }

    [SerializeField] private List<Canvases> _canvasesList = new List<Canvases>();

    void Start()
    {
        for (int i = 0; i < m_menuList.Length; i++)
        {
            m_menuList[i].Setup(this);
        }

        if (_canvasesList.Count <= 0) {
            Debug.LogError($"No canvasList ref setup at {this}");
            return;
        }
        
        foreach (var element in _canvasesList) {
            element.canvas.enabled = false;
        }
    }

    internal void ShowMainMenu()
    {
        m_gameManager.ClearLevel();
        m_gameManager.SetState(GameManager.eStateGame.MAIN_MENU);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_gameManager.State == GameManager.eStateGame.GAME_STARTED)
            {
                m_gameManager.SetState(GameManager.eStateGame.PAUSE);
            }
            else if (m_gameManager.State == GameManager.eStateGame.PAUSE)
            {
                m_gameManager.SetState(GameManager.eStateGame.GAME_STARTED);
            }
        }
    }

    internal void Setup(GameManager gameManager)
    {
        m_gameManager = gameManager;
        m_gameManager.StateChangedAction += OnGameStateChange;
    }

    private void OnGameStateChange(GameManager.eStateGame state)
    {
        foreach (var element in _canvasesList) {
            if (element.correspondState == state) {
                element.canvas.enabled = true;
                continue;
            }
            
            if (element.canvas.enabled) element.canvas.enabled = false;
        }
    }

    private void ShowMenu<T>() where T : IMenu
    {
        for (int i = 0; i < m_menuList.Length; i++)
        {
            IMenu menu = m_menuList[i];
            if(menu is T)
            {
                menu.Show();
            }
            else
            {
                menu.Hide();
            }            
        }
    }

    internal Text GetLevelConditionView()
    {
        UIPanelGame game = m_menuList.Where(x => x is UIPanelGame).Cast<UIPanelGame>().FirstOrDefault();
        if (game)
        {
            return game.LevelConditionView;
        }

        return null;
    }

    internal void ShowPauseMenu()
    {
        m_gameManager.SetState(GameManager.eStateGame.PAUSE);
    }

    internal void LoadLevelMoves()
    {
        m_gameManager.LoadLevel(GameManager.eLevelMode.MOVES);
    }

    internal void LoadLevelTimer()
    {
        m_gameManager.LoadLevel(GameManager.eLevelMode.TIMER);
    }

    internal void ShowGameMenu()
    {
        m_gameManager.SetState(GameManager.eStateGame.GAME_STARTED);
    }
}
