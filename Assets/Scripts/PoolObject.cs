using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObject : MonoBehaviour {
    private List<GameObject> _objectsPool = new List<GameObject>();
    private bool _init;
    public bool Init => _init;

    private static PoolObject _instance;
    public static PoolObject Instance {
        get {
            if (_instance != null) return _instance;
            
            var instances = FindObjectsOfType<PoolObject>();
                    
            _instance = instances.Length > 0 
                    ? instances[0] 
                    : new GameObject($"{typeof(PoolObject)} (singleton)").AddComponent<PoolObject>();

            return _instance; 
        }
    }

    private Transform _parent;
    private GameObject _prefab;

    public void InitPool(GameObject prefab, Transform parent, float initialNumber) {
        _parent = parent;
        _prefab = prefab;

        for (int i = 0; i < initialNumber; i++) {
            var inst = Instantiate(_prefab, _parent, true);
            inst.SetActive(false);
            _objectsPool.Add(inst);
        }

        _init = true;
    }

    public GameObject Get() {
        while (true) {
            if (_objectsPool.Count <= 0) {
                return Instantiate(_prefab, _parent, true);
            }

            var toCheckInst = _objectsPool.First();
            if (toCheckInst == null) {
                continue;
            }
            
            toCheckInst.SetActive(true);
            _objectsPool.Remove(toCheckInst);
            return toCheckInst;
        }
    }

    public void Destroy(GameObject obj) {
        obj.SetActive(false);
        _objectsPool.Add(obj);
    }
}