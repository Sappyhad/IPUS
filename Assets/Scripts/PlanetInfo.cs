using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    public string planetName;
    public string SideTitle = "Statistics & More";
    public string Dots = ". . .";
    public string SmallInfo;
    public string BigInfo;
    public List<string> List = new List<string>(new string[11]);
    public List<string> SmallList = new List<string>(new string[7]);
}
