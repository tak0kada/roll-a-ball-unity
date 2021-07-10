using System;
using System.IO;
using UnityEngine;


public class PickUps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>(Path.Combine("Prefabs", "PickUp"));
        if (prefab == null)
        {
            Debug.LogError("PickUp prefab not loaded.");
            return;
        }

        for (int i = 0; i < 12; ++i)
        {
            float r = 6;
            float theta = Mathf.PI / 6;
            Vector3 pos = new Vector3(r * Mathf.Cos(i * theta), 0.5f, r * Mathf.Sin(i * theta));
            var obj = Instantiate(prefab, pos, new Quaternion());
            obj.transform.parent = transform;
        }
    }
}
