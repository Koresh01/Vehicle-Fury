using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

/// <summary>
/// Активирует все карты ввода от пользователя.
/// </summary>
public class ActionMapsController : MonoBehaviour
{
    public InputActions inputActions;

    [SerializeField] List<Map> maps;

    void Awake()
    {
        inputActions = new InputActions();
        InitializeMaps();
    }

    void InitializeMaps()
    {
        foreach (var map in maps)
        {
            map.InitializeInputActions(inputActions);
        }
    }

    private void Start()
    {
        foreach (var map in maps)
        {
            map.gameObject.SetActive(true);
        }
    }
}
