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
}
