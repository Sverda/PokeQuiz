﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PokeQuiz.Services;
using System;

namespace PokeQuiz.Migrations
{
    [DbContext(typeof(PokeContext))]
    [Migration("20180920190731_PokemonOneImage")]
    partial class PokemonOneImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Pokemon", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Image");

                    b.HasKey("Name");

                    b.ToTable("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
