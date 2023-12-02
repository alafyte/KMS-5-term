using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    private double points = 0;
    public TMP_Text pointsText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            ++points;
            pointsText.text = "Очки: " + points;
        }

    }
}
