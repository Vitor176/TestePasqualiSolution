using System;
using System.ComponentModel.DataAnnotations;

namespace PasqualiSolution.Web.Models
{
    public class RegisterPFModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal IncomeValue { get; set; }
        public DateTime? BirthDate { get; set; }
        [MaxLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string Cpf { get; set; }
    }
}
