namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query) {
        // Modifique este método para responder a la búsqueda
        SearchItem[] items = Search(query);

        return new SearchResult(items, query);
    }
    static SearchItem[] Search(string query){
        //Crea un Vector para la query
        List<string> words = Utils.MakeList(query);
        Vector queryVector = new Vector(words);

        List<SearchItem> result = new List<SearchItem>();

        foreach(Vector v in Matriz.matrizVectores){       
            //Calcula el score por cada vector y solo lo muestra si es mayor a 10^-6         
            double score = queryVector.ProdEscalar(v);
            score = score/(queryVector.NormaVector() * v.NormaVector());
            if(score > 0){
                string text = File.ReadAllText(v.path);
            //Ordena      las palabras del query por su TFIDF
            Dictionary<string, double> queryOrdered = queryVector.TFIDF.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);
            
            //Guarda en maxTFIDFPos la posicion de la palabra con mas TFIDF que este en el doc
            int maxTFIDFPos = 0;
            foreach(string w in queryOrdered.Keys){
                if(v.TFIDF.ContainsKey(w)){
                    maxTFIDFPos = text.ToLower().IndexOf(w);
                    break;
                }      
            }    
            //Guarda en el snippet desde punto anterior a 50 caracteres antes de maxTFIDFPos 
            //hasta el siguiente punto despues de 100 caracteres
            int prevDot = Utils.PrevDot(maxTFIDFPos-50, text);
            string snippet = text.Substring(prevDot, Utils.NextDot(maxTFIDFPos+100, text) - prevDot+1);
            result.Add(new SearchItem(v.GetName(), snippet, (float) score, v.path));
            }           
        }
        //Ordena los resultados de mayor a menor segun el score
        return result.OrderByDescending(x=>x.Score).ToArray();
    }


}
