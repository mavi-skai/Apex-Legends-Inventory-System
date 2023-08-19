using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField]
    private Transform PlayerTransform;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    

    public Vector3 GetPlayerTransform()
    {
        return PlayerTransform.transform.position;
    }
    
}
