using System.ComponentModel.DataAnnotations;
using SQLite;

namespace CoreBusiness.Entidades
{
    public class Observacao
    {

        public Observacao() { }

        public Observacao(string texto)
        {
            Texto = texto;
        }

        public Observacao(Guid id, string texto)
        {
            Id = id;
            Texto = texto;
        }

        [Required]
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        [Required]
        public string Texto { get; set; }
    }
}