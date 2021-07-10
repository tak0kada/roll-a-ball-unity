using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float acceleration = 10;
    private Vector3 forceDir;
    private Rigidbody rb;
    private int count;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI winText;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText(0);
        winText.gameObject.SetActive(false);
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        forceDir = new Vector3(inputVector.x, 0.0f, inputVector.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);

            ++count;
            SetCountText(count);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(forceDir * acceleration);
    }

    private void SetCountText(int count)
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            countText.gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
        }
    }
}
