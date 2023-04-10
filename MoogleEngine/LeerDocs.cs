using System.IO;
using System;
static class LeerDocs{
    static string[] words = new string[]{};
    public static string[] GetWords(){
        if(words.Length == 0){
            //Carpeta de los txt
            string path = "./Content/";
            //Obtiene todas las direcciones de los archivos txt en esa carpeta
            string[] files = Directory.GetFiles(path, "*.txt");
            //Mete el todos los textos en un string
            string allText = "";
            foreach(string file in files){
                allText += File.ReadAllText(file);
            }
            //Le quito los caracteres especiales al string
            char[] specialChars = {',', '.', ';','"','\'','?','/',':','[',']','{','}','+','=','-','_','(',')','!','@','#','$','%','^','&','*','`','~'};
            string textWithoutSymbols = "";
            foreach(char c in allText){
                if(!specialChars.Contains(c))
                    textWithoutSymbols += c;
                
            }
            //Convierto las palabras separadas por espacio en un array de strings que omite los elementos vacios
            words = textWithoutSymbols.Split(new char[]{' ', '\n'}, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }
        return words;
        
    }
        
}
