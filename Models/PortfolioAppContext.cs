using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApp.Models;

public partial class PortfolioAppContext : DbContext
{
    public PortfolioAppContext()
    {
    }

    public PortfolioAppContext(DbContextOptions<PortfolioAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Cdl> Cdls { get; set; }

    public virtual DbSet<Competency> Competencies { get; set; }

    public virtual DbSet<CompetencyTracker> CompetencyTrackers { get; set; }

    public virtual DbSet<ContactsOfInterest> ContactsOfInterests { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<GoalStep> GoalSteps { get; set; }

    public virtual DbSet<IndustryContactInfo> IndustryContactInfos { get; set; }

    public virtual DbSet<IndustryContactLog> IndustryContactLogs { get; set; }

    public virtual DbSet<Networking> Networkings { get; set; }

    public virtual DbSet<NetworkingEvent> NetworkingEvents { get; set; }

    public virtual DbSet<NetworkingQuestion> NetworkingQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:portfolio-app.database.windows.net,1433;Initial Catalog=PortfolioApp;Persist Security Info=False;User ID=portfolioadmin;Password=Portfolio1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Cdl>(entity =>
        {
            entity.HasKey(e => e.CdlId).HasName("PK__CDL__3158CC6E6C1BD4BB");

            entity.ToTable("CDL");

            entity.Property(e => e.CdlId).HasColumnName("cdlId");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dateCreated");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("lastUpdated");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Competency>(entity =>
        {
            entity.ToTable("Competency");

            entity.Property(e => e.CompetencyId).HasColumnName("competencyId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("lastUpdated");
            entity.Property(e => e.LinkToIndicators).HasColumnName("linkToIndicators");
            entity.Property(e => e.ParentCompetencyId).HasColumnName("parentCompetencyId");
        });

        modelBuilder.Entity<CompetencyTracker>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CompetencyId, e.Level });

            entity.ToTable("CompetencyTracker");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CompetencyId).HasColumnName("competencyId");
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .HasDefaultValue("Emerging")
                .HasColumnName("level");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("created");
            entity.Property(e => e.DateEnd)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dateEnd");
            entity.Property(e => e.DateStart)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dateStart");
            entity.Property(e => e.Evidence).HasColumnName("evidence");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(sysdatetimeoffset())")
                .HasColumnName("lastUpdated");
            entity.Property(e => e.SkillsReview).HasColumnName("skillsReview");

            entity.HasOne(d => d.Competency).WithMany(p => p.CompetencyTrackers)
                .HasForeignKey(d => d.CompetencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompetencyTracker_Competency");

            entity.HasOne(d => d.User).WithMany(p => p.CompetencyTrackers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompetencyTracker_AspNetUsers");
        });

        modelBuilder.Entity<ContactsOfInterest>(entity =>
        {
            entity.HasKey(e => new { e.ContactOfInterestId, e.UserId });

            entity.ToTable("ContactsOfInterest");

            entity.HasIndex(e => e.ContactOfInterestId, "UQ_ContactsOfInterest_Id").IsUnique();

            entity.Property(e => e.ContactOfInterestId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.User).WithMany(p => p.ContactsOfInterests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ContactsOfInterest_Users");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => new { e.GoalId, e.UserId });

            entity.ToTable("Goal");

            entity.HasIndex(e => e.GoalId, "UQ_Goal_goalId").IsUnique();

            entity.Property(e => e.GoalId)
                .ValueGeneratedOnAdd()
                .HasColumnName("goalId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Complete).HasColumnName("complete");
            entity.Property(e => e.CompletionNotes).HasColumnName("completionNotes");
            entity.Property(e => e.DateSet)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dateSet");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.Learnings).HasColumnName("learnings");
            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("startDate");
            entity.Property(e => e.Timeline).HasColumnName("timeline");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_AspNetUsers");
        });

        modelBuilder.Entity<GoalStep>(entity =>
        {
            entity.HasKey(e => new { e.StepId, e.GoalId });

            entity.HasIndex(e => e.StepId, "UQ_GoalSteps_stepId").IsUnique();

            entity.Property(e => e.StepId)
                .ValueGeneratedOnAdd()
                .HasColumnName("stepId");
            entity.Property(e => e.GoalId).HasColumnName("goalId");
            entity.Property(e => e.Step).HasColumnName("step");

            entity.HasOne(d => d.Goal).WithMany(p => p.GoalSteps)
                .HasPrincipalKey(p => p.GoalId)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GoalSteps_Goal");
        });

        modelBuilder.Entity<IndustryContactInfo>(entity =>
        {
            entity.HasKey(e => new { e.ContactInfoId, e.ContactId });

            entity.ToTable("IndustryContactInfo");

            entity.HasIndex(e => e.ContactInfoId, "UQ_IndustryContactInfo_Id").IsUnique();

            entity.Property(e => e.ContactInfoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("contactInfoId");
            entity.Property(e => e.ContactId).HasColumnName("contactId");
            entity.Property(e => e.ContactDetails).HasColumnName("contactDetails");
            entity.Property(e => e.ContactType).HasColumnName("contactType");

            entity.HasOne(d => d.Contact).WithMany(p => p.IndustryContactInfos)
                .HasPrincipalKey(p => p.ContactId)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IndustryContactInfo_IndustryContactLog");
        });

        modelBuilder.Entity<IndustryContactLog>(entity =>
        {
            entity.HasKey(e => new { e.ContactId, e.UserId });

            entity.ToTable("IndustryContactLog");

            entity.HasIndex(e => e.ContactId, "UQ_IndustryContactLog_contactId").IsUnique();

            entity.Property(e => e.ContactId)
                .ValueGeneratedOnAdd()
                .HasColumnName("contactId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.DateMet).HasColumnName("dateMet");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");

            entity.HasOne(d => d.User).WithMany(p => p.IndustryContactLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IndustryContactLog_AspNetUsers");
        });

        modelBuilder.Entity<Networking>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.NetworkingId });

            entity.ToTable("Networking");

            entity.HasIndex(e => e.NetworkingId, "UQ_Networking_networkingId").IsUnique();

            entity.HasIndex(e => e.UserId, "UQ_Networking_userId").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.NetworkingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("networkingId");
            entity.Property(e => e.ElevatorPitch).HasColumnName("elevatorPitch");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("lastUpdated");

            entity.HasOne(d => d.User).WithOne(p => p.Networking)
                .HasForeignKey<Networking>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Networking_AspNetUsers");
        });

        modelBuilder.Entity<NetworkingEvent>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.UserId });

            entity.ToTable("NetworkingEvent");

            entity.HasIndex(e => e.EventId, "UQ_NetworkingEvent_eventId").IsUnique();

            entity.Property(e => e.EventId)
                .ValueGeneratedOnAdd()
                .HasColumnName("eventId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.User).WithMany(p => p.NetworkingEvents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NetworkingEvent_AspNetUsers");
        });

        modelBuilder.Entity<NetworkingQuestion>(entity =>
        {
            entity.HasKey(e => new { e.NetworkingQuestionsId, e.UserId });

            entity.HasIndex(e => e.NetworkingQuestionsId, "UQ_NetworkingQuestions_networkingQuestionsId").IsUnique();

            entity.Property(e => e.NetworkingQuestionsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("networkingQuestionsId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Question).HasColumnName("question");

            entity.HasOne(d => d.User).WithMany(p => p.NetworkingQuestions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NetworkingQuestions_AspNetUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
