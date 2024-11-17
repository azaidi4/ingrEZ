﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ingrEZ.Data;

#nullable disable

namespace ingrEZ.Migrations
{
    [DbContext(typeof(IngrEZDataContext))]
    [Migration("20241114221250_UpdateMealPlanRecipe")]
    partial class UpdateMealPlanRecipe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ingrEZ.Models.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("MealPlan");
                });

            modelBuilder.Entity("ingrEZ.Models.MealPlanRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("Meal")
                        .HasColumnType("int");

                    b.Property<int>("MealPlanId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealPlanId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MealPlanRecipe");
                });

            modelBuilder.Entity("ingrEZ.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("varchar(6)")
                        .HasAnnotation("Relational:JsonPropertyName", "difficulty");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "ingredients");

                    b.Property<string>("ItemizedInstructions")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "itemizedInstructions");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("varchar(9)")
                        .HasAnnotation("Relational:JsonPropertyName", "mealType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<DateTime?>("PinnedDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PreperationTime")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "preperationTime");

                    b.Property<int>("ServingSize")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "servingSize");

                    b.Property<string>("Suggestions")
                        .HasColumnType("longtext")
                        .HasAnnotation("Relational:JsonPropertyName", "suggestions");

                    b.HasKey("Id");

                    b.HasIndex("Hash")
                        .HasDatabaseName("idx_hash");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("ingrEZ.Models.MealPlanRecipe", b =>
                {
                    b.HasOne("ingrEZ.Models.MealPlan", null)
                        .WithMany("Recipes")
                        .HasForeignKey("MealPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ingrEZ.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ingrEZ.Models.MealPlan", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
