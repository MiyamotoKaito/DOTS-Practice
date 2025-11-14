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
    private uint _randomSeed;

    class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var data = new Config()
            {
                //GetEntityメソッドはゲームオブジェクト型をEntity型に変換できる(重要)
                Character = GetEntity(authoring._character, TransformUsageFlags.Dynamic),
                SpawnRadius = authoring._spawnRadius,
                SpawnCount = authoring._spawnCount,
                RandomSeed = authoring._randomSeed
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
public struct Config : IComponentData
{
    public Entity Character;
    public float SpawnRadius;
    public int SpawnCount;
    public uint RandomSeed;
}