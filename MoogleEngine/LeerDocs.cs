using System.IO;
using System;
namespace MoogleEngine;

//Clase que lee los Docs
public static class LeerDocs{

    //Lista que contendra todas las palabras repetidas tantas veces como docs en los q aparezca
    //Funcion que lee los Docs
    public static void GetData(){
        string path = "../Content/";
        string[] files = Directory.GetFiles(path, "*.txt");
        foreach(string file in files){
            string text = "."+File.ReadAllText(file).ToLower()+".";
            //Creo una lista con todas las palabras del texto
            List<string> listWords = (Utils.MakeList(text).ToList());
            //Creo un Vector por cada documento (Al crearse se guarda en mi matriz de docs)
            Vector v = new Vector(
                file,
                listWords
            );
        }
    }
    
        
}