using System;
using System.Collections.Generic;

public class EnemyService
{
	private List<Enemy> _enemies;

	private const int MaxCountForCountCondition = 10;

	public EnemyService()
	{
		_enemies = new List<Enemy>();
	}

	public int EnemiesCount => _enemies.Count;


	public void Add(Enemy enemy)
	{
		_enemies.Add(enemy);
	}

	public void Update(float deltatime)
	{
		for (int i = 0; i < _enemies.Count; i++)
		{
			DestroyDeadEnemy(_enemies[i]);
			DestroyMaxCountEnemy(_enemies[i]);
			DestroyTimerEnemy(_enemies[i]);
		}
	}

	private void DestroyDeadEnemy(Enemy enemy)
	{
		Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyType.IsDead && enemy.IsDead);

		if (selectedEnemy != null)
			_enemies.Remove(enemy);
	}

	private void DestroyMaxCountEnemy(Enemy enemy)
	{
		List<Enemy> countConditionEnemies = GetEnemyBy(enemy => enemy.Type == DestroyType.MaxCount);

		if (countConditionEnemies != null)
			if (countConditionEnemies.Count > MaxCountForCountCondition)
			{
				Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyType.MaxCount);

				_enemies.Remove(enemy);
			}
	}

	private void DestroyTimerEnemy(Enemy enemy)
	{
		Enemy selectedEnemy = GetEnemyToDestroy(enemy => enemy.Type == DestroyType.TimeIsOver && enemy.TimeIsOver);
		if (selectedEnemy != null)
			_enemies.Remove(enemy);
	}

	private Enemy GetEnemyToDestroy(Func<Enemy, bool> enemyFilter)
	{
		foreach (Enemy enemy in _enemies)
			if (enemyFilter.Invoke(enemy))
				if (enemy.IsDead)
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
