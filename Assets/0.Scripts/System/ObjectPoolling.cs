using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolling<T> : Singleton<ObjectPoolling<T>> where T : MonoBehaviour
{
    protected Dictionary<string, Queue<T>> objectDatas = new Dictionary<string, Queue<T>>();

    public T Get(T type, Transform pos)
    {
        T data;
        string name = type.name;

        if(!objectDatas.ContainsKey(name))
        {
            objectDatas.Add(name, new Queue<T>());
        }

        Queue<T> queue = objectDatas[name];

        if(queue.Count <= 0)
        {
            data = Instantiate(type, pos);
            data.name = name;
        }
        else
        {
            data = queue.Dequeue();
            data.gameObject.SetActive(true);

        }

        data.transform.position = pos.position;
        data.transform.SetParent(Instance.transform);
        return data;
    }

    public void Take(T type)
    {
        string name = type.name;

        if(!objectDatas.ContainsKey(name))
        {
            objectDatas.Add(name, new Queue<T>());
        }

        type.gameObject.SetActive(false);
        objectDatas[name].Enqueue(type);
    }
}
