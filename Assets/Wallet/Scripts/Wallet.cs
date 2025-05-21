using System;
using System.Collections.Generic;

public class Wallet
{
	public event Action<ItemsType, int> Changed;

	private Dictionary<ItemsType, int> _items;
	private int _maxAmount;

	public Wallet(int maxAmount)
	{
		_maxAmount = maxAmount;
		_items = new Dictionary<ItemsType, int>();

		_items.Add(ItemsType.Coins, 0);
		_items.Add(ItemsType.Diamonds, 0);
		_items.Add(ItemsType.Energie, 0);
	}

	public void Add(ItemsType type, int valueToAdd)
	{
		if (_items.ContainsKey(type) == false)
			return;

		int currentAmount = _items[type] + valueToAdd;

		if (currentAmount < _maxAmount)
			_items[type] = currentAmount;

		if (currentAmount >= _maxAmount)
			_items[type] = _maxAmount;

		Changed?.Invoke(type, _items[type]);
	}

	public void Remove(ItemsType type, int valueToRemove)
	{
		if (_items.ContainsKey(type) == false)
			return;

		int currentAmount = _items[type] - valueToRemove;

		if (currentAmount > 0)
			_items[type] = currentAmount;

		if (currentAmount <= 0)
		{
			currentAmount = 0;
			_items[type] = 0;
		}

		Changed?.Invoke(type, _items[type]);
	}

	public int CurrentAmount(ItemsType type)
	{
		if (_items.ContainsKey(type))
			return _items[type];

		return default(int);
	}
}
