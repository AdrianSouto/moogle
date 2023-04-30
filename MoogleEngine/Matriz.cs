namespace MoogleEngine;
static class Matriz{
    public static Dictionary<string, Vector> matrizVectores = new Dictionary<string, Vector>();
    public static Dictionary<string, double> IDF = new Dictionary<string, double>();

    public static void Add(string s, Vector v){
        matrizVectores.Add(s,v);
    }

    public static double CalculateIDF(string w)
    {       //Cuenta la cant de docs q contienen la palabra
        int cont = 0;
        foreach(Vector v in matrizVectores.Values){
            if(v.TFIDF.ContainsKey(w)){
                cont++;
            }
        }
        IDF[w] = cont != 0? Math.Log((double) matrizVectores.Count()/cont)+1: 0;
        return IDF[w];
    }
    public static void RecorreVectors(Action<Vector> func){
        foreach(Vector v in matrizVectores.Values){
            func(v);
        }
    }
    public static void RecorreWords(Action<string> func){
        List<string> allWords = LeerDocs.words;
        foreach(string w in allWords){
            func(w);
        }
    }

    public static void CalculateTFIDF(){
        List<string> allWords = LeerDocs.words;
        foreach(string w in allWords){
            double idf = CalculateIDF(w);
            foreach(Vector v in matrizVectores.Values){
                v.TFIDF[w] =  CalculateTF(w, v) * idf;
            }
        }
    }

    


    public static double CalculateTF(string w, Vector v){
        if(v.TFIDF.ContainsKey(w)){
            return v.TFIDF[w] / v.count;
        }else{
            return 0;
        }
    }
}