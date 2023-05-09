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
        int pointPos = text.Substring(pos, 20).IndexOf(".");
        if(pointPos != -1)
            return pos + pointPos+1;
        else
            return PrevDot(pos, text);
        
    }
    //Dado un texto encuentra el punto siguiente a la posicion dada
    public static int NextDot(int pos, string text){
        if(pos+20 >= text.Length-1) return text.Length-1;
        int pointPos = text.Substring(pos, 20).IndexOf(".");
        if(pointPos != -1)
            return pos + pointPos;
        else
            return NextDot(pos+20, text);
    }
}