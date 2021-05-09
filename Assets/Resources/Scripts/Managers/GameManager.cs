using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PoolAbleObject m_ShipWreck;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            Debug.LogError("An instance of " + ToString() + " already existed!");
        }
        else
        {
            Instance = this;
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void SpawnShipWreck(Vector3 position, Quaternion rotation)
    {
        GameObject shipWreck = PoolManager.Instance.GetObjectFromPool(m_ShipWreck);
        shipWreck.transform.position = position;
        shipWreck.transform.rotation = rotation;
    }
}
