using System.IO;
using System;
namespace MoogleEngine;
static class Utils{
    //Dado un string devuelve una Lista con cada palabra sin signos de puntuacion
    public static List<string> MakeList(string text){
        char[] specialChars = {'!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
        ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~', '¡', '¢',
        '£', '¤', '¥', '¦', '§', '¨', '©', 'ª', '«', '¬', '®', '¯', '°', '±', '²', '³', '´', 'µ', '¶', '·',
        '¸', '¹', 'º', '»', '¼', '½', '¾', '¿', '×', '÷',' ','\n'};
        return text.ToLower().Split(specialChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    //Dado un texto encuentra el punto anterior a la posicion dada
    public static int PrevDot(int pos, string text){
        pos = Math.Max(pos - 20, 0);
        if(pos == 0) return 0;
        int pointPos = text.Substring(pos, 20).IndexOf('.');
        if(pointPos != -1)
            return pos + pointPos+1;
        else
            return PrevDot(pos, text);
        
    }
    //Dado un texto encuentra el punto siguiente a la posicion dada
    public static int NextDot(int pos, string text){
        pos = Math.Min(pos, text.Length-1);
        int pointPos = ((text+".").Substring(pos)).IndexOf('.')-1;
        return pointPos + pos;
    }
    //Dada una palabra calcula el IDF
    public static double CalculateIDF(string w)
    {    
        //En este punto IDF contiene la cantidad de docs en los que se encuentra cada palabra
        int cont = Matriz.IDF.ContainsKey(w)? Matriz.IDF[w] : 0;
        double idf = cont != 0? Math.Log((double) Matriz.matrizVectores.Count()/cont) : 0;
        //Si el idf es menor o igual a 1 la palabra no es importante
        if(idf > 1){
            return idf;
        }else{
            return 0;
        }
    }
    public static double CalculateTF(Vector v, string w){
        return (double)v.TFIDF[w]/v.words.Count;
    }
}