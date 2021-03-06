﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForcastAPI.Data;

namespace WeatherForcastAPI.Data.Migrations
{
    [DbContext(typeof(WeatherForcastContext))]
    partial class WeatherForcastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherForcastAPI.Models.Forcast", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Condition");

                    b.Property<int>("MaxTemp");

                    b.Property<int>("MinTemp");

                    b.Property<string>("Name");

                    b.Property<string>("Outlook");

                    b.Property<string>("WindDir");

                    b.Property<int>("WindSpeed");

                    b.HasKey("ID");

                    b.ToTable("Forcasts");
                });
#pragma warning restore 612, 618
        }
    }
}
