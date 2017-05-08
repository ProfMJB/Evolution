using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Gene<T> : IGene
    {
        private Gene(int parentCount)
        {
            this.alleles = new T[parentCount];
        }

        public Gene(params T[] alleles)
        {
            this.alleles = alleles;
        }

        T[] alleles;

        public IEnumerable<T> Alleles { get { return alleles; } }

        public IGene Combine(IGene[] genes)
        {
            //TODO: Check that the ammount of given genes = the ammount of alleles in each gene
            Random random = new Random();
            Gene<T> child = new Gene<T>(genes.Length);
            for (int i = 0; i < genes.Length; i++)
            {
                child.alleles[i] = ((Gene<T>)genes[i]).alleles[(random.Next(0, ((Gene<T>)genes[i]).alleles.Length))];
            }
            return child;
        }

        public override string ToString()
        {
            string al = "";
            foreach (T item in alleles)
            {
                al += ":" + item.ToString();
            }
            return al.TrimStart(':');
        }
    }
}
