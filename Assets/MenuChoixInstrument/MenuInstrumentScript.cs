using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class MenuInstrumentScript : MonoBehaviour
{

    private List<Instrument> instrumentList;
    private List<GameObject> instrumentMenuBouton;
    public GameObject MenuBoutonPrefabs;
    public GameObject FondBoutonPrefab;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        instrumentList = new List<Instrument>();
        instrumentMenuBouton = new List<GameObject>();

        Instrument melodie = new Instrument();
        melodie.Nom = "mélodie";
        melodie.EmplacementTexture = "IconesInstrument/Inst_Basses";
        melodie.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie.Rythmic = false;
        instrumentList.Add(melodie);

        Instrument melodie5 = new Instrument();
        melodie5.Nom = "mélodie5";
        melodie5.EmplacementTexture = "IconesInstrument/Inst_Basses";
        melodie5.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie5.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie5.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie5.Rythmic = false;
        instrumentList.Add(melodie5);

        Instrument melodie2 = new Instrument();
        melodie2.Nom = "mélodie2";
        melodie2.EmplacementTexture = "IconesInstrument/Inst_Basses";
        melodie2.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie2.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie2.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie2.Rythmic = false;
        instrumentList.Add(melodie2);

        Instrument melodie3 = new Instrument();
        melodie3.Nom = "mélodie3";
        melodie3.EmplacementTexture = "IconesInstrument/Inst_Basses";
        melodie3.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie3.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie3.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie3.Rythmic = false;
        instrumentList.Add(melodie3);

        Instrument melodie4 = new Instrument();
        melodie4.Nom = "mélodie4";
        melodie4.EmplacementTexture = "IconesInstrument/Inst_Basses";
        melodie4.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie4.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie4.EmplacementsMusique.Add("Sounds/Mélodie/mon_morceau_2");
        melodie4.Rythmic = false;
        instrumentList.Add(melodie4);

        Instrument rythme = new Instrument();
        rythme.Nom = "Rythme";
        rythme.EmplacementTexture = "IconesInstrument/Inst_GuitareRock";
        rythme.EmplacementsMusique.Add("Sounds/Rythme/Mon_morceau_3");
        rythme.EmplacementsMusique.Add("Sounds/Rythme/Mon_morceau_3");
        rythme.EmplacementsMusique.Add("Sounds/Rythme/Mon_morceau_3");
        rythme.EmplacementsMusique.Add("Sounds/Rythme/Mon_morceau_3");
        rythme.Rythmic = false;
        instrumentList.Add(rythme);

        Instrument percu = new Instrument();
        percu.Nom = "percu";
        percu.EmplacementTexture = "IconesInstrument/Inst_Batteries";
        percu.EmplacementsMusique.Add("Sounds/Percution/BluesP");
        percu.EmplacementsMusique.Add("Sounds/Percution/BluesP");
        percu.EmplacementsMusique.Add("Sounds/Percution/BluesP");
        percu.EmplacementsMusique.Add("Sounds/Percution/BluesP");
        percu.EmplacementsMusique.Add("Sounds/Percution/BluesP");
        percu.Rythmic = true;
        instrumentList.Add(percu);

        
        Instrument blues = new Instrument();
        blues.Nom = "Blues";
        blues.EmplacementTexture = "IconesInstrument/Inst_Harmonica";
        blues.EmplacementsMusique.Add("Sounds/Blues/Blues1.1");
        blues.EmplacementsMusique.Add("Sounds/Blues/Blues1.2");
        blues.EmplacementsMusique.Add("Sounds/Blues/Blues1.3");
        blues.Rythmic = false;
        instrumentList.Add(blues);
        
        int j = -2;
        int compteurLignes = 1;
        foreach (Instrument i in instrumentList)
        {
            GameObject fond = (GameObject)Instantiate(FondBoutonPrefab, new Vector3((float)(j * 2.6 -1.3), compteurLignes*2, -5), Quaternion.identity);
            fond.transform.parent = gameObject.transform;
            GameObject g = (GameObject)Instantiate(MenuBoutonPrefabs, new Vector3((float)(j * 2.6 - 1.3), compteurLignes*2, -6), Quaternion.identity);
            g.GetComponent<instrumentScript>().Instrument = i;
            g.GetComponent<SpriteRenderer>().sprite = Resources.Load(i.EmplacementTexture, typeof(Sprite)) as Sprite;
            instrumentMenuBouton.Add(g);
            g.transform.parent = gameObject.transform;
            j++;
            if (j == 4 || j == 10 || j == 16)
            {
                compteurLignes--;
                j = -2;
            }
      
        }

    }

}
