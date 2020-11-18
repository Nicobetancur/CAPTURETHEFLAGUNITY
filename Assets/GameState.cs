using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Singleton
    public PlayerController pCont;

    public static GameState instance;

    void Awake()
    {
        instance = this;
    }
    
    #endregion

    public GameObject BlueP;
    public GameObject RedP;
}
