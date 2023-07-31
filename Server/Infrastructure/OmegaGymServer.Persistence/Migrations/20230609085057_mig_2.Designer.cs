﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OmegaGymServer.Persistence.Contexts;

#nullable disable

namespace OmegaGymServer.Persistence.Migrations
{
    [DbContext(typeof(OmegaGymEfDbContext))]
    [Migration("20230609085057_mig_2")]
    partial class mig_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.OperationClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubscriptionArticlelOne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionArticlelThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionArticlelTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubscriptionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubscriptionPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SubscriptionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserSubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserSubscriptionId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.SubscriptionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubscriptionCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionCategories");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OperationClaimId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserSubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserSubscriptionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.UserSubscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserSubscriptions");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("OmegaGymServer.Domain.Entities.UserSubscription", "UserSubscription")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserSubscriptionId");

                    b.Navigation("UserSubscription");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.SubscriptionCategory", b =>
                {
                    b.HasOne("OmegaGymServer.Domain.Entities.Subscription", "Subscription")
                        .WithMany("SubscriptionCategories")
                        .HasForeignKey("SubscriptionId");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.User", b =>
                {
                    b.HasOne("OmegaGymServer.Domain.Entities.OperationClaim", "OperationClaim")
                        .WithMany("Users")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OmegaGymServer.Domain.Entities.UserSubscription", "UserSubscription")
                        .WithMany("Users")
                        .HasForeignKey("UserSubscriptionId");

                    b.Navigation("OperationClaim");

                    b.Navigation("UserSubscription");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.OperationClaim", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.Subscription", b =>
                {
                    b.Navigation("SubscriptionCategories");
                });

            modelBuilder.Entity("OmegaGymServer.Domain.Entities.UserSubscription", b =>
                {
                    b.Navigation("Subscriptions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}