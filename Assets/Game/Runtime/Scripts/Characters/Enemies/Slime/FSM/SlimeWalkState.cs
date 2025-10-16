using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

public class SlimeWalkState : IState
{
    private readonly Slime _slime;
    private readonly Animator _animator;
    private readonly EnemiesConfig _enemiesConfig;
    private readonly EnemyDeathBox _enemyDeathBox;

    public SlimeWalkState(
        Slime slime, 
        Animator animator,
        EnemiesConfig enemiesConfig,
        EnemyDeathBox enemyDeathBox)
    {
        _slime = slime;
        _animator = animator;
        _enemiesConfig = enemiesConfig;
        _enemyDeathBox = enemyDeathBox;
    }

    public void Enter()
    {
        _animator.SetFloat(GlobalVariables.VelocityX, 1);

        _enemyDeathBox.OnDeath += OnDeath;
    }

    public void Update()
    {
        _slime.Walk();
    }

    public void Exit()
    {
        _animator.SetFloat(GlobalVariables.VelocityX, 0);
        
        _enemyDeathBox.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        _slime.StateMachine.Enter<EnemyDeathState>();
    }
}