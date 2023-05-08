namespace MoogleEngine;
static class Matriz{
    public static Dictionary<string, Vector> matrizVectores = new Dictionary<string, Vector>();
    public static Dictionary<string, int> IDF = new Dictionary<string, int>();
    public static void Add(string s, Vector v){
        matrizVectores.Add(s,v);
        
    }

    public static double CalculateIDF(string w)
    {       //Cuenta la cant de docs q contienen la palabra
        /*int cont = 0;
        foreach(Vector v in matrizVectores.Values){
            if(v.TFIDF.ContainsKey(w)){
                cont++;
            }
        }*/
        int cont = IDF.ContainsKey(w)? IDF[w] : 0;     
        double idf = cont!=0?Math.Log((double) matrizVectores.Count()/cont):0;
        if(idf > 1){
            return idf;
        }else{
            return 0;
        }
    }
    public static double CalculateTF(Vector v, string w){
        return (double)v.TFIDF[w]/v.count;
    }

}