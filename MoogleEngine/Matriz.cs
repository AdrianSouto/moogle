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
        
        double idf = cont!=0? Math.Log((double) matrizVectores.Count()/cont): 0;
        if(idf > 0.5){
            IDF[w] = idf;
            return IDF[w];
        }else{
            return 0;
        }
    }

    public static void CalculateTFIDF(){
        List<string> allWords = LeerDocs.words;
        foreach(string w in allWords){
            double idf = CalculateIDF(w);
            foreach(Vector v in matrizVectores.Values){
                if(IDF.ContainsKey(w)){
                    v.TFIDF[w] =  CalculateTF(w, v) * idf;
                }else{
                    v.TFIDF.Remove(w);
                }
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