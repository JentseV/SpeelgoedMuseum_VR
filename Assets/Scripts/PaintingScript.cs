using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Renderer paintingRenderer;
    [SerializeField] private Renderer frameRenderer;
    public float maxDistance = 10f;
    public float fadeDistance = 5f;
    public float fadeSpeed = 1.5f;

    private float initialAlpha;
    private float distanceToPlayer;

    void Start()
    {
        paintingRenderer = GetComponent<Renderer>();
        frameRenderer = GetComponent<Renderer>();
        initialAlpha = paintingRenderer.material.color.a;
    }

    void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("D:" + distanceToPlayer);
            Debug.Log("D/:" + (distanceToPlayer - fadeDistance) / (maxDistance));
            Debug.Log("---");
            float fadeAmount = Mathf.Clamp01((distanceToPlayer - fadeDistance) / (maxDistance));

            float targetAlpha = Mathf.Lerp(0f, initialAlpha, fadeAmount);
            Color frameCollor = frameRenderer.material.color;
            Color currentColor = paintingRenderer.material.color;
            float newAlpha = Mathf.Lerp(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
            paintingRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            frameRenderer.material.color = new Color(frameCollor.r, frameCollor.g, frameCollor.b, newAlpha);

        }
    }
}
