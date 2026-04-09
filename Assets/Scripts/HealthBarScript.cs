using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image fillImage; // assign the "Fill" child
    public Vector3 offset = new Vector3(0, 2f, 0);

    private Transform target;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Follow enemy
        transform.position = target.position + offset;

        // Face camera
        if (mainCamera != null)
        {
            transform.rotation = Quaternion.LookRotation(
                transform.position - mainCamera.transform.position
            );
        }
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    public void SetHealth(float current, float max)
    {
        if (fillImage != null)
        {
            if(current<0) return; //avoid negatives
            float ratio = current / max;
            fillImage.rectTransform.localScale = new Vector3(ratio, .9f, 1f);
        }
    }

    public void Show(bool visible)
    {
        gameObject.SetActive(visible);
    }
}