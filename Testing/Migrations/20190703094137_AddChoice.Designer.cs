﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Testing.DAL;

namespace Testing.Migrations
{
    [DbContext(typeof(TestingDbContext))]
    [Migration("20190703094137_AddChoice")]
    partial class AddChoice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Testing.Models.Choice", b =>
                {
                    b.Property<Guid>("ChoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChoiceString");

                    b.Property<Guid>("QuestionId");

                    b.Property<bool>("isCorrect");

                    b.HasKey("ChoiceId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Testing.Models.Exam", b =>
                {
                    b.Property<Guid>("ExamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExamName");

                    b.Property<Guid>("SubjectId");

                    b.Property<string>("Version");

                    b.HasKey("ExamId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Testing.Models.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hint");

                    b.Property<int>("Point");

                    b.Property<int>("QuestionLevel");

                    b.Property<string>("QuestionString");

                    b.Property<int>("QuestionType");

                    b.Property<Guid>("TopicId");

                    b.HasKey("QuestionId");

                    b.HasIndex("TopicId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Testing.Models.QuestionExam", b =>
                {
                    b.Property<Guid>("QuestionExamId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExamId");

                    b.Property<Guid>("QuestionId");

                    b.HasKey("QuestionExamId");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionExams");
                });

            modelBuilder.Entity("Testing.Models.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SubjectLevel");

                    b.Property<string>("SubjectName");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Testing.Models.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChildId");

                    b.Property<Guid>("ParentId");

                    b.Property<string>("TopicName");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Testing.Models.Choice", b =>
                {
                    b.HasOne("Testing.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Testing.Models.Exam", b =>
                {
                    b.HasOne("Testing.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Testing.Models.Question", b =>
                {
                    b.HasOne("Testing.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Testing.Models.QuestionExam", b =>
                {
                    b.HasOne("Testing.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Testing.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
