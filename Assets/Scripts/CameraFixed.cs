using UnityEngine;

public class CameraFixed : MonoBehaviour
{
    public float targetWidth = 16f; // ancho deseado en unidades
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float targetAspect = targetWidth / 9f; // 16:9 de referencia
        float windowAspect = (float)Screen.width / Screen.height;

        cam.orthographicSize = targetWidth / 2f / windowAspect;
    }
}
