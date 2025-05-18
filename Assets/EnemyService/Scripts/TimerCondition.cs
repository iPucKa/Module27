using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCondition : DestroyCondition
{
	private TestExample _test;
	private float _maxTime;
	private float _time;

	public TimerCondition(TestExample coroutineRunner, float maxTime)
	{
		_test = coroutineRunner;
		Timer timer = new Timer(_test);
	}

	public void Update(float deltaTime)
	{
		_time += Time.deltaTime;
	}
}
