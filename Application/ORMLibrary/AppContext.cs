namespace ORMLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Disability> Disabilities { get; set; }
        public virtual DbSet<MartialStatus> MartialStatus { get; set; }
        public virtual DbSet<PlanOfAccount> PlanOfAccounts { get; set; }
        public virtual DbSet<PlanOfCredit> PlanOfCredits { get; set; }
        public virtual DbSet<PlanOfDeposit> PlanOfDeposits { get; set; }
        public virtual DbSet<SystemInformation> SystemInformations { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.DebitValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .Property(e => e.CreditValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.MainAccountCredits)
                .WithRequired(e => e.MainAccount)
                .HasForeignKey(e => e.MainAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.PercentAccountCredits)
                .WithRequired(e => e.PercentAccount)
                .HasForeignKey(e => e.PercentAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.MainAccountDeposits)
                .WithRequired(e => e.MainAccount)
                .HasForeignKey(e => e.MainAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.PercentAccountDeposits)
                .WithRequired(e => e.PercentAccount)
                .HasForeignKey(e => e.PercentAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.DebitTransactions)
                .WithRequired(e => e.DebetAccount)
                .HasForeignKey(e => e.DebetAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.CreditTransactions)
                .WithRequired(e => e.CreditAccount)
                .HasForeignKey(e => e.CreditAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Citizenship>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Citizenship>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Citizenship)
                .HasForeignKey(e => e.CitezenshipId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PassportSeries)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.IssuedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.IdentificationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.BirthPlace)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ResidenceActualAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.HomePhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.MobilePhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ResidenceAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.MonthlyIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Credits)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Deposits)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Credit>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Credit>()
                .Property(e => e.CreditCardPin)
                .IsUnicode(false);

            modelBuilder.Entity<Deposit>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Disability>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Disability>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Disability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MartialStatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<MartialStatus>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.MartialStatus)
                .HasForeignKey(e => e.MaritalStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfAccount>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.PlanOfAccount)
                .HasForeignKey(e => e.PlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfAccount>()
                .HasMany(e => e.MainAccountPlanOfCredits)
                .WithRequired(e => e.MainPlanOfAccount)
                .HasForeignKey(e => e.MainAccountPlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfAccount>()
                .HasMany(e => e.PercentAccountPlanOfCredits)
                .WithRequired(e => e.PercentPlanOfAccount)
                .HasForeignKey(e => e.PercentAccountPlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfAccount>()
                .HasMany(e => e.MainAccountPlanOfDeposits)
                .WithRequired(e => e.MainPlanOfAccount)
                .HasForeignKey(e => e.MainAccountPlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfAccount>()
                .HasMany(e => e.PercentAccountPlanOfDeposits)
                .WithRequired(e => e.PercentPlanOfAccount)
                .HasForeignKey(e => e.PercentAccountPlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfCredit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PlanOfCredit>()
                .Property(e => e.MinAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PlanOfCredit>()
                .HasMany(e => e.Credits)
                .WithRequired(e => e.PlanOfCredit)
                .HasForeignKey(e => e.PlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanOfDeposit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PlanOfDeposit>()
                .Property(e => e.MinAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PlanOfDeposit>()
                .HasMany(e => e.Deposits)
                .WithRequired(e => e.PlanOfDeposit)
                .HasForeignKey(e => e.PlanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Town>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Town>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Town>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Town)
                .HasForeignKey(e => e.ResidenceActualPlaceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);
        }
    }
}
