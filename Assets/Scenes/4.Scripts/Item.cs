using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int atk;
    [SerializeField] private int def;
    [SerializeField] public Sprite Icon { get;  set; }
    public bool IsEquipped { get; set; }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int ATK { get { return atk; } }
    public int DEF { get { return def; } }

    public void SetData(string name, string description, int atk, int def, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.atk = atk;
        this.def = def;
        Icon = icon;
    }
}
