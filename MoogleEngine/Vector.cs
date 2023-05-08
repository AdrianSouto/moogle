namespace MoogleEngine;
class Vector{
    public Dictionary<string, double> TFIDF{
        get;
    } = new Dictionary<string, double>();
    public string path = "";
    public int count;
    public List<string> words = new List<string>();

    //Para los docs
    public Vector(string path, List<string> listWords){

        this.path = path;
        this.count = listWords.Count();
        Matriz.Add(this.GetName(), this);
        this.words = listWords;
        TFIDF = ToCountDictionary(listWords);
    }
    //Para la query
    public Vector(List<string> listWords){
        this.count = listWords.Count();
        this.words = listWords;
        TFIDF = ToCountDictionary(listWords);
        CalcularTFIDF();
    }
    public void CalcularTFIDF(){
        foreach(string w in TFIDF.Keys){
            TFIDF[w] = Matriz.CalculateTF(this, w) * Matriz.CalculateIDF(w);
        }
    }
    public string GetName(){
        return path != ""? path.Substring(path.LastIndexOf('/')+1, path.ToLower().IndexOf(".txt") - path.LastIndexOf('/')-1) : "Sin Nombre";
    }
    public double ProdEscalar(Vector v){
        //Query.ProdEscalar(Documento)
        double sum = 0;
        foreach(string w in TFIDF.Keys){
            if(v.TFIDF.ContainsKey(w)){
                double idfWord = Matriz.CalculateIDF(w);
                sum +=  TFIDF[w] * (Matriz.CalculateTF(v,w) * idfWord) ;
            }
        }
        return sum;
    }
    public static Dictionary<string, double> ToCountDictionary(List<string> array, bool isQuery = false){
        Dictionary<string, double> d = new Dictionary<string, double>();
        foreach(string w in array){
            if(d.ContainsKey(w)){
                d[w]++;
            }else{
                d.Add(w, 1);
                if(!isQuery){
                    //LeerDocs.words.Add(w);
                    if(Matriz.IDF.ContainsKey(w)){
                        Matriz.IDF[w]++;
                    }else{
                        Matriz.IDF.Add(w, 1);
                    }
                }
                    
            }
            
        }
        return d;
    }
}