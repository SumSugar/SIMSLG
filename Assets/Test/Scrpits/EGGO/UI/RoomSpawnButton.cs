﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomSpawnButton : MonoBehaviour {
    /// <summary>
    /// The text attached to the button
    /// </summary>
    public Text buttonText;

    public Image towerIcon;

    public Button buyButton;

    public Image energyIcon;

    public Color energyDefaultColor;

    public Color energyInvalidColor;

    /// <summary>
    /// Fires when the button is tapped
    /// </summary>
    public event Action<Room> buttonTapped;

    /// <summary>
    /// Fires when the pointer is outside of the button bounds
    /// and still down
    /// </summary>
    public event Action<Room> draggedOff;

    /// <summary>
    /// The tower controller that defines the button
    /// </summary>
    Room m_Room;

    ///// <summary>
    ///// Cached reference to level currency
    ///// </summary>
    //Currency m_Currency;

    /// <summary>
    /// The attached rect transform
    /// </summary>
    RectTransform m_RectTransform;

    /// <summary>
    /// Checks if the pointer is out of bounds
    /// and then fires the draggedOff event
    /// </summary>
    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(m_RectTransform, eventData.position))
        {
            if (draggedOff != null)
            {
                draggedOff(m_Room);
            }
        }
    }

    /// <summary>
    /// The click for when the button is tapped
    /// </summary>
    public void OnClick()
    {
        if (buttonTapped != null)
        {
            buttonTapped(m_Room);
        }
    }

    /// <summary>
    /// Define the button information for the tower
    /// </summary>
    /// <param name="towerData">
    /// The tower to initialize the button with
    /// </param>
    public void InitializeButton(Room RoomrData)
    {
        m_Room = RoomrData;

        UpdateButton();
    }

    /// <summary>
    /// Cache the rect transform
    /// </summary>
    protected virtual void Awake()
    {
        m_RectTransform = (RectTransform)transform;
    }

    /// <summary>
    /// Update the button's button state based on cost
    /// </summary>
    void UpdateButton()
    {
        //if (m_Currency == null)
        //{
        //    return;
        //}

        //// Enable button
        //if (m_Currency.CanAfford(m_Tower.purchaseCost) && !buyButton.interactable)
        //{
        //    buyButton.interactable = true;
        //    energyIcon.color = energyDefaultColor;
        //}
        //else if (!m_Currency.CanAfford(m_Tower.purchaseCost) && buyButton.interactable)
        //{
        //    buyButton.interactable = false;
        //    energyIcon.color = energyInvalidColor;
        //}
    }
}