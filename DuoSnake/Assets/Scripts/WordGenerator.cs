using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;

public class WordGenerator : MonoBehaviour
{
    public bool isChosen = false;
    public OrderedDictionary sentenceList = new OrderedDictionary(){
        {"The Chicago Bulls won six championships", "I Chicago Bulls hanno vinto sei campionati" },
        {"When I am hungry, I eat food", "Quando ho fame, mangio cibo" },
        {"Sarah found a lizard"  ,"Sarah ha trovato una lucertola" },
        {"I like open parties","Mi piacciono le feste aperte" },
        {"I am a football fan","Sono un tifoso di calcio" },
        {"This is such a relatable mood","Questo è uno stato d'animo così riconoscibile" },
        {"I'm going to Lollapalooza","Sto andando a Lollapalooza" },
        {"The sunset was breathtaking","Il tramonto era mozzafiato" },
        {"You’re getting fat","Stai ingrassando" },
        {"We're coming to get you","Stiamo venendo a prenderti" },
        {"I didn't want to make a big deal about it","Non volevo fare un grosso problema al riguardo" },
        {"He fell behind with his work","È rimasto indietro con il suo lavoro" },
        {"That is fake news","Questa è una notizia falsa" },
        {"I am so happy to see you today","Sono così felice di vederti oggi" },
        {"My daughter does the laundry","Mia figlia fa il bucato" },
        {"Don’t get too excited","Non essere troppo entuisiasta" },
        {"It's an awfully important job","È un lavoro terribilmente importante" },
        {"Can we stop pretending to like kale","Possiamo smetterla di fingere che ci piaccia il cavolo cappuccio" },
        {"I turn off the light", "Spengo la luce" }
        };

    public static string[] randomWordsList = {"metodo", "sapere","bianco","pensare","molecola","filo","profondità",
                                            "completo","fiore","lunghezza", "è ", "cresciuto","ufficio","voi",
                                            "spento","posto","pietra","vecchio","difficoltà","bambini","bugia",
                                            "continuare","anno","ferrovia","separato","salita","credere",
                                            "morte","risposta","gamma","lago","posa","totale","stampa",
                                            "lavaggio","persone","inventare","taglio","monte","migliaia",
                                            "andato","tratto","proprio","bambino","nuovo","gratuito",
                                            "appartamento","rappresentare "};
    public string[] createdSentence = null;

    public string GetSentence() {
        int randomIndex = Random.Range(0, sentenceList.Count - 1);
        string sentence = sentenceList.Cast<DictionaryEntry>().ElementAt(1).Value.ToString();
        Debug.Log(randomIndex);
        return sentence;
    }

}     

