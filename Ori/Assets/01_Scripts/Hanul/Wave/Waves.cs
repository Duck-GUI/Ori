using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public int dimensions = 10;
    public List<Octave> octaves = new List<Octave>();
    public float uvScale = 2f;
    
    protected MeshFilter _meshFilter;
    protected Mesh _mesh;

    private MeshCollider _meshCollider;
    
    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;

        public Octave(Vector2 Speed, Vector2 Scale, float Height, bool alt)
        {
            this.speed = Speed;
            this.scale = Scale;
            this.height = Height;
            this.alternate = alt;
        }
    }

    private void Start()
    {
        _meshCollider = GetComponent<MeshCollider>();

        _mesh = new Mesh();
        _mesh.name = gameObject.name;

        _mesh.vertices = GenerateVerts();
        _mesh.triangles = GenerateTries();
        _mesh.uv = GenerateUVs();
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();

        _meshFilter = gameObject.AddComponent<MeshFilter>();
        _meshFilter.mesh = _mesh;
    }

    private Vector2[] GenerateUVs()
    {
        var uvs = new Vector2[_mesh.vertices.Length];
        
        for (int x = 0; x <= dimensions; ++x)
        {
            for (int z = 0; z <= dimensions; ++z)
            {
                var vec = new Vector2((x / uvScale) % 2, (z / uvScale) % 2);
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1 ? vec.y : 2 - vec.y);
            }
        }

        return uvs;
    }
    
    public float GetHeight(Vector3 position)
    {
        var scale = new Vector3(1 / transform.lossyScale.x, 0, 1 / transform.lossyScale.z);
        var localPos = Vector3.Scale((position - transform.position), scale);

        var p1 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Floor(localPos.z));
        var p2 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Ceil(localPos.z));
        var p3 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Floor(localPos.z));
        var p4 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Ceil(localPos.z));
        
        p1.x = Mathf.Clamp(p1.x, 0, dimensions);
        p1.z = Mathf.Clamp(p1.z, 0, dimensions);
        p2.x = Mathf.Clamp(p2.x, 0, dimensions);
        p2.z = Mathf.Clamp(p2.z, 0, dimensions);
        p3.x = Mathf.Clamp(p3.x, 0, dimensions);
        p3.z = Mathf.Clamp(p3.z, 0, dimensions);
        p4.x = Mathf.Clamp(p4.x, 0, dimensions);
        p4.z = Mathf.Clamp(p4.z, 0, dimensions);

        var max = Mathf.Max(Vector3.Distance(p1, localPos), 
            Vector3.Distance(p2, localPos), 
            Vector3.Distance(p3, localPos), 
            Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        
        var dist = (max - Vector3.Distance(p1, localPos))
                 + (max - Vector3.Distance(p2, localPos))
                 + (max - Vector3.Distance(p3, localPos))
                 + (max - Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        
        var height = _mesh.vertices[index(p1.x, p1.z)].y * (max - Vector3.Distance(p1, localPos))
                   + _mesh.vertices[index(p2.x, p2.z)].y * (max - Vector3.Distance(p2, localPos))
                   + _mesh.vertices[index(p3.x, p3.z)].y * (max - Vector3.Distance(p3, localPos))
                   + _mesh.vertices[index(p4.x, p4.z)].y * (max - Vector3.Distance(p4, localPos));
        
        return height * transform.lossyScale.y / dist;

    }

    private void Update()
    {
        
        var verts = _mesh.vertices;
        for (int x = 0; x <= dimensions; ++x)
        {
            for (int z = 0; z <= dimensions; ++z)
            {
                var y = 0f;
                for (int o = 0; o < octaves.Count; ++o)
                {
                    if (octaves[o].alternate)
                    {
                        var perl = Mathf.PerlinNoise(
                            (x * octaves[o].scale.x) / dimensions, 
                            (z * octaves[o].scale.y) / dimensions) * Mathf.PI * 2f;
                        y += Mathf.Cos(perl + octaves[o].speed.magnitude * Time.time) * octaves[o].height;
                    }
                    else
                    {
                        var perl = Mathf.PerlinNoise(
                            (x * octaves[o].scale.x + Time.time * octaves[o].speed.x) / dimensions, 
                            (z * octaves[o].scale.y + Time.time * octaves[o].speed.y) / dimensions) - 0.5f;
                        y += perl * octaves[o].height;
                    }
                    
                }

                verts[index(x, z)] = new Vector3(x, y, z);
                _mesh.RecalculateNormals();
            }
        }
        
        _mesh.vertices = verts;
        _meshCollider.sharedMesh = _mesh;

    }

    public void WavesGen()
    {
        var verts = _mesh.vertices;
        for (int x = 0; x <= dimensions; ++x)
        {
            for (int z = 0; z <= dimensions; ++z)
            {
                var y = 0f;
                for (int o = 0; o < octaves.Count; ++o)
                {
                        var perl = Mathf.PerlinNoise(
                            (x * octaves[o].scale.x) / dimensions, 
                            (z * octaves[o].scale.y) / dimensions) * Mathf.PI * 2f;
                        y += Mathf.Cos(perl + octaves[o].speed.magnitude * Time.time) * octaves[o].height;
                }

                verts[index(x, z)] = new Vector3(x, y, z);
                _mesh.RecalculateNormals();
            }
        }
        
        _mesh.vertices = verts;
    }
    
    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(dimensions + 1) * (dimensions + 1)];

        for (int x = 0; x <= dimensions; ++x)
            for (int z = 0; z <= dimensions; ++z)
                verts[index(x, z)] = new Vector3(x, 0, z);

        return verts;
        
    }

    private int index(int x, int z)
    {
        return x * (dimensions + 1) + z;
    }
    
    private int index(float x, float z)
    {
        return index((int)x, (int)z);
    }
    
    private int[] GenerateTries()
    {
        var tries = new int[_mesh.vertices.Length * 6];

        for (int x = 0; x < dimensions; ++x)
            for (int z = 0; z < dimensions; ++z)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }

        return tries;
    }
}
