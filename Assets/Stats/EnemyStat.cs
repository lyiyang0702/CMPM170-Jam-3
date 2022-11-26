using UnityEngine;

public class EnemyStat : CharacterStat
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
