using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
	//private DestroyCondition _destroyCondition;
	private DestroyTypeCondition _destroyCondition;
	private bool _isDead;
	private float _time;
	private float _maxTime;

	public Enemy(DestroyTypeCondition destroyCondition)
	{
		_destroyCondition = destroyCondition;
		_isDead = false;
		_time = 0;
		_maxTime = 20;
	}

	public DestroyTypeCondition Type { get; }
	public bool IsDead => _isDead;
	public bool TimeIsOver => _time > _maxTime;


	public void Kill()
	{
		_isDead = true;
	}

	public void SetTime() => _time = 100;
}
