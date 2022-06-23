using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : MonoSingletonGeneric<ServicePool<T>> where T : class
{
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    public virtual T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(i => i.IsUsed == false);
            if (item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }            
        }

        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> pooledItem = new PooledItem<T>();
        pooledItem.Item = CreateItem();
        pooledItem.IsUsed = true;
        pooledItems.Add(pooledItem);
        return pooledItem.Item;
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        Debug.Log("Returning item");
        pooledItem.IsUsed = false;
    }

    protected virtual T CreateItem()
    {
        return (T) null;
    }
    private class PooledItem<t>
    {
        public t Item;
        public bool IsUsed;
    }
}

