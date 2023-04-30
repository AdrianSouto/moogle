using System.IO;
using System;
namespace MoogleEngine;
public static class LeerDocs{
    public static List<string> words = new List<string>();
    public static void GetData(){
        //Carpeta de los txt
        string path = "../Content/";
        //Obtiene todas las direcciones de los archivos txt en esa carpeta
        string[] files = Directory.GetFiles(path, "*.txt");
        //Mete el todos los textos en un string
        string allText = "";
        foreach(string file in files){
            string text = File.ReadAllText(file).ToLower();
            allText += text;
            List<string> listWords = Utils.RemoveTildes(Utils.MakeList(text).ToList());
            Vector v = new Vector(
                file,
                listWords
            );
        }
        //Creo un array de las palabras sin los caracteres especiales
        words = Utils.RemoveRepeats(Utils.RemoveTildes(Utils.MakeList(allText).ToList()));
        Matriz.CalculateTFIDF();
    }
    
        
}

/*d.TFIDF = d.words.GroupBy(
                    x => x.Value
                    )
                 .ToDictionary(
                    g => g.Key,
                    g => ((double) g.Count())
                );*/