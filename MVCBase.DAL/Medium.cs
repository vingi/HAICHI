using System;
using NHibernate;
using NHibernate.Cfg;
using MVCBase.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCBase.DAL
{
    public class Medium
    {
        ISession session;
        public Medium()
        {
            session = (new NHibernateHelper()).GetSession();
        }

        public void Add(Ba_Medium medium)
        {
            session.Save(medium);
            session.Flush();
        }

        public void Update(Ba_Medium medium)
        {
            session.Update(medium);
            session.Flush();
        }

        public void SaveOrUpdate(Ba_Medium medium)
        {
            session.SaveOrUpdate(medium);
            session.Flush();
        }

        public Ba_Medium GetSinglemediumById(int Ns_ID)
        {
            return session.Get<Ba_Medium>(Ns_ID);
        }

        public IList<Ba_Medium> Getmedium()
        {
            return session.CreateQuery("from Ba_Medium as ns where ns.Ns_State=:st")
                .SetBoolean("st", true).List<Ba_Medium>();
        }

        public IList<Ba_Medium> Getmedium(int pagenum)
        {
            int pagestep = 3;
            return session.CreateQuery("from Ba_Medium as ns where ns.Ns_State=:st order by ns.Ns_BuildTime desc")
                .SetBoolean("st", true)
                .SetFirstResult((pagenum - 1) * pagestep)
                .SetMaxResults(pagenum * pagestep)
                .List<Ba_Medium>();
        }
    }
}
