﻿// <auto-generated />
#nullable disable
using FFXIVCharaTracker.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFXIVCharaTracker.Migrations
{
    [DbContext(typeof(CharaContext))]
    [Migration("20230128204956_InventorySlotAddUniqueIndex")]
    partial class InventorySlotAddUniqueIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("FFXIVCharaTracker.DB.Chara", b =>
                {
                    b.Property<ulong>("CharaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Account")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChocoboLevel")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ClassID")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ClassLevel")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CurGear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomDeliveryRanks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GCRank")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GatherGear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IncompleteFolkloreBooks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IncompleteQuests")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IncompleteSecretRecipeBooks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LevelAlc")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelArm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelBsm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelBtn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelCrp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelCul")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelFsh")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelGsm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelLtw")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelMin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LevelWvr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LockedCustomDeliveries")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LockedDuties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LowGear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PluginDataVersion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RetainersStoringDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnobtainedEmotes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnobtainedHairstyles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnobtainedMinions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnobtainedMounts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("WorldID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharaID");

                    b.ToTable("Charas");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.InventorySlot", b =>
                {
                    b.Property<ulong>("InventorySlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("CharaID")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Inventory")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ItemCategory")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ItemID")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("RetainerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slot")
                        .HasColumnType("INTEGER");

                    b.HasKey("InventorySlotID");

                    b.HasIndex("CharaID", "Inventory", "Slot");

                    b.HasIndex("ItemID", "CharaID", "Quantity");

                    b.HasIndex("ItemID", "RetainerID", "Quantity");

                    b.HasIndex("RetainerID", "Inventory", "Slot");

                    b.HasIndex("CharaID", "RetainerID", "Inventory", "Slot")
                        .IsUnique();

                    b.HasIndex("ItemCategory", "ItemID", "CharaID", "Quantity");

                    b.HasIndex("ItemCategory", "ItemID", "RetainerID", "Quantity");

                    b.ToTable("InventorySlots");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Retainer", b =>
                {
                    b.Property<ulong>("RetainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("ClassID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Gear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("OwnerCharaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RetainerID");

                    b.HasIndex("OwnerCharaID");

                    b.ToTable("Retainers");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("Dps1")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("Dps2")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("Healer")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("Tank")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamID");

                    b.HasIndex("Dps1")
                        .IsUnique();

                    b.HasIndex("Dps2")
                        .IsUnique();

                    b.HasIndex("Healer")
                        .IsUnique();

                    b.HasIndex("Tank")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.InventorySlot", b =>
                {
                    b.HasOne("FFXIVCharaTracker.DB.Chara", "Chara")
                        .WithMany("Inventory")
                        .HasForeignKey("CharaID");

                    b.HasOne("FFXIVCharaTracker.DB.Retainer", "Retainer")
                        .WithMany("Inventory")
                        .HasForeignKey("RetainerID");

                    b.Navigation("Chara");

                    b.Navigation("Retainer");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Retainer", b =>
                {
                    b.HasOne("FFXIVCharaTracker.DB.Chara", "Owner")
                        .WithMany("Retainers")
                        .HasForeignKey("OwnerCharaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Team", b =>
                {
                    b.HasOne("FFXIVCharaTracker.DB.Chara", "Dps1A")
                        .WithOne("Dps1")
                        .HasForeignKey("FFXIVCharaTracker.DB.Team", "Dps1");

                    b.HasOne("FFXIVCharaTracker.DB.Chara", "Dps2A")
                        .WithOne("Dps2")
                        .HasForeignKey("FFXIVCharaTracker.DB.Team", "Dps2");

                    b.HasOne("FFXIVCharaTracker.DB.Chara", "HealerA")
                        .WithOne("Healer")
                        .HasForeignKey("FFXIVCharaTracker.DB.Team", "Healer");

                    b.HasOne("FFXIVCharaTracker.DB.Chara", "TankA")
                        .WithOne("Tank")
                        .HasForeignKey("FFXIVCharaTracker.DB.Team", "Tank");

                    b.Navigation("Dps1A");

                    b.Navigation("Dps2A");

                    b.Navigation("HealerA");

                    b.Navigation("TankA");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Chara", b =>
                {
                    b.Navigation("Dps1");

                    b.Navigation("Dps2");

                    b.Navigation("Healer");

                    b.Navigation("Inventory");

                    b.Navigation("Retainers");

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("FFXIVCharaTracker.DB.Retainer", b =>
                {
                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
