using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    [Header("Player Boost Amounts")]

    [SerializeField]
    private float _speedBoost = 2.0f;
    [SerializeField]
    private float _jumpBoost = 2.0f;
    [SerializeField]
    private int _attackBoost = 5;
    #endregion


}
