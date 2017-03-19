using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab3.Modells;

namespace Lab3.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20170309163908_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab3.Modells.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName");

                    b.Property<int?>("PersonId1");

                    b.HasKey("PersonId");

                    b.HasIndex("PersonId1");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Lab3.Modells.Person", b =>
                {
                    b.HasOne("Lab3.Modells.Person")
                        .WithMany("Persons")
                        .HasForeignKey("PersonId1");
                });
        }
    }
}
