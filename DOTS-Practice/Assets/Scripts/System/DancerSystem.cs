using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/// <summary>
/// SourceGeneratorと共存するためにPartial修飾子を使う
/// </summary>
public partial struct DancerSystem : ISystem
{
    /// <summary>
    /// この関数で動かす
    /// </summary>
    /// <param name="state"></param>
    public void OnUpdate(ref SystemState state)
    {
        var elapsed = (float)SystemAPI.Time.ElapsedTime;

        //RefRO：値の読み取りだけ
        //RefRW：値の読み取りと書き換え
        foreach (var (dancer, xfrom) in
                SystemAPI.Query<RefRO<Dancer>,
                                RefRW<LocalTransform>>())
        {
            //三角関数で揺らす

            //時間を観測
            var t = dancer.ValueRO.Speed * elapsed;
            //時間によって上下運動(バウンス)
            var y = math.abs(math.sin(t)) * 0.1f;
            //左右の傾き
            var bank = math.cos(t) * 0.5f;

            //傾きの回転軸
            var fwd = xfrom.ValueRO.Forward();
            //前方向に傾き回転を作る
            var rot = quaternion.AxisAngle(fwd, bank);
            //回転させた Up ベクトルを計算
            var up = math.mul(rot, math.float3(0, 1, 0));

            //ValueRWを経由してtransformを更新
            xfrom.ValueRW.Position.y = y;
            xfrom.ValueRW.Rotation = quaternion.LookRotation(fwd, up);
        }
    }
}
