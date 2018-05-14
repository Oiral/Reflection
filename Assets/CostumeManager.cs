using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeManager : MonoBehaviour
{
    #region instanceManager
    public static CostumeManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public List<GameObject> DefaultTileCostumes;
    public List<GameObject> HoleTileCostumes;
    public List<GameObject> WallCostumes;
    public List<GameObject> BlockTileCostumes;
    public List<GameObject> GoalTileCostumes;
}
