using System;
using System.Collections.Generic;
using UnityEngine;

public class TT2NetNetworkDiscovery : MonoBehaviour
{
	public bool running;

	public string broadcastData;

	public event Action DiscoveredPlayersUpdated;

	public List<FriendData> PlayerList { get; private set; } = new List<FriendData>();

	public FriendData GetFriendData(string playerId)
	{
		return PlayerList.Find((FriendData x) => x.playerID == playerId);
	}

	public void StopBroadcast() { running = false; }

	public void Initialize() { }

	public void StartAsServer() { running = true; }

	public void StartAsClient() { running = true; }
}
