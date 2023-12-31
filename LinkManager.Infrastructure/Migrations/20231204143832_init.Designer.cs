﻿// <auto-generated />
using System;
using LinkManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinkManager.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231204143832_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LinkManager.Domain.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AgentKindId")
                        .HasColumnType("int");

                    b.Property<string>("Descripion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisteredTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentKindId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("LinkManager.Domain.AgentKind", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("AgentKinds");
                });

            modelBuilder.Entity("LinkManager.Domain.LinkEnd", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ActiveLinkFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("AgentChecked")
                        .HasColumnType("bit");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CheckedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LinkEndTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("LinkOutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("LinkEndTypeId");

                    b.HasIndex("LinkOutId")
                        .IsUnique();

                    b.ToTable("Links");
                });

            modelBuilder.Entity("LinkManager.Domain.LinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinkTypes");
                });

            modelBuilder.Entity("LinkManager.Domain.Agent", b =>
                {
                    b.HasOne("LinkManager.Domain.AgentKind", "AgentKind")
                        .WithMany("Agents")
                        .HasForeignKey("AgentKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgentKind");
                });

            modelBuilder.Entity("LinkManager.Domain.LinkEnd", b =>
                {
                    b.HasOne("LinkManager.Domain.Agent", "Agent")
                        .WithMany("Links")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinkManager.Domain.LinkType", "LinkEndType")
                        .WithMany("Links")
                        .HasForeignKey("LinkEndTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinkManager.Domain.LinkEnd", "In")
                        .WithOne("Out")
                        .HasForeignKey("LinkManager.Domain.LinkEnd", "LinkOutId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("In");

                    b.Navigation("LinkEndType");
                });

            modelBuilder.Entity("LinkManager.Domain.Agent", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("LinkManager.Domain.AgentKind", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("LinkManager.Domain.LinkEnd", b =>
                {
                    b.Navigation("Out")
                        .IsRequired();
                });

            modelBuilder.Entity("LinkManager.Domain.LinkType", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
