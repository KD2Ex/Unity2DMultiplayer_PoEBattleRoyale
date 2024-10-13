using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new();

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 pos, Quaternion rot)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

        if (pool == null)
        {
            pool = new PooledObjectInfo { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();;


        if (spawnableObj == default)
        {
            spawnableObj = Instantiate(objectToSpawn, pos, rot);
        }
        else
        {
            spawnableObj.transform.position = pos;
            spawnableObj.transform.rotation = rot;
            pool.InactiveObjects.Remove(spawnableObj);

            Debug.Log(spawnableObj.transform.position);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnToPool(GameObject go)
    {
        string goName = go.name.Substring(0, go.name.Length - 7);

        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

        if (pool == null)
        {
            Debug.LogWarning($"Object is not in pool {go.name}");
        }
        else
        {
            go.SetActive(false);
            pool.InactiveObjects.Add(go);
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new();
}
