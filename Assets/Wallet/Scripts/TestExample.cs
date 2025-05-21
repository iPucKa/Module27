using UnityEngine;

public class TestExample : MonoBehaviour
{
	[SerializeField] private WalletView _walletView;

	private const int MaxAmount = 100;

	private Wallet _wallet;

	private Item _coin;
	private Item _diamond;
	private Item _energie;

	private void Awake()
	{
		_wallet = new Wallet(MaxAmount);
		_walletView.Initialize(_wallet);

		_coin = new Item(ItemsType.Coins);
		_diamond = new Item(ItemsType.Diamonds);
		_energie = new Item(ItemsType.Energie);
	}

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.Alpha1))
			_wallet.Add(_coin.Type, 15);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			_wallet.Remove(_coin.Type, 3);

		if (Input.GetKeyDown(KeyCode.Alpha3))
			_wallet.Add(_diamond.Type, 10);

		if (Input.GetKeyDown(KeyCode.Alpha4))
			_wallet.Remove(_diamond.Type, 2);

		if (Input.GetKeyDown(KeyCode.Alpha5))
			_wallet.Add(_energie.Type, 5);

		if (Input.GetKeyDown(KeyCode.Alpha6))
			_wallet.Remove(_energie.Type, 1);
	}

	public void ShowWallet() => _walletView.gameObject.SetActive(true);

	public void CloseWallet() => _walletView.gameObject.SetActive(false);
}
