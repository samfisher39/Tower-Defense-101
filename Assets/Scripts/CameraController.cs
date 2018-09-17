using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = false;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minZ = -10f;
    public float maxZ = 80f;
    public float minRotX = 25f;
    public float maxRotX = 90f;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (transform.position.y == maxY && scroll < 0)
            return;
        if (transform.position.y == minY && scroll > 0)
            return;
        Vector3 pos = transform.position;
        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.z -= scroll * 700 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;

        Vector3 rot = transform.rotation.eulerAngles;
        rot.x = Mathf.Clamp(Mathf.Pow((Mathf.Asin(transform.position.y / (maxY + 20)) / Mathf.PI * 180) / 90, 0.35f) * 90, minRotX, maxRotX);
        transform.rotation = Quaternion.Euler(rot);
    }
}
