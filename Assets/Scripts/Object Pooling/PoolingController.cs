using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : MonoBehaviour
{
    [SerializeField] 
    private SimpleObjectPooling myPooling;
    [SerializeField] 
    private float fireRate = 1f;
    [SerializeField] 
    private bool isGameStart = false;

    [SerializeField] 
    private float count = 0f;
    [SerializeField] 
    private int countBullets = 0;

    private void Awake()
    {
        myPooling.SetUp(this.transform);
        myPooling.onEnableObject += PrintBulletCount;
    }

    private void OnEnable()
    {
        GameManager.onStartGame += InitObjectPooling;
        GameManager.onEndGame += InitObjectPooling;
    }

    private void OnDisable()
    {
        myPooling.onEnableObject -= PrintBulletCount;
        GameManager.onStartGame += InitObjectPooling;
        GameManager.onEndGame += InitObjectPooling;
    }

    private void FixedUpdate()
    {
        if (isGameStart)
        {
            count += Time.deltaTime;

            if (count > fireRate)
            {
                myPooling.GetObject();
                count = 0;
            }
        }
    }

    public void InitObjectPooling()
    {
        isGameStart = !isGameStart;
    }

    private void PrintBulletCount()
    {
        countBullets++;
    }
}
