using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Ditzelgames;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class WaterFloater : MonoBehaviour
{
    
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public bool AffectDirection = true;
    public bool AttachToSurface = false;
    public Transform[] FloatPoints;
    
    protected Rigidbody _rigidbody;     
    protected Waves Waves;
    
    protected float WaterLine;
    protected Vector3[] WaterLinePoints;
    
    protected Vector3 smoothVectorRotation;
    protected Vector3 TargetUp;
    protected Vector3 centerOffset;

    public Vector3 Center { get { return transform.position + centerOffset; } }
    
    void Awake()
    {
        Waves = FindObjectOfType<Waves>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        
        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++)
            WaterLinePoints[i] = FloatPoints[i].position;
        centerOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;
    }

    void FixedUpdate()
    {
        var newWaterLine = 0f;

        for (int i = 0; i < FloatPoints.Length; i++)
        {
            WaterLinePoints[i] = FloatPoints[i].position;
            WaterLinePoints[i].y = Waves.GetHeight(FloatPoints[i].position);
            newWaterLine += WaterLinePoints[i].y / FloatPoints.Length;
        }

        var waterLineDelta = newWaterLine - WaterLine;
        WaterLine = newWaterLine;

        //_rigidbody.position = new Vector3(_rigidbody.position.x, WaterLine - centerOffset.y, _rigidbody.position.z);
        Vector3 targetPosition = new Vector3(_rigidbody.position.x, WaterLine - centerOffset.y, _rigidbody.position.z);
        _rigidbody.MovePosition(targetPosition);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (FloatPoints == null)
            return;

        for (int i = 0; i < FloatPoints.Length; i++)
        {
            if (FloatPoints[i] == null)
                continue;

            if (Waves != null)
            {
                
                Gizmos.color = Color.red;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.3f);
            }
            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(FloatPoints[i].position, 0.1f);

        }
        
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 1f);
            Gizmos.DrawRay(new Vector3(Center.x, WaterLine, Center.z), TargetUp * 1f);
        }
    }
}
