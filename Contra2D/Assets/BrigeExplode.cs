using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigeExplode : MonoBehaviour
{
    [SerializeField] GameObject[] _brigePart = new GameObject[5];
    [SerializeField] GameObject explosionPrefab;
    public int number = 0;
    private IEnumerator _detonation;
    void Start()
    {
        _detonation = detonation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(_detonation);
        }
    }
    IEnumerator detonation()
    {
        while (true)
        {
            GameObject _explotion = Instantiate(explosionPrefab, transform) as GameObject;
            _explotion.transform.position = new Vector3(_brigePart[number].transform.position.x, _brigePart[number].transform.position.y, _brigePart[number].transform.position.z - 0.7f);
            yield return new WaitForSeconds(1f);
            Destroy(_explotion);
            Destroy(_brigePart[number]);
            number++;
            if (number >= 4)
            {
                StopCoroutine(_detonation);
                Destroy(this.gameObject);
            }
            StartCoroutine(_detonation);
        }
    }
}
