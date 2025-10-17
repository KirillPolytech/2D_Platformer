using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.Enemies.FSM;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

public class SlimeStateMachine : GenericFSM
{
    public SlimeStateMachine(
        Slime slime,
        Animator animator,
        EnemiesConfig enemiesConfig,
        EnemyDeathBox enemyDeathBox)
    {
        _states.Add(typeof(SlimeWalkState).ToString(),
            new SlimeWalkState(slime, animator, enemiesConfig, enemyDeathBox));

        _states.Add(typeof(EnemyDeathState).ToString(),
            new SlimeDeathState(animator, slime));
        
        _states.Add(typeof(EnemyActiveState).ToString(),
            new SlimeInitializeState(slime, slime.transform.position));
    }
}