using System.Collections;

public interface IPeriodicallyHandler
{
    float lifeTime { get; set; }
    float spawnTime { get; set; }
    IPeriodicallyExecutor executor { get; set; }
    void Upgrade(float lifeTime, float spawntime);
    IEnumerator Spawner();
}