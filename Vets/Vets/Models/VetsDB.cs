using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vets.Models
{
    public class VetsDB : DbContext   // a classe VetsBD extende da superclasse DbContext, herdando todas as propriedades desta classe
    {
        //representar a base de dados
        //descreve as tabelas que estão lá contidas

        //represnetar o "construtor" desta classe
        //identifica onde se encontra a base de dados
        public VetsDB() : base("VetsDBConnection")
        {
        }
        //descrever as tabelas que estão na base de dados
        public virtual DbSet<Donos> Donos { get; set;}    //Donos a azul é a classe, a preto é a tabela
        // no Package Manager Console escrever: Enable-Migrations -EnableAutomaticMigrations
        // a seguir escrever Update-Database
        // escrever "MSSQLLocalDB" em vez de v11.0 no ficheiro Web.config em connectionstrings
    }
}