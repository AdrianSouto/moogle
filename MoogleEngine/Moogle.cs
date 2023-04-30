namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query) {
        // Modifique este método para responder a la búsqueda
        SearchItem[] items = Search(query);

        return new SearchResult(items, query);
    }
    static SearchItem[] Search(string query){
        List<string> words = Utils.MakeList(query);
        Vector queryVector = new Vector(words);
        List<SearchItem> result = new List<SearchItem>();
        foreach(Vector v in Matriz.matrizVectores.Values){
            bool containAny = false;
            foreach(string s in queryVector.TFIDF.Keys){
                if(queryVector.TFIDF[s] != 0 && v.TFIDF.ContainsKey(s) && v.TFIDF[s] != 0){
                    containAny = true;
                    break;
                }
            }
            if(containAny){
                double score = v.ProdEscalar(queryVector);
                result.Add(new SearchItem(v.GetName(), score.ToString(), (float) score));
            }
        }
        return result.OrderByDescending(x=>x.Score).ToArray();
    }
}
