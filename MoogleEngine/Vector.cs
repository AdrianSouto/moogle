namespace MoogleEngine;
class Vector{
    public Dictionary<string, double> TFIDF{
        get;
    } = new Dictionary<string, double>();

    public string path = "";

    public List<string> words = new List<string>();
    public static int x = 0;

    //Constructor para los docs
    public Vector(string path, List<string> listWords){
        this.path = path;
        //Guardo este vector en mi Matriz
        Matriz.Add(this);
        this.words = listWords;
        CountWords();
    }
    //Constructor para la query
    public Vector(List<string> listWords){
        this.words = listWords;
        path = "query";
        CountWords();
    }
    //Forma el nombre del Doc a partir del Path
    public string GetName(){
        return path.Substring(path.LastIndexOf('/')+1, path.ToLower().IndexOf(".txt") - path.LastIndexOf('/')-1);
    }
    //Calcula el producto escalar de los TFIDF entre 2 vectores 
    //y calcula las magnitudes de esos vectores
    public double ProdEscalar(Vector v){
        //Query.ProdEscalar(Documento)
        double sum = 0;
        foreach(string w in TFIDF.Keys){
            double idfWord = Utils.CalculateIDF(w);
            TFIDF[w] = (Utils.CalculateTF(this,w) * idfWord);
            if(v.TFIDF.ContainsKey(w)){
                double tfidfDOC = (Utils.CalculateTF(v,w) * idfWord);               
                sum +=  TFIDF[w] * tfidfDOC;
            }
        }
        return sum;
    }

    public double NormaVector(){
        double norma = 0;
        foreach(string s in TFIDF.Keys){
           double  d= TFIDF[s];
            norma += Math.Pow(d,2);
        }
        return Math.Sqrt(norma);
    }

    //Llena TFIDF con la cant de veces q aparece la palabra en el doc 
    //y llena IDF con la cant de docs en los q aparece la palabra
    public void CountWords(){
        foreach(string w in words){
            x++;
            //Llena TFIDF con la cant de veces q aparece la palabra en el doc
            if(TFIDF.ContainsKey(w)){
                TFIDF[w]++;
            }else{
                TFIDF.Add(w, 1);
                //Llena IDF con la cant de docs en los q aparece la palabra
                if(path != "query"){
                    if(Matriz.IDF.ContainsKey(w)){
                        Matriz.IDF[w]++;
                    }else{
                        Matriz.IDF.Add(w, 1);
                    }
                }
                    
            }      
        }
    }
}