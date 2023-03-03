﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eBaplie.Data;

#nullable disable

namespace eBaplie.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230222091745_AddvoyagestoVessel")]
    partial class AddvoyagestoVessel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eBaplie.Models.BaplieRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RequireConsigneeDetails")
                        .HasColumnType("bit");

                    b.Property<bool?>("RequireContainerNumber")
                        .HasColumnType("bit");

                    b.Property<bool?>("RequireContainerSize")
                        .HasColumnType("bit");

                    b.Property<bool?>("RequireContainerType")
                        .HasColumnType("bit");

                    b.Property<bool?>("RequirePackagingDetails")
                        .HasColumnType("bit");

                    b.Property<bool?>("RequireVesselVoyagNumber")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BaplieRequirements");
                });

            modelBuilder.Entity("eBaplie.Models.EdiChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChangeType")
                        .HasColumnType("int");

                    b.Property<int>("EdifactId")
                        .HasColumnType("int");

                    b.Property<int?>("EdifactNavigationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EdifactNavigationId");

                    b.ToTable("EdiChangeLogs");
                });

            modelBuilder.Entity("eBaplie.Models.EdifactGlobal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ArrivalDateTimeEstimated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Baplie")
                        .HasColumnType("bit");

                    b.Property<int?>("BaplieRequirementNavigationId")
                        .HasColumnType("int");

                    b.Property<string>("BillOfLadingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierPartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierStreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consignee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneeCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneePartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneeStreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContainerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContainerSequenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomsBroker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateEDI")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryOrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DepartureDateTimeEstimated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDateTimeReal")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinataireShipTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DryOrReefer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haulage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMDGClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformationContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformationContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformationContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line_To")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritimeTransportMainCarriage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAD_CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAD_MessageRecipient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAD_PartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAD_Shipto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAD_StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OnCarriageTransportModeEnum")
                        .HasColumnType("int");

                    b.Property<string>("PlaceOfDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfReceipt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortOfDischarge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortOfLoading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortOfTransShipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousMessageNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequirementId")
                        .HasColumnType("int");

                    b.Property<string>("SenderCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderPartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderStreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SplitGoodsPlacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusEnum")
                        .HasColumnType("int");

                    b.Property<int>("Tare")
                        .HasColumnType("int");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalNumberOfEquipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportEquipmentReleaseOrderEnum")
                        .HasColumnType("int");

                    b.Property<string>("TypeEDI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeISO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UltimateReleaseDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VGM")
                        .HasColumnType("int");

                    b.Property<int?>("VesselId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.Property<string>("VoyageNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XPos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YPos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZPos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaplieRequirementNavigationId");

                    b.HasIndex("VesselId");

                    b.ToTable("EdifactGlobals");
                });

            modelBuilder.Entity("eBaplie.Models.Vessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("eBaplie.Models.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("VesselId")
                        .HasColumnType("int");

                    b.Property<string>("VoygeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VesselId");

                    b.ToTable("Voyage");
                });

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("eBaplie.Models.EdiChangeLog", b =>
                {
                    b.HasOne("eBaplie.Models.EdifactGlobal", "EdifactNavigation")
                        .WithMany("EdiChangeLogsNavigation")
                        .HasForeignKey("EdifactNavigationId");

                    b.Navigation("EdifactNavigation");
                });

            modelBuilder.Entity("eBaplie.Models.EdifactGlobal", b =>
                {
                    b.HasOne("eBaplie.Models.BaplieRequirement", "BaplieRequirementNavigation")
                        .WithMany("BapliesNavigation")
                        .HasForeignKey("BaplieRequirementNavigationId");

                    b.HasOne("eBaplie.Models.Vessel", "VesselNavigation")
                        .WithMany("BapliesNavigation")
                        .HasForeignKey("VesselId");

                    b.Navigation("BaplieRequirementNavigation");

                    b.Navigation("VesselNavigation");
                });

            modelBuilder.Entity("eBaplie.Models.Voyage", b =>
                {
                    b.HasOne("eBaplie.Models.Vessel", "VesselNavigation")
                        .WithMany("VoyagesNavigation")
                        .HasForeignKey("VesselId");

                    b.Navigation("VesselNavigation");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eBaplie.Models.BaplieRequirement", b =>
                {
                    b.Navigation("BapliesNavigation");
                });

            modelBuilder.Entity("eBaplie.Models.EdifactGlobal", b =>
                {
                    b.Navigation("EdiChangeLogsNavigation");
                });

            modelBuilder.Entity("eBaplie.Models.Vessel", b =>
                {
                    b.Navigation("BapliesNavigation");

                    b.Navigation("VoyagesNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
