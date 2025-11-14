using Unity.Entities;
using UnityEngine;

public class ConfigAuthoring : MonoBehaviour
{
    [SerializeField]
    private GameObject _character;
    [SerializeField]
    private float _spawnRadius;
    [SerializeField]
    private int _spawnCount;
    [SerializeField]
    private int _randomSeed;
}
public struct Config : IComponentData
{
    public Entity Character;
    public float SpawnRadius;
    public int SpawnCount;
    public int RandomSeed;
}