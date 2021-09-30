using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class ObjectContainer<TEntity> : MonoBehaviour where TEntity: MonoBehaviour
{
    [SerializeField]
    protected List<TEntity> entities = new List<TEntity>();
    public void SetObjects(TEntity[] newEntities)
    {
        CleanObjects();
        foreach (var tile in newEntities)
        {
            entities.Add(tile);
        }
    }

    public void AddObjects(TEntity[] newEntities)
    {
        entities.AddRange(newEntities);
    }
    public TEntity SearchTileByGameObject(GameObject searchObject)
    {
        return entities.FirstOrDefault(entity => entity.gameObject == searchObject);
    }

    private void CleanObjects()
    {
        if (entities == null) return;
        foreach (var entity in entities)
        {
            Destroy(entity.gameObject);       
        }
        entities.Clear();

    }
}