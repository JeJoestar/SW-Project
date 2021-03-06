// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SW.DAL;

#nullable disable

namespace SW.DAL.Migrations
{
    [DbContext(typeof(SWContext))]
    [Migration("20220306172209_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SW.DAL.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AmmoSupplyId")
                        .HasColumnType("int");

                    b.Property<int?>("AttachedFleetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmmoSupplyId");

                    b.HasIndex("AttachedFleetId");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("SW.DAL.BaseFleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Fraction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fleets");
                });

            modelBuilder.Entity("SW.DAL.Clone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BaseId")
                        .HasColumnType("int");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LegionId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StarshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.HasIndex("LegionId");

                    b.HasIndex("StarshipId");

                    b.ToTable("Clones");
                });

            modelBuilder.Entity("SW.DAL.Droid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BaseId")
                        .HasColumnType("int");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StarshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.HasIndex("StarshipId");

                    b.ToTable("Droids");
                });

            modelBuilder.Entity("SW.DAL.Jedi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("LegionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PadawanId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PadawanId")
                        .IsUnique()
                        .HasFilter("[PadawanId] IS NOT NULL");

                    b.ToTable("Jedis");
                });

            modelBuilder.Entity("SW.DAL.Legion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GeneralJediId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneralJediId")
                        .IsUnique();

                    b.ToTable("Legions");
                });

            modelBuilder.Entity("SW.DAL.Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FleetId")
                        .HasColumnType("int");

                    b.Property<string>("PathList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplyId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeaponryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FleetId");

                    b.HasIndex("SupplyId");

                    b.HasIndex("WeaponryId");

                    b.ToTable("Starships");
                });

            modelBuilder.Entity("SW.DAL.StarshipWeaponry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LaserDoubleCannonCnt")
                        .HasColumnType("int");

                    b.Property<int>("LaserTargetDefenseCannonCnt")
                        .HasColumnType("int");

                    b.Property<int>("LaserTurretCnt")
                        .HasColumnType("int");

                    b.Property<int>("ProtonTorpedoLauncherCnt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StarshipWeaponries");
                });

            modelBuilder.Entity("SW.DAL.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartridgesCount")
                        .HasColumnType("int");

                    b.Property<int>("FuelLitresAmount")
                        .HasColumnType("int");

                    b.Property<int>("GrenadesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("SW.DAL.Base", b =>
                {
                    b.HasOne("SW.DAL.Supply", "AmmoSupply")
                        .WithMany()
                        .HasForeignKey("AmmoSupplyId");

                    b.HasOne("SW.DAL.BaseFleet", "AttachedFleet")
                        .WithMany("AttachedBases")
                        .HasForeignKey("AttachedFleetId");

                    b.Navigation("AmmoSupply");

                    b.Navigation("AttachedFleet");
                });

            modelBuilder.Entity("SW.DAL.Clone", b =>
                {
                    b.HasOne("SW.DAL.Base", "Base")
                        .WithMany("Clones")
                        .HasForeignKey("BaseId");

                    b.HasOne("SW.DAL.Legion", "Legion")
                        .WithMany("Clones")
                        .HasForeignKey("LegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW.DAL.Starship", "Starship")
                        .WithMany("Passangers")
                        .HasForeignKey("StarshipId");

                    b.Navigation("Base");

                    b.Navigation("Legion");

                    b.Navigation("Starship");
                });

            modelBuilder.Entity("SW.DAL.Droid", b =>
                {
                    b.HasOne("SW.DAL.Base", "Base")
                        .WithMany("Droids")
                        .HasForeignKey("BaseId");

                    b.HasOne("SW.DAL.Starship", "Starship")
                        .WithMany("Droids")
                        .HasForeignKey("StarshipId");

                    b.Navigation("Base");

                    b.Navigation("Starship");
                });

            modelBuilder.Entity("SW.DAL.Jedi", b =>
                {
                    b.HasOne("SW.DAL.Jedi", "Padawan")
                        .WithOne("Teacher")
                        .HasForeignKey("SW.DAL.Jedi", "PadawanId");

                    b.Navigation("Padawan");
                });

            modelBuilder.Entity("SW.DAL.Legion", b =>
                {
                    b.HasOne("SW.DAL.Jedi", "GeneralJedi")
                        .WithOne("Legion")
                        .HasForeignKey("SW.DAL.Legion", "GeneralJediId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneralJedi");
                });

            modelBuilder.Entity("SW.DAL.Starship", b =>
                {
                    b.HasOne("SW.DAL.BaseFleet", "Fleet")
                        .WithMany("Starships")
                        .HasForeignKey("FleetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SW.DAL.Supply", "Supply")
                        .WithMany()
                        .HasForeignKey("SupplyId");

                    b.HasOne("SW.DAL.StarshipWeaponry", "Weaponry")
                        .WithMany()
                        .HasForeignKey("WeaponryId");

                    b.Navigation("Fleet");

                    b.Navigation("Supply");

                    b.Navigation("Weaponry");
                });

            modelBuilder.Entity("SW.DAL.Base", b =>
                {
                    b.Navigation("Clones");

                    b.Navigation("Droids");
                });

            modelBuilder.Entity("SW.DAL.BaseFleet", b =>
                {
                    b.Navigation("AttachedBases");

                    b.Navigation("Starships");
                });

            modelBuilder.Entity("SW.DAL.Jedi", b =>
                {
                    b.Navigation("Legion");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SW.DAL.Legion", b =>
                {
                    b.Navigation("Clones");
                });

            modelBuilder.Entity("SW.DAL.Starship", b =>
                {
                    b.Navigation("Droids");

                    b.Navigation("Passangers");
                });
#pragma warning restore 612, 618
        }
    }
}
