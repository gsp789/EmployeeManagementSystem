using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeDataUtil.Models
{
    public partial class HREmployeeManagementContext : DbContext
    {
        public virtual DbSet<Hrcurrency> Hrcurrency { get; set; }
        public virtual DbSet<Hremployee> Hremployee { get; set; }
        public virtual DbSet<HremployeeRole> HremployeeRole { get; set; }
        public virtual DbSet<HrerrorLogs> HrerrorLogs { get; set; }
        public virtual DbSet<HrexpenseCategory> HrexpenseCategory { get; set; }
        public virtual DbSet<Hrexpenses> Hrexpenses { get; set; }
        public virtual DbSet<HrexpensesAttachments> HrexpensesAttachments { get; set; }
        public virtual DbSet<HrexpenseSubCategory> HrexpenseSubCategory { get; set; }
        public virtual DbSet<HrpasswordRecovery> HrpasswordRecovery { get; set; }
        public virtual DbSet<Hrroles> Hrroles { get; set; }
        public virtual DbSet<Hrstatus> Hrstatus { get; set; }
        public virtual DbSet<HrtravelClaim> HrtravelClaim { get; set; }
        public virtual DbSet<Hruser> Hruser { get; set; }

        public HREmployeeManagementContext(DbContextOptions<HREmployeeManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hrcurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("HRCurrency");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hremployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("HREmployee");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeAddress).HasColumnType("text");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HremployeeRole>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.RoleId });

                entity.ToTable("HREmployeeRole");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HremployeeRole)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HREmployeeRole_EmpId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.HremployeeRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HREmployeeRole_RoleId");
            });

            modelBuilder.Entity<HrerrorLogs>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("HRErrorLogs");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<HrexpenseCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("HRExpenseCategory");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryDescription).HasColumnType("text");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hrexpenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.ToTable("HRExpenses");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ExpenseEndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStartDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.Hrexpenses)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK_HRExpenses_ClaimId");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Hrexpenses)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_HRExpenses_CurrencyId");

                entity.HasOne(d => d.ExpenseCategory)
                    .WithMany(p => p.Hrexpenses)
                    .HasForeignKey(d => d.ExpenseCategoryId)
                    .HasConstraintName("FK_HrExpense_CategoryId1");

                entity.HasOne(d => d.ExpenseSubCategory)
                    .WithMany(p => p.Hrexpenses)
                    .HasForeignKey(d => d.ExpenseSubCategoryId)
                    .HasConstraintName("FK_HrExpense_CategoryId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Hrexpenses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_HrExpense_StatusId");
            });

            modelBuilder.Entity<HrexpensesAttachments>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.ToTable("HRExpensesAttachments");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExpenseFileName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.HrexpensesAttachments)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_HRExpenses_ExpenseId");
            });

            modelBuilder.Entity<HrexpenseSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("HRExpenseSubCategory");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Limit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SubCategoryDescription).HasColumnType("text");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.HrexpenseSubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_HRExpenseCategoryId");
            });

            modelBuilder.Entity<HrpasswordRecovery>(entity =>
            {
                entity.ToTable("HRPasswordRecovery");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveryCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hrroles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("HRRoles");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleDescription).HasColumnType("text");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hrstatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("HRStatus");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HrtravelClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("HRTravelClaim");

                entity.Property(e => e.BusinessPurpose).HasColumnType("text");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.IsClaimed).HasColumnName("Is_Claimed");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ApprovedEmployee)
                    .WithMany(p => p.HrtravelClaimApprovedEmployee)
                    .HasForeignKey(d => d.ApprovedEmployeeId)
                    .HasConstraintName("FK_HRTravelClaim_AppId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HrtravelClaimEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_HRTravelClaim_EmpId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.HrtravelClaim)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_HRStatus_StsId");
            });

            modelBuilder.Entity<Hruser>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("HRUser");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogedIn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
