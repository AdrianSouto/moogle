namespace MoogleEngine;
static class Matriz{
    //Mi lista de vectores (Lo que representa mi matriz)
    public static List<Vector> matrizVectores = new List<Vector>();

    public static Dictionary<string, int> IDF = new Dictionary<string, int>();

    public static void Add(Vector v){
        matrizVectores.Add(v);
        
    }

    
}