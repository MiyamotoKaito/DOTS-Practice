using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/// <summary>
/// アップデートのタイミングを明示的に呼び出し
/// 他のUpdateよりも先に実行したいから
/// </summary>
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct SpawnSystem : ISystem
{
    /// <summary>
    /// このシステムはConfigコンポーネントが存在する場合だけ実行される
    /// </summary>
    /// <param name="state"></param>
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
    }
    public void OnUpdate(ref SystemState state)
    {
        //ワールド内にたった一つだけ存在するConfigコンポーネントを取得する
        var config = SystemAPI.GetSingleton<Config>();
        //prefabのインスタンス処理
        var instances = state.EntityManager.Instantiate(
            config.Character,
            config.SpawnCount,
            Allocator.Temp
            );

        var rand = new Random(config.RandomSeed);
        foreach (var entity in instances)
        {
            var xform = SystemAPI.GetComponentRW<LocalTransform>(entity);
            var dancer = SystemAPI.GetComponentRW<Dancer>(entity);
            var walker = SystemAPI.GetComponentRW<Walker>(entity);

            xform.ValueRW = LocalTransform.FromPositionRotation(
                rand.NextOnDisk() * config.SpawnRadius,
                rand.NextYRotation()
                );

            dancer.ValueRW = Dancer.Random(rand.NextUInt());
            walker.ValueRW = Walker.Random(rand.NextUInt());
        }

        state.Enabled = false;
    }
}
