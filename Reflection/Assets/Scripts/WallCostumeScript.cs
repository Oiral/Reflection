using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCostumeScript : MonoBehaviour {
    
    private void Awake()
    {
        Instantiate(CostumeManager.instance.WallCostumes[Random.Range(0, CostumeManager.instance.WallCostumes.Count)], transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
