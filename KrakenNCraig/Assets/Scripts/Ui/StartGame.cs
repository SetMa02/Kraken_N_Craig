using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private KrakenMovement _kraken;
    [SerializeField] private CanvasGroup _menuGroup;
    [SerializeField] private Button _button;

    private void Start()
    {
        _kraken.enabled = false;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartPlay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartPlay);
    }

    private void StartPlay()
    {
        _kraken.enabled = true;
        _menuGroup.blocksRaycasts = false;
        _menuGroup.alpha = 0;
    }
}
