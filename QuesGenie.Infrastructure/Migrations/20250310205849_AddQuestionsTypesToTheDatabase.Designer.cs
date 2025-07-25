﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuesGenie.Infrastructure.Data;

#nullable disable

namespace QuesGenie.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250310205849_AddQuestionsTypesToTheDatabase")]
    partial class AddQuestionsTypesToTheDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("AvatarFileName")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ForgetPasswordResetLinkRequestedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastEmailConfirmationToken")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Documents", b =>
                {
                    b.Property<string>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FileUrl")
                        .HasColumnType("text");

                    b.Property<string>("SubmissionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("DocumentId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.MatchingPairs", b =>
                {
                    b.Property<string>("PairId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("LeftSide")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RightSide")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PairId");

                    b.HasIndex("QuestionId");

                    b.ToTable("MatchingPairs");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.McqOptions", b =>
                {
                    b.Property<string>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("IsCorrectAnswer")
                        .HasColumnType("boolean");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("McqOptions");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Questions", b =>
                {
                    b.Property<string>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PageRange")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("QuestionSetId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("QuestionSetId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.QuestionsSets", b =>
                {
                    b.Property<string>("QuestionSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("GeneratedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubmissionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionSetId");

                    b.HasIndex("DocumentId")
                        .IsUnique();

                    b.HasIndex("SubmissionId");

                    b.ToTable("QuestionsSets");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.QuizResponses", b =>
                {
                    b.Property<string>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<bool>("IsCorrectAnswer")
                        .HasColumnType("boolean");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuizId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ResponseId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizResponses");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Quizzes", b =>
                {
                    b.Property<string>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("QuestionSetId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SubmitDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuizId");

                    b.HasIndex("QuestionSetId");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Submissions", b =>
                {
                    b.Property<string>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("SampleQuestions")
                        .HasColumnType("text");

                    b.Property<DateTime>("SubmissionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubmissionId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.FillTheBlankQuestions", b =>
                {
                    b.HasBaseType("QuesGenie.Domain.Entities.Questions");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("FillTheBlank");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.MatchingQuestions", b =>
                {
                    b.HasBaseType("QuesGenie.Domain.Entities.Questions");

                    b.ToTable("MatchingQuestions");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.McqQuestions", b =>
                {
                    b.HasBaseType("QuesGenie.Domain.Entities.Questions");

                    b.ToTable("McqQuestions");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.TrueFalseQuestions", b =>
                {
                    b.HasBaseType("QuesGenie.Domain.Entities.Questions");

                    b.Property<bool>("Answer")
                        .HasColumnType("boolean");

                    b.ToTable("TrueFalseQuestions");
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
                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", null)
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

                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.ApplicationUser", b =>
                {
                    b.OwnsMany("QuesGenie.Domain.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<string>("ApplicationUserId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("ExpiresOn")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("RevokedOn")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ApplicationUserId", "Id");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationUserId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Documents", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.Submissions", "Submission")
                        .WithMany("Documents")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.MatchingPairs", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.MatchingQuestions", "Question")
                        .WithMany("MatchingPairs")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.McqOptions", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.McqQuestions", "Question")
                        .WithMany("McqOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Questions", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.Documents", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesGenie.Domain.Entities.QuestionsSets", "QuestionSet")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("QuestionSet");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.QuestionsSets", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.Documents", "Document")
                        .WithOne("QuestionSet")
                        .HasForeignKey("QuesGenie.Domain.Entities.QuestionsSets", "DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesGenie.Domain.Entities.Submissions", "Submission")
                        .WithMany("QuestionSets")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.QuizResponses", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.Questions", "Question")
                        .WithMany("QuizResponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesGenie.Domain.Entities.Quizzes", "Quiz")
                        .WithMany("Responses")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Quizzes", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.QuestionsSets", "QuestionSet")
                        .WithMany("Quizzes")
                        .HasForeignKey("QuestionSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Submissions", b =>
                {
                    b.HasOne("QuesGenie.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Quizzes");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Documents", b =>
                {
                    b.Navigation("QuestionSet")
                        .IsRequired();
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Questions", b =>
                {
                    b.Navigation("QuizResponses");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.QuestionsSets", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Quizzes", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.Submissions", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("QuestionSets");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.MatchingQuestions", b =>
                {
                    b.Navigation("MatchingPairs");
                });

            modelBuilder.Entity("QuesGenie.Domain.Entities.McqQuestions", b =>
                {
                    b.Navigation("McqOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
