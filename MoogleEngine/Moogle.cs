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
            double score = queryVector.ProdEscalar(v);
            if(score > 0){
                string text = File.ReadAllText(v.path);
                int maxTFIDFPos = 0;
                Dictionary<string, double> queryOrdered = queryVector.TFIDF.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);
                string word = "";
                foreach(string w in queryOrdered.Keys){
                    if(v.TFIDF.ContainsKey(w)){
                        maxTFIDFPos = text.ToLower().IndexOf(w);
                        word = w;
                        break;
                    }
                }    
                int prevDot = Utils.PrevDot(maxTFIDFPos-50, text);
                string snipet = text.Substring(prevDot, Utils.NextDot(maxTFIDFPos+100, text) - prevDot);
                result.Add(new SearchItem(v.GetName(), snipet, (float) score));
            }
        }
        return result.OrderByDescending(x=>x.Score).ToArray();
    }
}
