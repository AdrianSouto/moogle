using System.IO;
using System;
namespace MoogleEngine;
static class Utils{
    public static List<string> MakeList(string text){
        char[] specialChars = {'!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
        ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~', '¡', '¢',
        '£', '¤', '¥', '¦', '§', '¨', '©', 'ª', '«', '¬', '®', '¯', '°', '±', '²', '³', '´', 'µ', '¶', '·',
        '¸', '¹', 'º', '»', '¼', '½', '¾', '¿', '×', '÷',' ','\n'};
        return text.ToLower().Split(specialChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    public static int PrevDot(int pos, string text){
        pos = Math.Max(pos - 20, 0);
        if(pos == 0) return 0;
        int pointPos = text.Substring(pos, 20).IndexOf(".");
        if(pointPos != -1)
            return pos + pointPos+1;
        else
            return PrevDot(pos, text);
        
    }
    public static int NextDot(int pos, string text){
        if(pos+20 >= text.Length-1) return text.Length-1;
        int pointPos = text.Substring(pos, 20).IndexOf(".");
        if(pointPos != -1)
            return pos + pointPos;
        else
            return NextDot(pos+20, text);
    }
    public static List<string> RemoveTildes(List<string> l){
        for(int x = 0; x < l.Count();x++){
            string ns = "";
            foreach(char c in l[x]){
                switch(c){
                    case 'á':
                        ns+='a';
                        break;
                    case 'é':
                        ns+='e';
                        break;
                    case 'í':
                        ns+='i';
                        break;
                    case 'ó':
                        ns+='o';
                        break;
                    case 'ú':
                        ns+='u';
                        break;
                    case 'Á':
                        ns+='A';
                        break;
                    case 'É':
                        ns+='E';
                        break;
                    case 'Í':
                        ns+='I';
                        break;
                    case 'Ó':
                        ns+='O';
                        break;
                    case 'Ú':
                        ns+='U';
                        break;
                    default:
                        ns+=c;
                        break;

                }
            }
            l[x] = ns;
        }   
        return l;
    }
}