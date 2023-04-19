using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    private HashSet<string> keycards = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKeycard(string keycardID)
    {
        keycards.Add(keycardID);
    }

    public bool HasKeycard(string keycardID)
    {
        return keycards.Contains(keycardID);
    }
}
