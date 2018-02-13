using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Client.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Male { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssueDate { get; set; }
        public string IdentificationNumber { get; set; }
        public string BirthPlace { get; set; }
        public string ResidenceActualAddress { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
        public string ResidenceAddress { get; set; }
        public bool Pensioner { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public virtual CitizenshipModel Citizenship { get; set; }
        public virtual DisabilityModel Disability { get; set; }
        public virtual MaritalStatusModel MartialStatus { get; set; }
        public virtual TownModel Town { get; set; }
    }
}
