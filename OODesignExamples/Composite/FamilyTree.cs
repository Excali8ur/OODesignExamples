using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Composite
{
    public interface iFamily
    {
        List<string> ShowName();
    }

    public class Man : iFamily
    {
        public string name;

        public List<string> ShowName()
        {
            return new List<string> { "M: " + name };
        }

        public iFamily Marry(iFamily marriedWith)
        {
            Family f = new Family(this, marriedWith);
            return f;
        }
    }

    public class Female : iFamily
    {
        public string name;

        public List<string> ShowName()
        {
            return new List<string> { "F: " + name };
        }

        public iFamily Marry(iFamily marriedWith)
        {
            Family f = new Family(this, marriedWith);
            return f;
        }
    }

    public class Family : iFamily
    {
        private iFamily[] couple;
        private List<iFamily> kids;
        public string name;

        public Family()
        {
            couple = new iFamily[2];
            kids = new List<iFamily>();
        }

        public Family(iFamily m1, iFamily m2)
        {
            couple = new iFamily[2] { m1, m2 };
            kids = new List<iFamily>();
        }

        public List<string> ShowName()
        {
            List<string> names = new List<string> { "--- Family name: " + name };
            foreach (iFamily k in kids)
            {
                List<string> mNames = k.ShowName();
                foreach (string s in mNames)
                {
                    names.Add(s);
                }
            }
            return names;
        }
    }
}
