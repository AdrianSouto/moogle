namespace MoogleEngine;
static class Matriz{
    //Mi lista de vectores (Lo que representa mi matriz)
    public static List<Vector> matrizVectores = new List<Vector>();

    public static Dictionary<string, int> IDF = new Dictionary<string, int>();

    public static void Add(Vector v){
        matrizVectores.Add(v);
        
    }

    //Dada una palabra calcula el IDF
    public static double CalculateIDF(string w)
    {    
        //En este punto IDF contiene la cantidad de docs en los que se encuentra cada palabra
        int cont = IDF.ContainsKey(w)? IDF[w] : 0;
        double idf = cont != 0? Math.Log((double) matrizVectores.Count()/cont) : 0;
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