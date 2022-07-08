using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystemDestroy;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerControls palyer))
        {
            GlobalEventManager.SendCoinTake();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyCoin());
        }
    }
    IEnumerator DestroyCoin()
    {
        var particle = Instantiate(_particleSystemDestroy, transform.position, Quaternion.Euler(-90, 0, 0));
        particle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(particle.gameObject);
        Destroy(gameObject);
    }
}
