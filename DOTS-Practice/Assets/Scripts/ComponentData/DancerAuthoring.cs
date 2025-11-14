using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// DancerをBakeするだけのクラス
/// </summary>
public class DancerAuthoring : MonoBehaviour
{
    public float Speed;
    class Baker : Baker<DancerAuthoring>
    {
        public override void Bake(DancerAuthoring authoring)
        {
            var data = new Dancer() { Speed = authoring.Speed };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
public struct Dancer : IComponentData
{
    public float Speed;

    public static Dancer Random(uint seed)
    => new Dancer() { Speed = new Unity.Mathematics.Random(seed).NextFloat(1, 8) };
}