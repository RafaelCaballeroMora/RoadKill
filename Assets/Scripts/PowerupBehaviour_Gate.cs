using System;
using TMPro;
using UnityEngine;

public class PowerupBehaviour_Gate : PowerupBehaviour
{
    public int deltaAttackSpeed = 0;
    [Header("Label Settings")]
    public GameObject labelPrefab;
    public Vector3 labelOffset = new Vector3(0, 2f, 0);
    private TextMeshProUGUI labelText;
    
    public override void Start()
    {
        base.Start();
        if (labelPrefab != null)
        {
            Renderer meshRenderer = GetComponentInChildren<MeshRenderer>();

            // Instantiate label as child
            GameObject labelObj = Instantiate(labelPrefab, transform);

            // Position above the mesh using extents
            labelObj.transform.localPosition = new Vector3(0, meshRenderer.bounds.extents.y - 2f, 0);

            labelText = labelObj.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    
    public override void Update()
    {
        base.Update();
        if (labelText != null)
        {
            labelText.text = deltaAttackSpeed.ToString();

            // Make it face the camera
            labelText.transform.rotation = Camera.main.transform.rotation;
        }
    }
    public override void BeConsumed(PlayerShoot playerHit)
    {
        playerHit.PowerUp("AttackSpeed", deltaAttackSpeed);
        Destroy(gameObject);
    }

    public override void BeHit()
    {
        deltaAttackSpeed ++;
    }
}
