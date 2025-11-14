using Unity.Entities;
using UnityEngine;

/// <summary>
/// Walker用のクラス
/// </summary>
public class WalkerAuthoring : MonoBehaviour
{
    [SerializeField, Header("前方向に動かす速度")]
    private float _forwardSpeed;
    [SerializeField, Header("角度を変える速度")]
    private float _angularSpeed;

    /// <summary>
    /// Walkerの変数にWalkerAuthoringの変数の値を変換するBakerクラス
    /// </summary>
    class Baker : Baker<WalkerAuthoring>
    {
        public override void Bake(WalkerAuthoring authoring)
        {
            var data = new Walker()
            {
                ForwardSpeed = authoring._forwardSpeed,
                AngularSpeed = authoring._angularSpeed
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}
/// <summary>
/// コンポーネント
/// </summary>
public struct Walker : IComponentData
{
    public float ForwardSpeed;
    public float AngularSpeed;

    public static Walker Random(uint seed)
    {
        var random = new Unity.Mathematics.Random(seed);
        return new Walker()
        {
            ForwardSpeed = random.NextFloat(0.1f, 0.8f),
            AngularSpeed = random.NextFloat(0.5f, 4)
        };
    }
}