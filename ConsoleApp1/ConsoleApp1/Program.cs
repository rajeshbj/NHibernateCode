using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            String connstring = "Server=119.82.106.246;userid=postgres;pwd=Stixis@123; database=SingnalRChatDb";

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = connstring;
                x.Driver<NpgsqlDriver>();
                x.Dialect<PostgreSQLDialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sefact = cfg.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var users = session.CreateCriteria<ChatUsers>().List<ChatUsers>();
                    foreach(var user in users)
                    {
                        Console.WriteLine("{0} \t{1} \t{2}", user.Id, user.Userid, user.Username);
                    }
                    tx.Commit();
                }
                Console.ReadLine();
            }
           

        }
    }
}
