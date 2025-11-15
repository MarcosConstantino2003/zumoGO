using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FitBackgroundToCamera : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect + 5;

        Vector3 scale = transform.localScale;

        scale.x = width / sr.bounds.size.x;
        scale.y = height / sr.bounds.size.y;

        transform.localScale = scale;
    }
}
