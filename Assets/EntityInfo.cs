using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EntityInfo : MonoBehaviour
{
    public EntityMode entityMode = EntityMode.Planet;

    public float size;
    public float heat;

    public float rock;
    public float water;
    public float oxygen;
    public float iron;

    public SpriteRenderer glow;

    private Sprite smallProto;
    private Sprite proto;

    public Resources resources;

    private SpriteRenderer sr;

    private EntityInfo nearestObject;

    private void Awake()
    {
        resources = new Resources(rock, water, oxygen, iron);
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        smallProto = UnityEngine.Resources.Load<Sprite>("Small Protoplanet");
        proto = UnityEngine.Resources.Load<Sprite>("Protoplanet");

        StartCoroutine(DissapateHeat());
    }

    private void Update()
    {
        if (entityMode == EntityMode.Planet)
        {
            ManageHeatRange();
            ManagePlanetType();
        }
        else if (entityMode == EntityMode.Material)
        {
            ManageMaterialColor();
        }

        ScalePlanet();
    }

    private void ManageHeatRange()
    {
        if (heat < 0)
            heat = 0;

        if (heat > 100)
            heat = 100;

        sr.color = new Color(1, 1 - (heat / 255), 1 - (heat / 100));
        glow.color = new Color(1, 1, 1, heat / 100);
    }

    private void ManagePlanetType()
    {
        if (size < 10)
            sr.sprite = smallProto;
        else if (size < 100)
            sr.sprite = proto;
    }

    private void ScalePlanet()
    {
        transform.localScale = Vector3.one * size;
    }

    private void ManageMaterialColor()
    {
        if (resources.water == 1)
            sr.color = Color.blue;
        else if (resources.oxygen == 1)
            sr.color = Color.cyan;
        else if (resources.iron == 1)
            sr.color = Color.yellow;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EntityInfo ei = other.GetComponent<EntityInfo>();

        if (ei != null)
        {
            if (ei.size > size)
            {
                ei.heat += (size / ei.size) * 100;
                ei.size += size / 2;
                ei.resources += resources;
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator DissapateHeat()
    {
        while (true)
        {
            bool b = true;

            if ((size >= 10 && size < 100) && heat <= 50)
                b = false;

            if (b)
                heat--;
            yield return new WaitForSeconds(1);
        }
    }
}

public enum EntityMode
{
    Planet, Material
}