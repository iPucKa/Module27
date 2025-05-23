using System;
using System.Collections.Generic;

public class EnemyService
{
	private Dictionary<Enemy, Func<bool>> _enemiesCollection = new Dictionary<Enemy, Func<bool>>();
	
	public int EnemiesCount => _enemiesCollection.Count;

	public void AddEnemyTo(Enemy enemy, Func<bool> destroyCondition)
	{
		_enemiesCollection.Add(enemy, destroyCondition);
	}

	public void Update(float deltatime)
	{
		foreach (KeyValuePair<Enemy, Func<bool>> enemy in _enemiesCollection)
		{
			if (enemy.Key != null)
			{
				if (enemy.Value.Invoke())
				{
					_enemiesCollection.Remove(enemy.Key);
					break;
				}
			}				
		}
	}
}
