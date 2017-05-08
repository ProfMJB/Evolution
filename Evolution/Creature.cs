using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Creature
    {
        public Creature()
        {
            genes = new Dictionary<string, IGene>();
        }

        public Creature(Dictionary<string, IGene> genes) { this.genes = genes; }

        Dictionary<string, IGene> genes;

        public IGene this[string key]
        {
            get { return genes[key]; }
        }

        public Gene<T> GetGene<T>(string key) { return (Gene<T>)this[key]; }

        public static Creature Breed<T>(params Creature[] parents)
            where T:Creature,new()
        {
            Creature child = new T();
            foreach (string key in parents[0].genes.Keys)
            {
                IGene[] parentGenes = new IGene[parents.Length];
                for(int i=0; i<parents.Length; i++)
                {
                    parentGenes[i] = parents[i][key];
                }
                child.genes[key] = parents[0].genes[key].Combine(parentGenes);
            }
            return child;
        }
        protected bool GeneActive(string key, bool dominant)
        {
            foreach (bool al in GetGene<bool>(key).Alleles)
            {
                if (al)
                {
                    return dominant;
                }

            }
            return !dominant;
        }

        public override string ToString()
        {
            string str = "";
            foreach(KeyValuePair<string, IGene> gene in genes)
            {
                str += string.Format("{0}:{1}\r\n", gene.Key, gene.Value);
            }
            return str.TrimEnd('\r', '\n');
        }
    }
}
