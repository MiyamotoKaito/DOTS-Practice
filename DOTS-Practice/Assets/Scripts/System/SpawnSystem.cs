using Unity.Collections;
using Unity.Entities;

/// <summary>
/// アップデートのタイミングを明示的に呼び出し
/// 他のUpdateよりも先に実行したいから
/// </summary>
[UpdateInGroup(typeof(InitializationSystemGroup))]

/// <summary>
/// オブジェクトを生成するシステム
/// </summary>
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
    }
}
