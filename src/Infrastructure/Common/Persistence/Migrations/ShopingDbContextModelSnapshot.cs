﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopingRequestSystem.Infrastructure.Common.Persistence;

namespace ShopingRequestSystem.Infrastructure.Common.Persistence.Migrations
{
    [DbContext(typeof(ShopingDbContext))]
    partial class ShopingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.DeliveryOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBestOffer")
                        .HasColumnType("bit");

                    b.Property<decimal>("ProposedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PublishedShopingRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("PublishedShopingRequestId");

                    b.ToTable("DeliveryOffers");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.PublishedShopingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ShopingRequesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopingRequesterId")
                        .IsUnique();

                    b.ToTable("PublishedShopingRequests");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.RequestExecutions.Models.RequestExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<decimal>("PaidSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("RequestExecutions");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.RequestExecutions.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("RequestExecutionId")
                        .HasColumnType("int");

                    b.Property<int>("TransportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestExecutionId");

                    b.HasIndex("TransportTypeId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.RequestExecutions.Models.TransportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TransportTypes");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.Requester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requesters");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShopingRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ShopingRequestId");

                    b.ToTable("ShopingItems");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PaymentSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("ShopingRequests");
                });

            modelBuilder.Entity("ShopingRequestSystem.Infrastructure.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.Contractor", b =>
                {
                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ShopingRequestSystem.Domain.Shared.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ContractorId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContractorId");

                            b1.ToTable("Contractors");

                            b1.WithOwner()
                                .HasForeignKey("ContractorId");
                        });

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.DeliveryOffer", b =>
                {
                    b.HasOne("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.Contractor", "Contractor")
                        .WithMany()
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.PublishedShopingRequest", null)
                        .WithMany("DeliveryOffers")
                        .HasForeignKey("PublishedShopingRequestId");

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.PublishedShopingRequest", b =>
                {
                    b.HasOne("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingRequest", null)
                        .WithOne()
                        .HasForeignKey("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.PublishedShopingRequest", "ShopingRequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.RequestExecutions.Models.Transport", b =>
                {
                    b.HasOne("ShopingRequestSystem.Domain.RequestExecutions.Models.RequestExecution", null)
                        .WithMany("Transports")
                        .HasForeignKey("RequestExecutionId");

                    b.HasOne("ShopingRequestSystem.Domain.RequestExecutions.Models.TransportType", "TransportType")
                        .WithMany()
                        .HasForeignKey("TransportTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TransportType");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.Requester", b =>
                {
                    b.HasOne("ShopingRequestSystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ShopingRequestSystem.Domain.Shared.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("RequesterId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RequesterId");

                            b1.ToTable("Requesters");

                            b1.WithOwner()
                                .HasForeignKey("RequesterId");
                        });

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingItem", b =>
                {
                    b.HasOne("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingRequest", null)
                        .WithMany("ShopingItems")
                        .HasForeignKey("ShopingRequestId");

                    b.OwnsOne("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingAddress", "Address", b1 =>
                        {
                            b1.Property<long>("ShopingItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ShopingItemId");

                            b1.ToTable("ShopingItems");

                            b1.WithOwner()
                                .HasForeignKey("ShopingItemId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingRequest", b =>
                {
                    b.HasOne("ShopingRequestSystem.Domain.ShopingRequests.Models.Requester", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ShopingRequestSystem.Domain.ShopingRequests.Models.RequestStatus", "Status", b1 =>
                        {
                            b1.Property<int>("ShopingRequestId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("ShopingRequestId");

                            b1.ToTable("ShopingRequests");

                            b1.WithOwner()
                                .HasForeignKey("ShopingRequestId");
                        });

                    b.Navigation("Requester");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.PublishedShopingRequests.Models.PublishedShopingRequest", b =>
                {
                    b.Navigation("DeliveryOffers");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.RequestExecutions.Models.RequestExecution", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("ShopingRequestSystem.Domain.ShopingRequests.Models.ShopingRequest", b =>
                {
                    b.Navigation("ShopingItems");
                });
#pragma warning restore 612, 618
        }
    }
}
