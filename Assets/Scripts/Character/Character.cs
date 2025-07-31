using System.Collections.Generic;
using Spine.Unity;
using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharState _state;
    public CharState State { get { return _state; } set { _state = value; } }
    [SerializeField]
    private CharacterData _charData;
    public CharacterData CharData { get { return _charData; } set { _charData = value; } }

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
     

    }



}
