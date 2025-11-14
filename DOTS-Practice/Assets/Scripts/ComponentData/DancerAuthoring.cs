using Unity.Entities;
using UnityEngine;

/// <summary>
/// Dancer‚ðBake‚·‚é‚¾‚¯‚ÌƒNƒ‰ƒX
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
}