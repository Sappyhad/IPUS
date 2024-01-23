using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoFull : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text sideTitleText;
    public TMP_Text dotsText;
    public TMP_Text smallInfoText;
    public TMP_Text bigListText;
    public TMP_Text SmallList;
    public TMP_Text bigInfoText;

    public void DisplayPlanetInfoBrief(PlanetInfo planetInfo)
    {
        // Wyświetl informacje na panelu InfoFull
        if (titleText != null){
            titleText.text = planetInfo.planetName;
        }
        else
        {
            Debug.Log("titleText is null");
        }

        if (sideTitleText != null){
            sideTitleText.text = planetInfo.SideTitle;
        }
        else
        {
            Debug.Log("sideTitleText is null");
        }

        if (dotsText != null){
            dotsText.text = planetInfo.Dots;
        }
        else
        {
            Debug.Log("dotsText is null");
        }

        if (smallInfoText != null){
            smallInfoText.text = planetInfo.SmallInfo;
        }
        else
        {
            Debug.Log("smallInfoText is null");
        }

        if (SmallList != null){
            SmallList.text = string.Join("\n", planetInfo.SmallList);
        }
        else
        {
            Debug.Log("SmallList is null");
        }

        if (bigListText != null){
            bigListText.text = string.Join("\n", planetInfo.List);
        }
        else
        {
            Debug.Log("bigListText is null");
        }

        if (bigInfoText != null){
            bigInfoText.text = planetInfo.BigInfo;
        }
        else
        {
            Debug.Log("bigInfoText is null");
        }
    }

    public void DisplayPlanetInfoAll(PlanetInfo planetInfo)
    {
        if (planetInfo == null){Debug.Log("planetInfo is null");}
        
        // Wyświetl informacje na panelu InfoFull
        if (titleText != null){
            titleText.text = planetInfo.planetName;
        }
        else
        {
            Debug.Log("titleText is null");
        }

        if (sideTitleText != null){
            sideTitleText.text = planetInfo.SideTitle;
        }
        else
        {
            Debug.Log("sideTitleText is null");
        }

        if (dotsText != null){
            dotsText.text = planetInfo.Dots;
        }
        else
        {
            Debug.Log("dotsText is null");
        }

        if (smallInfoText != null){
            smallInfoText.text = planetInfo.SmallInfo;
        }
        else
        {
            Debug.Log("smallInfoText is null");
        }

        if (SmallList != null){
            SmallList.text = string.Join("\n", planetInfo.SmallList);
        }
        else
        {
            Debug.Log("SmallList is null");
        }

        if (bigListText != null){
            bigListText.text = string.Join("\n", planetInfo.List);
        }
        else
        {
            Debug.Log("bigListText is null");
        }

        if (bigInfoText != null){
            bigInfoText.text = planetInfo.BigInfo;
        }
        else
        {
            Debug.Log("bigInfoText is null");
        }
    }
}
