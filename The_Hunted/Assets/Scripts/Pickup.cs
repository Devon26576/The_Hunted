using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public int pointValue = 1;

    // Start is called before the first frame update
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.UpdateScore(pointValue);
            GameManager.Instance.totalPickups -= 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
      transform.Rotate(new Vector3(15, 30, 45)* Time.deltaTime);  
    }
}
