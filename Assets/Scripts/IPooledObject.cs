using UnityEngine;

public interface IPooledObject
{
    void OnObjectSpawn(float dec, float ttl);
}
