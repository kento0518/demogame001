using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STOP,
        LEFT,
        RIGHT,
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;
    float speed;
    float verticalSpeed; // 上下移動のための速度
    Rigidbody2D rigidbody2D;

    // ダブルタップ関連
    private float lastTapTime = 0f;  // 最後にタップされた時刻
    private float doubleTapThreshold = 0.3f;  // ダブルタップとして認識する時間の間隔（秒）
    private bool isDoubleTap = false;  // ダブルタップが認識されたかどうか

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical"); // 上下方向の入力

        if (x == 0)
        {
            direction = DIRECTION_TYPE.STOP;
        }
        else if (x > 0)
        {
            direction = DIRECTION_TYPE.RIGHT;
            HandleDoubleTap(DIRECTION_TYPE.RIGHT);
        }
        else if (x < 0)
        {
            direction = DIRECTION_TYPE.LEFT;
            HandleDoubleTap(DIRECTION_TYPE.LEFT);
        }

        // y軸の入力で上下移動の速度を設定
        verticalSpeed = y * 3; // 上下移動の速度を変更（3は任意のスピード）
    }

    void FixedUpdate()
    {
        // 横方向の処理
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;

            case DIRECTION_TYPE.RIGHT:
                if (isDoubleTap)
                {
                    speed = 10; // ダブルタップで素早く移動
                }
                else
                {
                    speed = 3; // 通常移動
                }
                transform.rotation = Quaternion.Euler(0, 0, 0); // 右向き
                break;

            case DIRECTION_TYPE.LEFT:
                if (isDoubleTap)
                {
                    speed = -10; // ダブルタップで素早く移動
                }
                else
                {
                    speed = -3; // 通常移動
                }
                transform.rotation = Quaternion.Euler(0, 180, 0); // 左向き
                break;
        }

        // プレイヤーの移動
        rigidbody2D.velocity = new Vector2(speed, verticalSpeed);
    }

    // ダブルタップ検出処理
    void HandleDoubleTap(DIRECTION_TYPE direction)
    {
        float currentTime = Time.time;

        // 最後のタップから設定した時間以内に同じ方向の入力があればダブルタップ
        if (currentTime - lastTapTime <= doubleTapThreshold)
        {
            isDoubleTap = true;
        }
        else
        {
            isDoubleTap = false;
        }

        lastTapTime = currentTime;
    }
}
