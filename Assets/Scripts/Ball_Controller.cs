using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text ballCountText;

    [SerializeField] private List<GameObject> balls;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;

    private float horizontal;

    [SerializeField] private GameObject ballPrefab;

    void Start()
    {
        UpdateBallCountText();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalBallMove();
        ForwardBallMove();
    }

    private void HorizontalBallMove()
    {
        float newX;
        if(Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxisRaw("Mouse X");
        }else
        {
            horizontal = 0;
        }

        newX = transform.position.x + (horizontal * horizontalSpeed * Time.deltaTime);
        newX = Mathf.Clamp(newX,-horizontalLimit,horizontalLimit);

        transform.position = new Vector3 (
            newX,
            transform.position.y,
            transform.position.z);
    }

    private void ForwardBallMove()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SteckBall"))
        {
            AddToStack(other.gameObject);
            UpdateBallCountText();
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            int gateNuber = other.gameObject.GetComponent<Gate_Controller>().GetGateNuber();

            if (gateNuber > 0){
                IncreaseBall(gateNuber);
                UpdateBallCountText();
            }
            else if (gateNuber < 0){
                DecreaseBall(gateNuber);
                UpdateBallCountText();
                if (balls.Count == 0)
                {
                    gameManager.ShowLoseArea();
                }
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.ShowWinArea();
        }
    }

    private void IncreaseBall(int gateNuber)
    {
        for (int i = 0; i < gateNuber; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            AddToStack(ball);
        }
    }

    private void DecreaseBall(int gateNuber)
    {
        int listCount = balls.Count - 1;
        for (int i = listCount; i > listCount + gateNuber; i--)
        {
            if (i >= 0)
            {
                balls[i].SetActive(false);
                balls.RemoveAt(i);
            }else
            {
                break;
            }
        }
    }

    private void UpdateBallCountText()
    {
        ballCountText.text = balls.Count.ToString();
    }

    private void AddToStack(GameObject ball)
    {
        ball.transform.SetParent(transform);
        ball.GetComponent<SphereCollider>().enabled = false;
        ball.transform.localPosition = new Vector3(0f, 0f, balls[balls.Count - 1].transform.localPosition.z - 1);
        balls.Add(ball);
    }
}
