using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService
{
	private List<Enemy> _enemies;
	private List<Enemy> _deadConditionEnemies;
	private List<Enemy> _timerConditionEnemies;
	private List<Enemy> _countConditionEnemies;

	private const int MaxCountForCountCondition = 10;
	private const float MaxTime = 15f;

	public EnemyService()
	{
		_enemies = new List<Enemy>();
	}

	public int Count => _enemies.Count;

	public void Update(float deltaTime)
	{
		foreach (Enemy enemy in _enemies)
		{
			DestroyDeadEnemy(enemy);
			DestroyMaxCountEnemy(enemy);
			DestroyTimerEnemy(enemy);
		}		
	}	

	public void Add(Enemy enemy)
	{
		_enemies.Add(enemy);

		//_deadConditionEnemies = GetEnemyBy(enemy => enemy.Type == DestroyTypeCondition.IsDead);
		//_timerConditionEnemies = GetEnemyBy(enemy => enemy.Type == DestroyTypeCondition.TimeIsOver);
		//_countConditionEnemies = GetEnemyBy(enemy => enemy.Type == DestroyTypeCondition.MaxCount);
	}

	

	private void DestroyDeadEnemy(Enemy enemy)
	{
		Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyTypeCondition.IsDead && enemy.IsDead);
		_enemies.Remove(enemy);
	}

	private void DestroyMaxCountEnemy(Enemy enemy)
	{
		List<Enemy> countConditionEnemies = GetEnemyBy(enemy => enemy.Type == DestroyTypeCondition.MaxCount);

		Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyTypeCondition.MaxCount);

		if(countConditionEnemies.Count > MaxCountForCountCondition)
			_enemies.Remove(enemy);
	}

	private void DestroyTimerEnemy(Enemy enemy)
	{
		Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyTypeCondition.TimeIsOver && enemy.TimeIsOver);
		_enemies.Remove(enemy);
	}

	private Enemy GetEnemyToDestroy(Func<Enemy, bool> enemyFilter)
	{
		foreach (Enemy enemy in _enemies)
			if (enemyFilter.Invoke(enemy))
				if(enemy.IsDead)
					return enemy;

		return null;
	}

	private List<Enemy> GetEnemyBy(Func<Enemy, bool> enemyFilter)
	{
		List<Enemy> enemies = new List<Enemy>();

		foreach (Enemy enemy in _enemies)
			if (enemyFilter.Invoke(enemy))
				enemies.Add(enemy);

		return enemies;
	}
}
