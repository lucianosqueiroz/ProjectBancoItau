using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Infra.Data.Contexto
{
    public class ProjectBancoItau : DbContext
    {
        /*public ProjectBancoItau()
            :base ("ProjectBancoItau")
        {

        }

       /* public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }*/

        protected override void OnModelCreating(DbModelBuilder modelBuider)
        {
           /* modelBuider.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuider.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuider.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuider.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey()); //quando alguma propriedade for o nome da tabela + ID, esta será a chave primaria


            modelBuider.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")); //quando for string o tipo no banco será varchar


            modelBuider.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            //quando não especifiar o tamanho string, este terá 100 caracteres

            /*
            modelBuider.Configurations.Add(new ClienteConfiguration()); //add a classe Usuario configuration na criação do banco
            modelBuider.Configurations.Add(new ContaConfiguration());
            modelBuider.Configurations.Add(new UsuarioConfiguration());*/
        }


    }


}
