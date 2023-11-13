using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] 
    private SimpleObjectPooling myPooling;
    [SerializeField] 
    private float speed;
    private Collider[] _collider;

    private bool isSetUp;

    private void OnEnable()
    {
        myPooling.onEnableObject += SetUp;
        GameManager.onEndGame += StopTube;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= SetUp;
        GameManager.onEndGame -= StopTube;
    }

    private void SetUp()
    {
        if (!isSetUp)
        {
            transform.position = RandomPosition(transform.position, 2f);
            isSetUp = true;
        }

        if (_collider == null)
        {
            _collider = GetComponents<Collider>();
        }
    }

    private void Update()
    {
        if (isSetUp)
            transform.position -= Vector3.right * speed * Time.deltaTime;
    }

    private void StopTube()
    {
        if (isSetUp)
        {
            isSetUp = false;
        }

        for (int i = 0; i < _collider.Length; i++)
        {
            _collider[i].enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Collector")
        {
            isSetUp = false;
            myPooling.ObjectReturn(this.gameObject);
        }
    }

    private Vector3 RandomPosition(Vector3 currentPosition, float range)
    {
        float rnd = Random.Range(currentPosition.y + range, currentPosition.y - range);
        currentPosition.y = rnd;
        return currentPosition;
    }
}
