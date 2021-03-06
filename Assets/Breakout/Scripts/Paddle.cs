using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5;
    [SerializeField] float xLimit = 12;
    [SerializeField] float bigSizeTime = 10;
    //[SerializeField] GameManager gameManager;
    [SerializeField] float fireRate = 1;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletsTime = 10;
    [SerializeField] Vector3 bulletOffset;
    bool bulletsActive;


    public bool BulletsActive
    {
        get => bulletsActive;
        set
        {
            bulletsActive = value;
            StartCoroutine(ShootBullets());
            Invoke("ResetBulletsActive", bulletsTime);

        }
    }

    void ResetBulletsActive()
    {
        bulletsActive = false;
        GameManager.Instance.powerUpIsActive = false;
    }



    IEnumerator ShootBullets()
    {

        while (BulletsActive)
        {
            Instantiate(bulletPrefab, transform.position + bulletOffset, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
        
    }


    /*void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
             transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }
    }*/


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width/2 ;
            Vector3 movement = Vector3.zero;

            if (touch.position.x < screenHalf && transform.position.x > -xLimit)
            {
                transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
            }
            if (touch.position.x > screenHalf && transform.position.x < xLimit)
            {
                transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
            }
        }

    }





    public void IncreaseSize()
    {
        if (!GameManager.Instance.ballIsOnPlay)
            return;
        Vector3 newSize = transform.localScale;
        newSize.x = 1.2f;
        transform.localScale = newSize;
        StartCoroutine(BackToOriginalSize());
    }

    IEnumerator BackToOriginalSize()
    {
        yield return new WaitForSeconds(bigSizeTime);
        transform.localScale = new Vector3(1, 1, 1);
        GameManager.Instance.powerUpIsActive = false;
    }

}
