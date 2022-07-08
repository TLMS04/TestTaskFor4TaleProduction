using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private List<GameObject> _coinSpawnPositions = new List<GameObject>();

    private int _coinSpawnPositionIndexOld = -1;
    private GameObject _coin;
    void Start()
    {
        GlobalEventManager.OnCoinTake.AddListener(SpawnCoin);
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        int coinSpawnPositionIndex = Random.Range(0, _coinSpawnPositions.Count);
        if(coinSpawnPositionIndex != _coinSpawnPositionIndexOld)
        {
            var position = _coinSpawnPositions[coinSpawnPositionIndex].transform.position;
            position.y += 1;
            _coin = Instantiate(_coinPrefab, position, Quaternion.identity);
            _coinSpawnPositionIndexOld = coinSpawnPositionIndex;
        }
        else
        {
            SpawnCoin();
        }
    }
}
