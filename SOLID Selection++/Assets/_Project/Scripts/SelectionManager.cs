﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _currentSelectionResponse;

    private Transform _currentSelection;

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _currentSelectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_currentSelection != null) _currentSelectionResponse.OnDeselect(_currentSelection);
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _currentSelectionResponse.OnSelect(_currentSelection);
    }
}