namespace MoogleEngine;
class Vector{
    public Dictionary<string, double> TFIDF{
        get;
    }
    public string path = "";
    public int count;

    //Para los docs
    public Vector(string path, List<string> listWords){

        this.path = path;
        this.count = listWords.Count();
        TFIDF = ToCountDictionary(listWords);
        Matriz.Add(this.GetName(), this);

    }
    //Para la query
    public Vector(List<string> listWords){
        this.count = listWords.Count();
        TFIDF = ToCountDictionary(listWords);
        CalculateTFIDF();
    }
    public string GetName(){
        return path != ""? path.Substring(path.LastIndexOf('/')+1, path.ToLower().IndexOf(".txt") - path.LastIndexOf('/')-1) : "Sin Nombre";
    }
    public double ProdEscalar(Vector v){
        double sum = 0;
        foreach(string w in TFIDF.Keys){
            if(v.TFIDF[w] != 0){
                sum+= this.TFIDF[w] * v.TFIDF[w];
            }
        }
        return sum;
    }
    public static Dictionary<string, double> ToCountDictionary(List<string> array){
        Dictionary<string, double> d = new Dictionary<string, double>();
        for(int x = 0; x < array.Count(); x++){
            if(d.ContainsKey(array[x])){
                d[array[x]]++;
            }else{
                d.Add(array[x], 1);
            }
        }
        return d;
    }
    public void CalculateTFIDF(){
        //Ya el IDF debe estar lleno xq esta funcion se usa para el query y el idf se llena al inicio
        List<string> allWords = LeerDocs.words;
        foreach(string w in allWords){
            if(this.TFIDF.ContainsKey(w)){
                double x = Matriz.IDF[w];

                TFIDF[w] =  Matriz.CalculateTF(w, this) * Matriz.IDF[w];
            }else{
                TFIDF.Add(w, 0);
            }
        }
    }
    
    public void Print(bool onlyWithValues = false){
        foreach(string w in TFIDF.Keys){
            if(!onlyWithValues || TFIDF[w]!=0)
                System.Console.WriteLine(w+": "+TFIDF[w]);
        }
    }
}