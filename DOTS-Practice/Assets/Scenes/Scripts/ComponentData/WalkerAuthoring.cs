using Unity.Entities;
using UnityEngine;

public class WalkerAuthoring : MonoBehaviour
{
    
}
public struct Walker : IComponentData
{
    public float ForwardSpeed;
    public float AngularSpeed;
}