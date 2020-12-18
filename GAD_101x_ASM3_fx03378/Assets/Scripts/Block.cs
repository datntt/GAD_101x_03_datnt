using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textHP;
    [SerializeField]
    private float blockHP = 99;
    [SerializeField]
    private float fallingSpeed = 3.0f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        textHP.text = blockHP.ToString();
        timer = fallingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Mỗi 3s khối Block sẽ di chuyên xuống 1 lần.
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            timer = fallingSpeed;
        }
    }

    public void OnDamaged(float damage)
    {
        // hp của block sẽ giảm bằng lượng damage của đạn
        blockHP -= damage;
        // cập nhật lại hiển thị hp của block
        textHP.text = blockHP.ToString();
        // Nếu hp nhỏ hơn hoặc bằng 0 thì destroy
        if (blockHP <= 0)
        {
            Destroy(gameObject);
            BlockController.instance.blockCount -= 1;
            if(BlockController.instance.blockCount <= 0)
            {
                BlockController.instance.ActiveWinPopUp();
            }
        }

    }
}
