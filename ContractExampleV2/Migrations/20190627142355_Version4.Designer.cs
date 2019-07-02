﻿// <auto-generated />
using System;
using ContractExampleV2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContractExampleV2.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20190627142355_Version4")]
    partial class Version4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContractExampleV2.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PostId");

                    b.HasKey("AuthorId");

                    b.HasIndex("PostId")
                        .IsUnique()
                        .HasFilter("[PostId] IS NOT NULL");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ContractExampleV2.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ContractExampleV2.BlogPost", b =>
                {
                    b.Property<int>("BlogId");

                    b.Property<int>("PostId");

                    b.HasKey("BlogId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("ContractExampleV2.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ContractExampleV2.Author", b =>
                {
                    b.HasOne("ContractExampleV2.Post", "Post")
                        .WithOne("Author")
                        .HasForeignKey("ContractExampleV2.Author", "PostId");
                });

            modelBuilder.Entity("ContractExampleV2.BlogPost", b =>
                {
                    b.HasOne("ContractExampleV2.Blog", "Blog")
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ContractExampleV2.Post", "Post")
                        .WithMany("BlogPosts")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
