using IDELanguages;

namespace IDELanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            CSharp cs = new CSharp();
            Java java = new Java();
            CLang cLang = new CLang();
            VBNET vBNET = new VBNET();
            Typescript ts = new Typescript();
            //ObjectOriented objectOriented = new ObjectOriented();
            //ide.CS = cs;
            //ide.Java = java;
            //ide.C = cLang;
            //ide.VBNET = vBNET;
            ide.Languages.Add(cs);
            ide.Languages.Add(vBNET);
            ide.Languages.Add(cLang);
            //ide.Languages.Add(java);
            //ide.Languages.Add(objectOriented);

            ide.Languages.Add(ts);
            ide.Work();

        }
    }

    // new feature, new code, dont/minimise modify the existing code
    // separate what repeats from what stays constant
    // code should be ideatic proof

    class IDE // SRP - OCP - Program to interface/abstraction not to implimentation
    {
        //public CSharp CS { get; set; }
        //public Java Java { get; set; }
        //public CLang C { get; set; }

        //public VBNET VBNET { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void Work()
        {
            foreach (var lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine(lang.GetParadigm());
            }
        }
    }

    interface ILanguage // what?
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }

    abstract class ObjectOriented : ILanguage
    {
        public string GetUnit() { return "Class"; }
        public string GetParadigm() { return "Object Oriented"; }

        abstract public string GetName();
        //{
        //    throw new NotImplementedException();
        //}
    }

    abstract class Procedural : ILanguage
    {
        public string GetUnit() { return "Function"; }
        public string GetParadigm() { return "Procedural"; }

        abstract public string GetName();
        //{
        //    throw new NotImplementedException();
        //}
    }



    class CSharp : ObjectOriented // Inheritance / IS-A - Realization
    {
        public override string GetName() { return "C Sharp"; }

    }

}
class Java : ObjectOriented
{
    public override string GetName() { return "Java"; }

}
class CLang : Procedural
{
    public override string GetName() { return "C Language"; }

}

class VBNET : ObjectOriented
{
    public override string GetName() { return "VB.Net"; }

}

class Typescript : ObjectOriented
{
    public override string GetName() { return "Typescript"; }

}

