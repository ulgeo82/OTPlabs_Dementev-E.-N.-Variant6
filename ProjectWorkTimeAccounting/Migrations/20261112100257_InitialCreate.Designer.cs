using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectWorkTimeAccounting;

#nullable disable

namespace ProjectWorkTimeAccounting.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20261112100257_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeePost")
                        .HasColumnType("integer")
                        .HasColumnName("employee_post");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<int>("QualificationId")
                        .HasColumnType("integer")
                        .HasColumnName("qualification_id");

                    b.HasKey("Id");

                    b.HasIndex("QualificationId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer")
                        .HasColumnName("developer_id");

                    b.Property<int>("ManagerId")
                        .HasColumnType("integer")
                        .HasColumnName("manager_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ProjectType")
                        .HasColumnType("integer")
                        .HasColumnName("project_type");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ManagerId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("hourly_rate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("qualifications");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.SalaryPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(12,2)")
                        .HasColumnName("amount");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<decimal>("HoursWorked")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("hours_worked");

                    b.Property<DateTime>("PaymentMonth")
                        .HasColumnType("date")
                        .HasColumnName("payment_month");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("salary_payments");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.WorkTimeRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("WorkDate")
                        .HasColumnType("date")
                        .HasColumnName("work_date");

                    b.Property<int>("WorkKind")
                        .HasColumnType("integer")
                        .HasColumnName("work_kind");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("work_time_records");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.WorkTimeRecordProject", b =>
                {
                    b.Property<int>("WorkTimeRecordId")
                        .HasColumnType("integer")
                        .HasColumnName("work_time_record_id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<decimal>("Hours")
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("hours");

                    b.HasKey("WorkTimeRecordId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("work_time_record_projects");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.Employee", b =>
                {
                    b.HasOne("ProjectWorkTimeAccounting.Entities.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Qualification");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.Project", b =>
                {
                    b.HasOne("ProjectWorkTimeAccounting.Entities.Employee", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectWorkTimeAccounting.Entities.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.SalaryPayment", b =>
                {
                    b.HasOne("ProjectWorkTimeAccounting.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.WorkTimeRecord", b =>
                {
                    b.HasOne("ProjectWorkTimeAccounting.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.WorkTimeRecordProject", b =>
                {
                    b.HasOne("ProjectWorkTimeAccounting.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectWorkTimeAccounting.Entities.WorkTimeRecord", "WorkTimeRecord")
                        .WithMany("WorkTimeRecordProjects")
                        .HasForeignKey("WorkTimeRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("WorkTimeRecord");
                });

            modelBuilder.Entity("ProjectWorkTimeAccounting.Entities.WorkTimeRecord", b =>
                {
                    b.Navigation("WorkTimeRecordProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
