using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject background;

    void Start() {
        transform.position = new Vector3(0, 3, -10);
    }

    void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        int edgeScrollSize = 30;

        if (Input.mousePosition.x < edgeScrollSize && transform.position.x > -20) {
            inputDir.x -= 0.5f;
        }
        if (Input.mousePosition.x > Screen.width - edgeScrollSize && transform.position.x < 50) {
            inputDir.x += 0.5f;
        }

        Vector3 moveDir = transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        background.transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
