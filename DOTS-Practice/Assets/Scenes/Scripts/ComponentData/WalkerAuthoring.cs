using Unity.Entities;
using UnityEngine;

public class WalkerAuthoring : MonoBehaviour
{
    [SerializeField, Header("前方向に動かす速度")]
    private float _forwardSpeed;
    [SerializeField, Header("角度を変える速度")]
    private float _angularSpeed;
}
public struct Walker : IComponentData
{
    public float ForwardSpeed;
    public float AngularSpeed;
}