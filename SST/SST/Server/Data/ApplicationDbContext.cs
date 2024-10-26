using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SST.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VezaVI.Light;

namespace SST.Server.Data
{
    public class ApplicationDbContext : VezaDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Firm>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Firm");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.FirmDocuments)
                .WithOne(e => e.Firm)
                .HasForeignKey(e => e.FirmID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.StyleVariableValues)
                .WithOne(e => e.Firm)
                .HasForeignKey(e => e.FirmID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.FirmEmailSetting)
                .WithOne(e => e.Firm)
                .HasForeignKey<Firm>(x => x.FirmEmailSettingID);

                entity.HasMany(e => e.FirmCustomers)
                .WithOne(e => e.Firm)
                .HasForeignKey(e => e.FirmID);

                entity.HasMany(e => e.ScreenFields)
                .WithOne(e => e.Firm)
                .HasForeignKey(e => e.FirmID);

                entity.HasMany(e => e.PublicHolidays)
                .WithOne(e => e.Firm)
                .HasForeignKey(e => e.FirmID);

                entity.HasOne(e => e.FirmMeetingSetups)
                .WithOne(e => e.Firm)
                .HasForeignKey<Firm>(e => e.FirmMeetingSetupID);
            });

            builder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Document");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.FirmDocuments)
                .WithOne(e => e.Document)
                .HasForeignKey(e => e.DocumentID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.CustomerDocuments)
                .WithOne(e => e.Document)
                .HasForeignKey(e => e.DocumentID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_DocumentType");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Documents)
                .WithOne(e => e.DocumentType)
                .HasForeignKey(e => e.DocumentTypeID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<FirmDocument>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_FirmDocuments");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<StyleVariable>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_StyleVariable");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.StyleVariableValues)
                .WithOne(e => e.StyleVariable)
                .HasForeignKey(e => e.VariableID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<StyleVariableValue>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_StyleVariableValue");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<FirmEmailSetting>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_FirmEmailSetting");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Customer");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.CustomerDocuments)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerID);

                entity.HasOne(e => e.Firm)
                .WithMany(e => e.FirmCustomers)
                .HasForeignKey(e => e.FirmID);
            });

            builder.Entity<CustomerDocument>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_CustomerDocument");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Setting");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<Screen>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Screen");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.ScreenFields)
                .WithOne(e => e.Screen)
                .HasForeignKey(e => e.ScreenID);
            });

            builder.Entity<Field>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Field");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.ScreenFields)
                .WithOne(e => e.Field)
                .HasForeignKey(e => e.FieldID);
            });

            builder.Entity<ScreenField>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ScreenField");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<FirmMeetingSetup>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_FirmMeetingSetup");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<UserAvailability>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_UserAvailability");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Meeting");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<MeetingTimeSlot>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_MeetingTimeSlot");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<MeetingParticipant>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_MeetingParticipant");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_TimeSlot");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<Day>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Day");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.HasMany(e => e.UserAvailabilities)
                .WithOne(e => e.Day)
                .HasForeignKey(e => e.DayID);

                entity.HasMany(e => e.MeetingTimeSlots)
                .WithOne(e => e.Day)
                .HasForeignKey(e => e.DayID);
            });

            builder.Entity<PublicHoliday>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_PublicHoliday");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            builder.Entity<NonWorkingDay>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_NonWorkingDay");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });


            //'FK_ContractQuestionDataFields_ContractQuestions_QuestionID' 
            builder.Entity<ContractQuestionDataField>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ContractQuestionDataField");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionID)
                .OnDelete(DeleteBehavior.NoAction);
            });

            // 'FK_ContractQuestionAnswerDataFields_ContractDataFields_ContractDataFieldID
            builder.Entity<ContractQuestionAnswerDataField>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ContractQuestionAnswerDataField");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity
                .HasOne(x => x.ContractTransactionDataField)
                .WithMany()
                .HasForeignKey(x => x.ContractTransactionDataFieldID)
                .OnDelete(DeleteBehavior.NoAction);

                entity
                .HasOne(x => x.Answer)
                .WithMany()
                .HasForeignKey(x => x.AnswerID)
                .OnDelete(DeleteBehavior.NoAction);
            });


            //FK_CustomerDataFieldValues_Customers_CustomerID
            builder.Entity<CustomerDataFieldValue>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_CustomerDataFieldValue");
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }

        public override void Seed()
        {
            SubscriptionPlan[] subscriptionPlans = new SubscriptionPlan[]
            {
                new SubscriptionPlan()
                {
                    ID = new Guid("{74F0385D-19BB-4EDF-892E-BD66860D0A35}"),
                    Description = "Trail Package",
                    MaxUsers = 2,
                    MonthlyPrice = 0,
                    YearlyPrice = 0,
                    IsActive = false,
                    IsDefaultPlan = true,
                    ValidForDays = 14
                },
                new SubscriptionPlan()
                {
                    ID = new Guid("{2F5CBAF6-6778-4A26-AD53-1204EFC56878}"),
                    Description = "1 to 5 Users",
                    MaxUsers = 5,
                    MonthlyPrice = 89,
                    YearlyPrice = 82,
                    IsActive = true,
                    ValidForDays = 30
                },
                new SubscriptionPlan()
                {
                    ID = new Guid("{7D5E1AB2-6FCE-4116-A34A-0E156266B342}"),
                    Description = "6 to 10 Users",
                    MaxUsers = 10,
                    MonthlyPrice = 82,
                    YearlyPrice = 75,
                    IsActive = true,
                    ValidForDays = 30
                },
                new SubscriptionPlan()
                {
                    ID = new Guid("{F3FFA814-86FA-4E0F-AA90-D9AF9C7C799C}"),
                    Description = "11 to 15 Users",
                    MaxUsers = 15,
                    MonthlyPrice = 75,
                    YearlyPrice = 69,
                    IsActive = true,
                    ValidForDays = 30
                },
                new SubscriptionPlan()
                {
                    ID = new Guid("{172989E0-80EC-48D6-AECE-D11C47E231B2}"),
                    Description = "15+ Users",
                    MaxUsers = 100,
                    MonthlyPrice = 70,
                    YearlyPrice = 65,
                    IsActive = true,
                    ValidForDays = 30
                }
            };
            SubscriptionPlans.AddOrUpdate(subscriptionPlans);

            IntroStep[] introSteps = new IntroStep[]
            {
                new IntroStep()
                {
                    ID = new Guid("{38BF5D19-328C-4D10-BDCF-B790573C43AA}"),
                    StepName = "Welcome",
                    Description = "Thank you for registering, follow our quick tutorial to get started.",
                    ButtonText = "Get Started",
                    Url = "",
                    Sequence = 0,
                    AllowSkip = false
                },
                new IntroStep()
                {
                    ID = new Guid("{C7F95E4F-748E-4CA2-A2E9-1996E15E3F94}"),
                    StepName = "Step 1",
                    Description = "Configure your Company",
                    ButtonText = "Configure",
                    Url = "/companyprofile",
                    Sequence = 1
                },
                new IntroStep()
                {
                    ID = new Guid("{A30BF82B-49BC-4F7F-8682-8129737F214F}"),
                    StepName = "Step 2",
                    Description = "Select your Subscription Plan",
                    ButtonText = "Configure",
                    Url = "/subscriptionplans",
                    Sequence = 2
                },
                new IntroStep()
                {
                    ID = new Guid("{E29A1813-72AD-4A42-932A-CD26955C2FE5}"),
                    StepName = "Step 3",
                    Description = "Apply your Company branding",
                    ButtonText = "Style",
                    Url = "/companybranding",
                    Sequence = 3
                },
                new IntroStep()
                {
                    ID = new Guid("{9F331EED-0E91-4096-B29E-09316D5717F0}"),
                    StepName = "Step 4",
                    Description = "Configure your Email Settings",
                    ButtonText = "Configure",
                    Url = "/emailsettings",
                    Sequence = 4
                },
                new IntroStep()
                {
                    ID = new Guid("{67A2F857-4FFF-4779-898B-38DF3A339C6F}"),
                    StepName = "Step 5",
                    Description = "Configure your Email Templates",
                    ButtonText = "Configure",
                    Url = "/emailtemplates",
                    Sequence = 5
                },
                new IntroStep()
                {
                    ID = new Guid("{257333EA-24EA-4AE5-B109-AC83D57A5130}"),
                    StepName = "Step 6",
                    Description = "Invite your Firm's Users",
                    ButtonText = "Invite",
                    Url = "/firmusers",
                    Sequence = 6
                },
                new IntroStep()
                {
                    ID = new Guid("{D9DF90F2-0E3E-4950-AB8B-C1FCE4131485}"),
                    StepName = "Step 7",
                    Description = "Invite your Firm's Customers",
                    ButtonText = "Invite",
                    Url = "/customers",
                    Sequence = 7
                },
                new IntroStep()
                {
                    ID = new Guid("{EB996554-254E-4B20-A662-BAC47E8BD5A2}"),
                    StepName = "Finished",
                    Description = "You are now setup.",
                    ButtonText = "Finish",
                    Url = "",
                    Sequence = 8,
                    AllowSkip = false
                }
            };
            IntroSteps.AddOrUpdate(introSteps);

            /*Countries*/
            List<Country> countries = new List<Country>()
            {
                new Country() { ID = new Guid("{CA21511F-E1A8-41A0-ADAF-F34528737836}"), Name = "Afghanistan", DailingCode = "+93", ISO2 = "af" },
                new Country() { ID = new Guid("{986973F5-14EF-4863-9078-6390FD376514}"), Name = "Albania", DailingCode = "+355", ISO2 = "al" },
                new Country() { ID = new Guid("{2491BFF1-DAA4-42E6-B73F-75F229D89E0F}"), Name = "Algeria", DailingCode = "+213", ISO2 = "dz" },
                new Country() { ID = new Guid("{5492F310-3C1A-4136-AFD1-B84C2AEA229E}"), Name = "American Samoa", DailingCode = "+1-684", ISO2 = "as" },
                new Country() { ID = new Guid("{F9917695-901D-4E50-A727-2F7773774150}"), Name = "Andorra", DailingCode = "+376", ISO2 = "ad" },
                new Country() { ID = new Guid("{1EC1F75E-DD52-4F75-9D00-A2654CF18FD3}"), Name = "Angola", DailingCode = "+244", ISO2 = "ao" },
                new Country() { ID = new Guid("{5AF1FE69-6E64-431F-B8A7-2ED93A32967E}"), Name = "Anguilla", DailingCode = "+1-264", ISO2 = "ai" },
                new Country() { ID = new Guid("{85123B68-90B0-4870-B976-8B276773E84C}"), Name = "Antarctica", DailingCode = "+672", ISO2 = "aq" },
                new Country() { ID = new Guid("{47F01C3F-9D15-4211-8C29-77338EE2CC8F}"), Name = "Antigua and Barbuda", DailingCode = "+1-268", ISO2 = "ag" },
                new Country() { ID = new Guid("{3DB42A4A-F1B2-401A-863A-1AE1EC3A657F}"), Name = "Argentina", DailingCode = "+54", ISO2 = "ar" },
                new Country() { ID = new Guid("{31EB077D-2983-45CF-8F5B-B1F5BF4D421B}"), Name = "Armenia", DailingCode = "+374", ISO2 = "am" },
                new Country() { ID = new Guid("{357E82DE-7ED2-41E9-8787-B54ED3D57690}"), Name = "Aruba", DailingCode = "+297", ISO2 = "aw" },
                new Country() { ID = new Guid("{A4987FDD-FF7D-4D8B-8ECD-3DC1B985D7A7}"), Name = "Australia", DailingCode = "+61", ISO2 = "au" },
                new Country() { ID = new Guid("{C9B0382A-3B48-4C68-A0D6-515DBBEF49BA}"), Name = "Austria", DailingCode = "+43", ISO2 = "at" },
                new Country() { ID = new Guid("{EA37614F-A12E-44C9-834D-3EE1A4D10D8A}"), Name = "Azerbaijan", DailingCode = "+994", ISO2 = "az" },
                new Country() { ID = new Guid("{926B4301-9126-493F-8E0B-5F3D14BE01CF}"), Name = "Bahamas", DailingCode = "+1-242", ISO2 = "bs" },
                new Country() { ID = new Guid("{D4516674-8B70-48DC-94AF-DF0D89088D19}"), Name = "Bahrain", DailingCode = "+973", ISO2 = "bh" },
                new Country() { ID = new Guid("{D0DAD3EA-88FA-42F8-9866-918C30CFDBF0}"), Name = "Bangladesh", DailingCode = "+880", ISO2 = "bd" },
                new Country() { ID = new Guid("{88F71272-90D3-4A5D-A071-BAFB5CC01D48}"), Name = "Barbados", DailingCode = "+1-246", ISO2 = "bb" },
                new Country() { ID = new Guid("{06A58591-1D67-49CD-A0FA-E5307EC48850}"), Name = "Belarus", DailingCode = "+375", ISO2 = "by" },
                new Country() { ID = new Guid("{165BDEEB-28F1-4C90-A9FE-F3266CAEFD3D}"), Name = "Belgium", DailingCode = "+32", ISO2 = "be" },
                new Country() { ID = new Guid("{AA1921AC-FB5C-45EE-AAE1-25F84403D19B}"), Name = "Belize", DailingCode = "+501", ISO2 = "bz" },
                new Country() { ID = new Guid("{6A2E2399-0898-4267-9E9E-45CED2D7425F}"), Name = "Benin", DailingCode = "+229", ISO2 = "bj" },
                new Country() { ID = new Guid("{AB58322C-64C5-4BB4-8BDD-376E3FEC48BB}"), Name = "Bermuda", DailingCode = "+1-441", ISO2 = "bm" },
                new Country() { ID = new Guid("{F0F99A48-5107-49DE-B2AB-A7E22FA0550D}"), Name = "Bhutan", DailingCode = "+975", ISO2 = "bt" },
                new Country() { ID = new Guid("{BCDAA0B9-1A96-4AFE-BA6B-25172F7B8AC3}"), Name = "Bolivia", DailingCode = "+591", ISO2 = "bo" },
                new Country() { ID = new Guid("{45D96EFA-2FF0-4658-A8C3-17E79E39B18F}"), Name = "Bosnia and Herzegovina", DailingCode = "+387", ISO2 = "ba" },
                new Country() { ID = new Guid("{93A04994-BE4F-4267-99DB-11B23B23D14C}"), Name = "Botswana", DailingCode = "+267", ISO2 = "bw" },
                new Country() { ID = new Guid("{E20D7DE1-2A6A-410A-BDF4-6079A813089C}"), Name = "Brazil", DailingCode = "+55", ISO2 = "br" },
                new Country() { ID = new Guid("{9A87B028-BDFA-4D5A-B230-2937D1F3FB38}"), Name = "British Indian Ocean Territory", DailingCode = "+246", ISO2 = "io" },
                new Country() { ID = new Guid("{D556DCFF-F29D-4422-9A7B-BE9FB9F5C268}"), Name = "British Virgin Islands", DailingCode = "+1-284", ISO2 = "vg" },
                new Country() { ID = new Guid("{0E8F09C9-68F1-465D-A4FB-846FAA1CE332}"), Name = "Brunei", DailingCode = "+673", ISO2 = "bn" },
                new Country() { ID = new Guid("{E14F4EB3-F09E-4A87-9C21-7775FE943C1A}"), Name = "Bulgaria", DailingCode = "+359", ISO2 = "bg" },
                new Country() { ID = new Guid("{BD4D687B-26D4-4373-9910-62DDF39AD74D}"), Name = "Burkina Faso", DailingCode = "+226", ISO2 = "bf" },
                new Country() { ID = new Guid("{05CFCB30-4BA2-45B0-89D1-1A3BEF11FAA1}"), Name = "Burundi", DailingCode = "+257", ISO2 = "bi" },
                new Country() { ID = new Guid("{4683BCD2-970B-4254-91C3-D93BACB40277}"), Name = "Cambodia", DailingCode = "+855", ISO2 = "kh" },
                new Country() { ID = new Guid("{9CD93E17-CE78-4944-8F9D-2142C8DB60E1}"), Name = "Cameroon", DailingCode = "+237", ISO2 = "cm" },
                new Country() { ID = new Guid("{C81A2E73-B951-412B-A6C8-6CD78ECCE530}"), Name = "Canada", DailingCode = "+1", ISO2 = "ca" },
                new Country() { ID = new Guid("{CB228629-1668-4DA0-82DE-4B293C741DE0}"), Name = "Cape Verde", DailingCode = "+238", ISO2 = "cv" },
                new Country() { ID = new Guid("{27B51A72-EEB9-413C-8089-37D6F13FBCF6}"), Name = "Cayman Islands", DailingCode = "+1-345", ISO2 = "ky" },
                new Country() { ID = new Guid("{48F3E3C7-6EC6-42CC-9EC2-E7B459925ECD}"), Name = "Central African Republic", DailingCode = "+236", ISO2 = "cf" },
                new Country() { ID = new Guid("{9D8D8E7D-0E1D-4F4F-910E-6AF49355BFC4}"), Name = "Chad", DailingCode = "+235", ISO2 = "td" },
                new Country() { ID = new Guid("{B0C96B2A-67BD-4A93-A41B-318F6A007916}"), Name = "Chile", DailingCode = "+56", ISO2 = "cl" },
                new Country() { ID = new Guid("{624F30B3-4F0F-46E3-BD5F-046803F81A50}"), Name = "China", DailingCode = "+86", ISO2 = "cn" },
                new Country() { ID = new Guid("{518E92DA-856A-42FF-91A4-F9D05E0D2561}"), Name = "Christmas Island", DailingCode = "+61", ISO2 = "cx" },
                new Country() { ID = new Guid("{B6299011-012B-495D-B959-7FB90EAB44C0}"), Name = "Cocos Islands", DailingCode = "+61", ISO2 = "cc" },
                new Country() { ID = new Guid("{E379F852-5D10-4334-9751-6A30F702BA3A}"), Name = "Colombia", DailingCode = "+57", ISO2 = "co" },
                new Country() { ID = new Guid("{F5B91408-5ECA-4CAB-BC64-A88E7826620B}"), Name = "Comoros", DailingCode = "+269", ISO2 = "km" },
                new Country() { ID = new Guid("{A18E8FC4-040A-4C3B-ADCD-DA106BD941B5}"), Name = "Cook Islands", DailingCode = "+682", ISO2 = "ck" },
                new Country() { ID = new Guid("{7DC37B99-980F-4642-A03D-B596749C2CC6}"), Name = "Costa Rica", DailingCode = "+506", ISO2 = "cr" },
                new Country() { ID = new Guid("{385D91B7-8F7B-4E5A-88DB-D7B9D31FF975}"), Name = "Croatia", DailingCode = "+385", ISO2 = "hr" },
                new Country() { ID = new Guid("{51D4C61D-BB96-483C-9909-0FEE2CDFC92A}"), Name = "Cuba", DailingCode = "+53", ISO2 = "cu" },
                new Country() { ID = new Guid("{093A51DF-7D55-4F86-9A48-8045DBBAC863}"), Name = "Curacao", DailingCode = "+599", ISO2 = "cw" },
                new Country() { ID = new Guid("{6727BD84-D3D6-4527-9EFB-D9155EEEA3B5}"), Name = "Cyprus", DailingCode = "+357", ISO2 = "cy" },
                new Country() { ID = new Guid("{FAC8E64B-65E7-4537-9CC7-1070924A729B}"), Name = "Czech Republic", DailingCode = "+420", ISO2 = "cz" },
                new Country() { ID = new Guid("{D6DF1D32-EFAA-4B91-99FF-C59C2405B5BC}"), Name = "Democratic Republic of the Congo", DailingCode = "+243", ISO2 = "cd" },
                new Country() { ID = new Guid("{01CCAE5A-299F-4E15-94CB-0E0786BB3AC5}"), Name = "Denmark", DailingCode = "+45", ISO2 = "dk" },
                new Country() { ID = new Guid("{2E2B0A7F-07C0-4BE7-90FE-1BE36FE533D2}"), Name = "Djibouti", DailingCode = "+253", ISO2 = "dj" },
                new Country() { ID = new Guid("{FBF31C13-622D-40A7-B845-8ED1F14A323F}"), Name = "Dominica", DailingCode = "+1-767", ISO2 = "dm" },
                new Country() { ID = new Guid("{B1063AFE-46DF-4037-9615-809EDC82445D}"), Name = "Dominican Republic", DailingCode = "+1-809,+1-829,+1-849", ISO2 = "do" },
                new Country() { ID = new Guid("{5886395B-E2D3-41CF-AD81-4F0717B7C1B5}"), Name = "East Timor", DailingCode = "+670", ISO2 = "tl" },
                new Country() { ID = new Guid("{02F1C7BA-1438-48F6-90E0-0FC2C6697586}"), Name = "Ecuador", DailingCode = "+593", ISO2 = "ec" },
                new Country() { ID = new Guid("{C167C1B1-86E8-41B8-B142-06402E313D96}"), Name = "Egypt", DailingCode = "+20", ISO2 = "eg" },
                new Country() { ID = new Guid("{4B8806CC-410F-4B27-8B6A-39017C3AA749}"), Name = "El Salvador", DailingCode = "+503", ISO2 = "sv" },
                new Country() { ID = new Guid("{93BAE7A9-D1E4-4CB9-B921-E1848A349D3C}"), Name = "Equatorial Guinea", DailingCode = "+240", ISO2 = "gq" },
                new Country() { ID = new Guid("{4398688B-9BCA-4012-B881-A0EC478309C1}"), Name = "Eritrea", DailingCode = "+291", ISO2 = "er" },
                new Country() { ID = new Guid("{CBCA84EA-50F9-416F-856A-1DAD2207BC02}"), Name = "Estonia", DailingCode = "+372", ISO2 = "ee" },
                new Country() { ID = new Guid("{4BDDF8AB-953C-4EB6-AAF6-4B168E4FAEFE}"), Name = "Ethiopia", DailingCode = "+251", ISO2 = "et" },
                new Country() { ID = new Guid("{DEA35999-FEDB-43A2-8170-45CDFC4EE725}"), Name = "Falkland Islands", DailingCode = "+500", ISO2 = "fk" },
                new Country() { ID = new Guid("{BA513AFB-F3B0-4AF9-8FAB-D5E6CE3A1227}"), Name = "Faroe Islands", DailingCode = "+298", ISO2 = "fo" },
                new Country() { ID = new Guid("{CCD3F9DE-01C8-43C1-9992-7BFC088E57EB}"), Name = "Fiji", DailingCode = "+679", ISO2 = "fj" },
                new Country() { ID = new Guid("{5A62BC09-32A4-4CF7-87EA-DECE0FBB09E1}"), Name = "Finland", DailingCode = "+358", ISO2 = "fi" },
                new Country() { ID = new Guid("{CEB0236E-5FDF-4387-AA61-9AA15F00AC89}"), Name = "France", DailingCode = "+33", ISO2 = "fr" },
                new Country() { ID = new Guid("{2D16C745-C0E5-41C5-8E78-8AC155721368}"), Name = "French Polynesia", DailingCode = "+689", ISO2 = "pf" },
                new Country() { ID = new Guid("{9B77E013-0F13-4DEB-9521-38F1E34D80A5}"), Name = "Gabon", DailingCode = "+241", ISO2 = "ga" },
                new Country() { ID = new Guid("{F6896C73-9DB6-4AAD-85C0-24AE7A3D381F}"), Name = "Gambia", DailingCode = "+220", ISO2 = "gm" },
                new Country() { ID = new Guid("{050F9741-38D5-45C5-8FD5-C3B8B619EEA9}"), Name = "Georgia", DailingCode = "+995", ISO2 = "ge" },
                new Country() { ID = new Guid("{1932AC3C-7265-4D63-B5B6-C44474AE9163}"), Name = "Germany", DailingCode = "+49", ISO2 = "de" },
                new Country() { ID = new Guid("{9D164A61-DB34-48A6-85F0-42494AA9DD7E}"), Name = "Ghana", DailingCode = "+233", ISO2 = "gh" },
                new Country() { ID = new Guid("{AA9539DA-1D4D-49B7-8A42-6C498E366C5D}"), Name = "Gibraltar", DailingCode = "+350", ISO2 = "gi" },
                new Country() { ID = new Guid("{CECA1DCA-F8A1-41B6-9846-F1C96ABFA7B8}"), Name = "Greece", DailingCode = "+30", ISO2 = "gr" },
                new Country() { ID = new Guid("{10C03366-CB64-4CFF-8F9D-9B94358A5791}"), Name = "Greenland", DailingCode = "+299", ISO2 = "gl" },
                new Country() { ID = new Guid("{80453F4D-80BC-470E-A7BD-F65015875427}"), Name = "Grenada", DailingCode = "+1-473", ISO2 = "gd" },
                new Country() { ID = new Guid("{37EB620D-C31D-4BB3-9140-89C9F7B86BB1}"), Name = "Guam", DailingCode = "+1-671", ISO2 = "gu" },
                new Country() { ID = new Guid("{B547B04E-AF52-43A8-9CF9-66BFFC59D198}"), Name = "Guatemala", DailingCode = "+502", ISO2 = "gt" },
                new Country() { ID = new Guid("{562F60AE-FBDD-4B8C-87D7-08610EAD8188}"), Name = "Guernsey", DailingCode = "+44-1481", ISO2 = "gg" },
                new Country() { ID = new Guid("{2227CCB5-6F72-4E24-B654-AB1A3B7262CD}"), Name = "Guinea", DailingCode = "+224", ISO2 = "gn" },
                new Country() { ID = new Guid("{41DCDA9E-35C3-465B-A970-AFB8330F18F6}"), Name = "Guinea-Bissau", DailingCode = "+245", ISO2 = "gw" },
                new Country() { ID = new Guid("{3CBEF098-834A-4F26-A892-79FE676C1809}"), Name = "Guyana", DailingCode = "+592", ISO2 = "gy" },
                new Country() { ID = new Guid("{36BFA9FA-DF96-49EC-A8A1-97A8DFE538CE}"), Name = "Haiti", DailingCode = "+509", ISO2 = "ht" },
                new Country() { ID = new Guid("{40E40F41-2BE9-43F1-865E-04A66E915906}"), Name = "Honduras", DailingCode = "+504", ISO2 = "hn" },
                new Country() { ID = new Guid("{B1AA656F-27A4-4E0C-B878-5EE2E9BAB171}"), Name = "Hong Kong", DailingCode = "+852", ISO2 = "hk" },
                new Country() { ID = new Guid("{A9EF7735-FC31-41F9-B39B-A12BD8E08E2C}"), Name = "Hungary", DailingCode = "+36", ISO2 = "hu" },
                new Country() { ID = new Guid("{AA1F0DCD-F1A2-49B6-B616-8C257C118A88}"), Name = "Iceland", DailingCode = "+354", ISO2 = "is" },
                new Country() { ID = new Guid("{A2EBD0B5-E9E5-492B-8311-56CD6C8E7C87}"), Name = "India", DailingCode = "+91", ISO2 = "in" },
                new Country() { ID = new Guid("{F2153F08-C5B0-4490-9A26-08871F5333C3}"), Name = "Indonesia", DailingCode = "+62", ISO2 = "id" },
                new Country() { ID = new Guid("{987D0730-96A8-42D4-A220-81B0561FB2B8}"), Name = "Iran", DailingCode = "+98", ISO2 = "ir" },
                new Country() { ID = new Guid("{20D03B0C-3F61-4E1A-ABBD-064C41F947B9}"), Name = "Iraq", DailingCode = "+964", ISO2 = "iq" },
                new Country() { ID = new Guid("{45E10F38-6109-4D9C-A757-D1B1D18E0724}"), Name = "Ireland", DailingCode = "+353", ISO2 = "ie" },
                new Country() { ID = new Guid("{FB96C87B-8C09-4A09-9981-EE5F32C2A29A}"), Name = "Isle of Man", DailingCode = "+44-1624", ISO2 = "im" },
                new Country() { ID = new Guid("{F0E9F1E0-C048-48F4-8026-5451AE6FB6A3}"), Name = "Israel", DailingCode = "+972", ISO2 = "il" },
                new Country() { ID = new Guid("{9E04C45A-0CD7-4D23-90D8-4171270F6F6D}"), Name = "Italy", DailingCode = "+39", ISO2 = "it" },
                new Country() { ID = new Guid("{A7D885F3-A94F-4F6C-94F1-E162E7070DDE}"), Name = "Ivory Coast", DailingCode = "+225", ISO2 = "ci" },
                new Country() { ID = new Guid("{7413DD32-EF72-4FBC-90C3-37E5D61B9C37}"), Name = "Jamaica", DailingCode = "+1-876", ISO2 = "jm" },
                new Country() { ID = new Guid("{DA719EB8-95FC-4966-BE67-9B4B3F13339E}"), Name = "Japan", DailingCode = "+81", ISO2 = "jp" },
                new Country() { ID = new Guid("{C9EEEEAF-3424-429B-BB76-DABA8735BACA}"), Name = "Jersey", DailingCode = "+44-1534", ISO2 = "je" },
                new Country() { ID = new Guid("{022725E8-A6E1-4401-9398-0829FC76D34C}"), Name = "Jordan", DailingCode = "+962", ISO2 = "jo" },
                new Country() { ID = new Guid("{37A8A70D-4F4E-473C-BC45-268AEFD9E697}"), Name = "Kazakhstan", DailingCode = "+7", ISO2 = "kz" },
                new Country() { ID = new Guid("{BBB4657E-57E6-42DC-BC47-E48D79EF3474}"), Name = "Kenya", DailingCode = "+254", ISO2 = "ke" },
                new Country() { ID = new Guid("{4B8EF36C-BA68-423D-B1B8-6E7156E2BA9D}"), Name = "Kiribati", DailingCode = "+686", ISO2 = "ki" },
                new Country() { ID = new Guid("{F41B4C14-3E72-429E-821E-B7E62A1B3520}"), Name = "Kosovo", DailingCode = "+383", ISO2 = "xk" },
                new Country() { ID = new Guid("{ED6D9EB2-FAEC-4D61-88DC-AD0930ACBB2D}"), Name = "Kuwait", DailingCode = "+965", ISO2 = "kw" },
                new Country() { ID = new Guid("{1A790149-8A43-49CB-9B4C-304E50058EEC}"), Name = "Kyrgyzstan", DailingCode = "+996", ISO2 = "kg" },
                new Country() { ID = new Guid("{1DEC2A85-F079-45B7-9857-4F0B57C831B2}"), Name = "Laos", DailingCode = "+856", ISO2 = "la" },
                new Country() { ID = new Guid("{FC51744B-2E4B-4B3E-9E9A-A4098AB81052}"), Name = "Latvia", DailingCode = "+371", ISO2 = "lv" },
                new Country() { ID = new Guid("{ED7A2C65-7B90-4D45-8317-471FA65CDF34}"), Name = "Lebanon", DailingCode = "+961", ISO2 = "lb" },
                new Country() { ID = new Guid("{3EDD38DC-E462-40BB-8311-3DB3A3CF9E6A}"), Name = "Lesotho", DailingCode = "+266", ISO2 = "ls" },
                new Country() { ID = new Guid("{1A16559F-9364-4E4C-BE36-46DE8A3EE03B}"), Name = "Liberia", DailingCode = "+231", ISO2 = "lr" },
                new Country() { ID = new Guid("{5016FCD4-EC9A-4695-8AE8-B35B3C9B8D32}"), Name = "Libya", DailingCode = "+218", ISO2 = "ly" },
                new Country() { ID = new Guid("{BDDB8A84-E6D1-45BB-9383-84E44993B991}"), Name = "Liechtenstein", DailingCode = "+423", ISO2 = "li" },
                new Country() { ID = new Guid("{CE1C56BE-A1E4-42F6-AF64-FE1727694330}"), Name = "Lithuania", DailingCode = "+370", ISO2 = "lt" },
                new Country() { ID = new Guid("{48CAD648-7A73-47EF-9B5C-636DECCFC93A}"), Name = "Luxembourg", DailingCode = "+352", ISO2 = "lu" },
                new Country() { ID = new Guid("{1CD1BC0E-7A3E-4959-9460-8FE8C61877BA}"), Name = "Macau", DailingCode = "+853", ISO2 = "mo" },
                new Country() { ID = new Guid("{BA51A7CD-943E-475D-B223-8E9E3C9A1C60}"), Name = "Macedonia", DailingCode = "+389", ISO2 = "mk" },
                new Country() { ID = new Guid("{9194C216-2947-47CF-8DCE-5D88A86E8127}"), Name = "Madagascar", DailingCode = "+261", ISO2 = "mg" },
                new Country() { ID = new Guid("{7F3BE292-9150-4B9A-B8F0-4F8C7BC1B184}"), Name = "Malawi", DailingCode = "+265", ISO2 = "mw" },
                new Country() { ID = new Guid("{681D982F-98BF-418D-A730-9F2DD1EBDC74}"), Name = "Malaysia", DailingCode = "+60", ISO2 = "my" },
                new Country() { ID = new Guid("{80FC7898-123F-4A08-BC2E-323F0CF0D202}"), Name = "Maldives", DailingCode = "+960", ISO2 = "mv" },
                new Country() { ID = new Guid("{9C1782CD-FEA1-4991-9D79-2C73D33AC896}"), Name = "Mali", DailingCode = "+223", ISO2 = "ml" },
                new Country() { ID = new Guid("{64F1A7BC-71AB-415D-A5CA-3A3C8F0552F6}"), Name = "Malta", DailingCode = "+356", ISO2 = "mt" },
                new Country() { ID = new Guid("{F82C7722-6BEE-4781-8D40-FEB8A5136005}"), Name = "Marshall Islands", DailingCode = "+692", ISO2 = "mh" },
                new Country() { ID = new Guid("{452E1EF5-87FA-4BBD-85C7-B22017AFBDA3}"), Name = "Mauritania", DailingCode = "+222", ISO2 = "mr" },
                new Country() { ID = new Guid("{7BD6B1CF-5192-4D45-A898-D2630310343C}"), Name = "Mauritius", DailingCode = "+230", ISO2 = "mu" },
                new Country() { ID = new Guid("{D9CDDF44-2BCC-4B52-99E6-08732A4DE6E8}"), Name = "Mayotte", DailingCode = "+262", ISO2 = "yt" },
                new Country() { ID = new Guid("{E8398045-AF6A-4B44-B2D8-209F9A546EE4}"), Name = "Mexico", DailingCode = "+52", ISO2 = "mx" },
                new Country() { ID = new Guid("{558268EA-320C-420B-894A-1FD180C8C725}"), Name = "Micronesia", DailingCode = "+691", ISO2 = "fm" },
                new Country() { ID = new Guid("{910EA7E3-383A-448A-A9E5-313311795F8F}"), Name = "Moldova", DailingCode = "+373", ISO2 = "md" },
                new Country() { ID = new Guid("{83EC0CEB-A4C1-4CD1-A2A7-DB25B17D347F}"), Name = "Monaco", DailingCode = "+377", ISO2 = "mc" },
                new Country() { ID = new Guid("{DB99DE37-A2C6-4205-A315-9122AF1F31D6}"), Name = "Mongolia", DailingCode = "+976", ISO2 = "mn" },
                new Country() { ID = new Guid("{D24D5512-F8A6-4D75-97E6-EB06C6939FFD}"), Name = "Montenegro", DailingCode = "+382", ISO2 = "me" },
                new Country() { ID = new Guid("{65A7A7FB-F950-4796-98A2-C0FE0B64D09C}"), Name = "Montserrat", DailingCode = "+1-664", ISO2 = "ms" },
                new Country() { ID = new Guid("{4FA4CE3E-7BCF-4E78-8D1A-49279DC3EB47}"), Name = "Morocco", DailingCode = "+212", ISO2 = "ma" },
                new Country() { ID = new Guid("{B82ECB04-8E07-4D12-9896-709717EBD246}"), Name = "Mozambique", DailingCode = "+258", ISO2 = "mz" },
                new Country() { ID = new Guid("{EBCE2148-4074-437B-BEB4-238909A81B34}"), Name = "Myanmar", DailingCode = "+95", ISO2 = "mm" },
                new Country() { ID = new Guid("{F473CD22-6082-4E86-A1F3-C25BCDA16C09}"), Name = "Namibia", DailingCode = "+264", ISO2 = "na" },
                new Country() { ID = new Guid("{9860D338-949D-49EB-97A4-82B2EC48615B}"), Name = "Nauru", DailingCode = "+674", ISO2 = "nr" },
                new Country() { ID = new Guid("{06B6A7B4-ED3C-4854-8D7F-023BFD7B4897}"), Name = "Nepal", DailingCode = "+977", ISO2 = "np" },
                new Country() { ID = new Guid("{AD6E5A23-6AED-4429-9E9D-F03F7E473A9C}"), Name = "Netherlands", DailingCode = "+31", ISO2 = "nl" },
                new Country() { ID = new Guid("{ED49B068-E55D-40BC-A6B2-3667D23ED5F1}"), Name = "Netherlands Antilles", DailingCode = "+599", ISO2 = "an" },
                new Country() { ID = new Guid("{4DDA6FE0-C363-4B70-93F5-266A9B85C63A}"), Name = "New Caledonia", DailingCode = "+687", ISO2 = "nc" },
                new Country() { ID = new Guid("{185A556A-1D50-4329-9AE1-A1982C0B5BCB}"), Name = "New Zealand", DailingCode = "+64", ISO2 = "nz" },
                new Country() { ID = new Guid("{B61F21DE-ABC2-44F6-868D-BE338B6AA658}"), Name = "Nicaragua", DailingCode = "+505", ISO2 = "ni" },
                new Country() { ID = new Guid("{E2F81F4E-0319-4198-AAE6-4B629042BC02}"), Name = "Niger", DailingCode = "+227", ISO2 = "ne" },
                new Country() { ID = new Guid("{105BB463-C29A-442C-80E2-E312D2EC5080}"), Name = "Nigeria", DailingCode = "+234", ISO2 = "ng" },
                new Country() { ID = new Guid("{40A6263D-1154-4509-ACF0-D14419FCDB66}"), Name = "Niue", DailingCode = "+683", ISO2 = "nu" },
                new Country() { ID = new Guid("{E0EC5A99-00EC-463C-AAE3-A0D449F0B4AF}"), Name = "North Korea", DailingCode = "+850", ISO2 = "kp" },
                new Country() { ID = new Guid("{9997124C-38AE-47EC-BB8C-67CDE35BE98A}"), Name = "Northern Mariana Islands", DailingCode = "+1-670", ISO2 = "mp" },
                new Country() { ID = new Guid("{A8B46EC0-C54B-4E06-8708-80A7FAA03CA1}"), Name = "Norway", DailingCode = "+47", ISO2 = "no" },
                new Country() { ID = new Guid("{0D13CEF0-2755-4D4B-B7EC-15993F6D87B3}"), Name = "Oman", DailingCode = "+968", ISO2 = "om" },
                new Country() { ID = new Guid("{810E1553-B612-4CB7-AA30-4C829A9CCF46}"), Name = "Pakistan", DailingCode = "+92", ISO2 = "pk" },
                new Country() { ID = new Guid("{A4FDDF10-283B-428F-AFB0-1CBDD6DEF2EC}"), Name = "Palau", DailingCode = "+680", ISO2 = "pw" },
                new Country() { ID = new Guid("{E79A5FBB-5376-47DB-B2F1-5F8D7F866429}"), Name = "Palestine", DailingCode = "+970", ISO2 = "ps" },
                new Country() { ID = new Guid("{82138181-C03A-4B9A-A3A9-74EAC00F5656}"), Name = "Panama", DailingCode = "+507", ISO2 = "pa" },
                new Country() { ID = new Guid("{FF242AEA-3C71-4D96-B624-55F029931E53}"), Name = "Papua New Guinea", DailingCode = "+675", ISO2 = "pg" },
                new Country() { ID = new Guid("{E5675175-6ABD-4248-88C2-734EE557FAED}"), Name = "Paraguay", DailingCode = "+595", ISO2 = "py" },
                new Country() { ID = new Guid("{0CB8E18D-76E1-4D5B-BFD1-15997259EBA7}"), Name = "Peru", DailingCode = "+51", ISO2 = "pe" },
                new Country() { ID = new Guid("{65910DCB-E548-4029-8A24-445B2FF43C5B}"), Name = "Philippines", DailingCode = "+63", ISO2 = "ph" },
                new Country() { ID = new Guid("{E96ACC87-47AE-4770-836C-530141BA5B98}"), Name = "Pitcairn", DailingCode = "+64", ISO2 = "pn" },
                new Country() { ID = new Guid("{8A5F31AE-FF7D-4795-A5BE-4746AE99D5C7}"), Name = "Poland", DailingCode = "+48", ISO2 = "pl" },
                new Country() { ID = new Guid("{B76457C2-4E9E-4FEB-95F7-1F332CDC7255}"), Name = "Portugal", DailingCode = "+351", ISO2 = "pt" },
                new Country() { ID = new Guid("{5AE4182D-11CB-47AF-A2FF-927380B1961A}"), Name = "Puerto Rico", DailingCode = "+1-787,+1-939", ISO2 = "pr" },
                new Country() { ID = new Guid("{25750D30-C317-48CA-9D4E-BA30C8F4CD90}"), Name = "Qatar", DailingCode = "+974", ISO2 = "qa" },
                new Country() { ID = new Guid("{702478A5-F5D4-483B-B154-7240F5D1A2DD}"), Name = "Republic of the Congo", DailingCode = "+242", ISO2 = "cg" },
                new Country() { ID = new Guid("{13E15200-A456-42AD-AB0A-19A9C57F1D07}"), Name = "Reunion", DailingCode = "+262", ISO2 = "re" },
                new Country() { ID = new Guid("{9D755185-ED5D-4B4E-9284-428E89DAAC80}"), Name = "Romania", DailingCode = "+40", ISO2 = "ro" },
                new Country() { ID = new Guid("{9150BAD7-EC17-4C07-9461-53EA3F5CFA00}"), Name = "Russia", DailingCode = "+7", ISO2 = "ru" },
                new Country() { ID = new Guid("{9216C744-F188-475A-80F7-3F2846E06C31}"), Name = "Rwanda", DailingCode = "+250", ISO2 = "rw" },
                new Country() { ID = new Guid("{E871B1BD-2238-4660-844B-B09A200E0E34}"), Name = "Saint Barthelemy", DailingCode = "+590", ISO2 = "bl" },
                new Country() { ID = new Guid("{AD363960-69E2-4D2D-A766-4805E215A245}"), Name = "Saint Helena", DailingCode = "+290", ISO2 = "sh" },
                new Country() { ID = new Guid("{736B9BF8-D7F0-46CC-A99C-383DC919D044}"), Name = "Saint Kitts and Nevis", DailingCode = "+1-869", ISO2 = "kn" },
                new Country() { ID = new Guid("{E9E28B5F-4C7A-4146-8708-5713707E6905}"), Name = "Saint Lucia", DailingCode = "+1-758", ISO2 = "lc" },
                new Country() { ID = new Guid("{3C879B24-E9EB-4652-9007-70A0D8DFAB04}"), Name = "Saint Martin", DailingCode = "+590", ISO2 = "mf" },
                new Country() { ID = new Guid("{4B0CF3C4-7CAF-4B6D-99F5-2857717DCC1E}"), Name = "Saint Pierre and Miquelon", DailingCode = "+508", ISO2 = "pm" },
                new Country() { ID = new Guid("{2AC3C229-FA47-44C7-A8A2-0299AE1D33BA}"), Name = "Saint Vincent and the Grenadines", DailingCode = "+1-784", ISO2 = "vc" },
                new Country() { ID = new Guid("{4798BB3A-80E5-4986-943D-3829E4503256}"), Name = "Samoa", DailingCode = "+685", ISO2 = "ws" },
                new Country() { ID = new Guid("{8A62C1B1-63F3-4739-B33A-306FC7DBBFA1}"), Name = "San Marino", DailingCode = "+378", ISO2 = "sm" },
                new Country() { ID = new Guid("{783C351C-2DBA-448D-A1EC-E49576199264}"), Name = "Sao Tome and Principe", DailingCode = "+239", ISO2 = "st" },
                new Country() { ID = new Guid("{688DDAB4-80F3-472D-859A-8D7C76454569}"), Name = "Saudi Arabia", DailingCode = "+966", ISO2 = "sa" },
                new Country() { ID = new Guid("{F0BC78A7-799E-4BCE-B74E-85087D95A019}"), Name = "Senegal", DailingCode = "+221", ISO2 = "sn" },
                new Country() { ID = new Guid("{73648EF4-94C2-4718-988D-526A53D93809}"), Name = "Serbia", DailingCode = "+381", ISO2 = "rs" },
                new Country() { ID = new Guid("{B3AE00D1-FEB4-4049-806A-173439531BDC}"), Name = "Seychelles", DailingCode = "+248", ISO2 = "sc" },
                new Country() { ID = new Guid("{165DA773-82CE-47F0-8B65-9282FE2D0040}"), Name = "Sierra Leone", DailingCode = "+232", ISO2 = "sl" },
                new Country() { ID = new Guid("{4918131A-0717-4279-B429-CCFFB4A50A0E}"), Name = "Singapore", DailingCode = "+65", ISO2 = "sg" },
                new Country() { ID = new Guid("{94DAF469-8DE0-4C1A-9BAB-6085C9E8915D}"), Name = "Sint Maarten", DailingCode = "+1-721", ISO2 = "sx" },
                new Country() { ID = new Guid("{B4BA38CD-159A-4A7A-8485-471A0D315158}"), Name = "Slovakia", DailingCode = "+421", ISO2 = "sk" },
                new Country() { ID = new Guid("{E786C113-DB94-493F-869E-E9E509164D6F}"), Name = "Slovenia", DailingCode = "+386", ISO2 = "si" },
                new Country() { ID = new Guid("{94841CAF-5E00-45B5-A3E4-86C269B2B5A0}"), Name = "Solomon Islands", DailingCode = "+677", ISO2 = "sb" },
                new Country() { ID = new Guid("{FC3DF219-100A-4500-8DA6-65FF117901CE}"), Name = "Somalia", DailingCode = "+252", ISO2 = "so" },
                new Country() { ID = new Guid("{E06896EA-BB77-44A7-9477-043DF3942829}"), Name = "South Africa", DailingCode = "+27", ISO2 = "za" },
                new Country() { ID = new Guid("{F5DA9CE9-2FF0-4DD8-8B1A-0CC4907EFBB4}"), Name = "South Korea", DailingCode = "+82", ISO2 = "kr" },
                new Country() { ID = new Guid("{C17AD73C-9732-4B8B-ADD8-7EB871AE4033}"), Name = "South Sudan", DailingCode = "+211", ISO2 = "ss" },
                new Country() { ID = new Guid("{3D06E8FF-6A87-4A66-AD41-8977998C4698}"), Name = "Spain", DailingCode = "+34", ISO2 = "es" },
                new Country() { ID = new Guid("{676C801A-5FB7-4B1B-9C06-5CCED1BE6CFC}"), Name = "Sri Lanka", DailingCode = "+94", ISO2 = "lk" },
                new Country() { ID = new Guid("{386B11D3-7CA1-4BC0-94C8-9CA87E7C18F8}"), Name = "Sudan", DailingCode = "+249", ISO2 = "sd" },
                new Country() { ID = new Guid("{078DA1FE-A578-4359-83EA-8C18C590F687}"), Name = "Suriname", DailingCode = "+597", ISO2 = "sr" },
                new Country() { ID = new Guid("{C8CA0780-DF9D-46C3-8B34-3FD9E69DFD0B}"), Name = "Svalbard and Jan Mayen", DailingCode = "+47", ISO2 = "sj" },
                new Country() { ID = new Guid("{03BCD044-0B9C-48B9-B896-933A356595FE}"), Name = "Swaziland", DailingCode = "+268", ISO2 = "sz" },
                new Country() { ID = new Guid("{EFEE3D9F-FB77-4FD2-AC5E-A08BB4EFC2D5}"), Name = "Sweden", DailingCode = "+46", ISO2 = "se" },
                new Country() { ID = new Guid("{66A426B7-DDB6-4A22-B0C9-33B9B1499D79}"), Name = "Switzerland", DailingCode = "+41", ISO2 = "ch" },
                new Country() { ID = new Guid("{91070F26-E864-45D3-9406-5E6A2B4AEC72}"), Name = "Syria", DailingCode = "+963", ISO2 = "sy" },
                new Country() { ID = new Guid("{22DABF99-0FA6-47BF-9EB9-394781DC021C}"), Name = "Taiwan", DailingCode = "+886", ISO2 = "tw" },
                new Country() { ID = new Guid("{2D5B89E5-E64C-4F8E-8083-216534488DD2}"), Name = "Tajikistan", DailingCode = "+992", ISO2 = "tj" },
                new Country() { ID = new Guid("{B598E9F3-8E5D-4B14-9684-C8E43F275D0F}"), Name = "Tanzania", DailingCode = "+255", ISO2 = "tz" },
                new Country() { ID = new Guid("{455B9FB7-88A9-44BA-8AE5-E0ABC815780F}"), Name = "Thailand", DailingCode = "+66", ISO2 = "th" },
                new Country() { ID = new Guid("{966166DD-4ECE-42FC-825D-4633263507A3}"), Name = "Togo", DailingCode = "+228", ISO2 = "tg" },
                new Country() { ID = new Guid("{E58B859C-DEED-4566-B65F-62376503BC86}"), Name = "Tokelau", DailingCode = "+690", ISO2 = "tk" },
                new Country() { ID = new Guid("{4109222B-266B-4150-8ACD-010AF00632C2}"), Name = "Tonga", DailingCode = "+676", ISO2 = "to" },
                new Country() { ID = new Guid("{071272E7-49E1-4F7F-8AD4-66394823AB0C}"), Name = "Trinidad and Tobago", DailingCode = "+1-868", ISO2 = "tt" },
                new Country() { ID = new Guid("{5E1AA4EC-912B-4B2E-99E4-434A1C127CD2}"), Name = "Tunisia", DailingCode = "+216", ISO2 = "tn" },
                new Country() { ID = new Guid("{1304145E-7690-422D-ABB1-D0EC4B994F4F}"), Name = "Turkey", DailingCode = "+90", ISO2 = "tr" },
                new Country() { ID = new Guid("{B8B16E12-1F4D-4B19-96C5-01B0161119C1}"), Name = "Turkmenistan", DailingCode = "+993", ISO2 = "tm" },
                new Country() { ID = new Guid("{275414E1-ED52-4808-ACFF-C1D87114499E}"), Name = "Turks and Caicos Islands", DailingCode = "+1-649", ISO2 = "tc" },
                new Country() { ID = new Guid("{D0369782-C0B1-49FB-80D6-B74C01C12741}"), Name = "Tuvalu", DailingCode = "+688", ISO2 = "tv" },
                new Country() { ID = new Guid("{4792D198-1FB1-41E2-9ADA-604A9467F210}"), Name = "U.S. Virgin Islands", DailingCode = "+1-340", ISO2 = "vi" },
                new Country() { ID = new Guid("{41E27160-A7FB-402C-B4D8-BAA272F102D9}"), Name = "Uganda", DailingCode = "+256", ISO2 = "ug" },
                new Country() { ID = new Guid("{EDAB9303-0F9D-42B4-AA96-E8A9B71B755B}"), Name = "Ukraine", DailingCode = "+380", ISO2 = "ua" },
                new Country() { ID = new Guid("{1FC65AC6-4590-4D51-BA3D-C4863610869E}"), Name = "United Arab Emirates", DailingCode = "+971", ISO2 = "ae" },
                new Country() { ID = new Guid("{FC4F7AD7-5944-41AA-868D-883FCE264507}"), Name = "United Kingdom", DailingCode = "+44", ISO2 = "gb" },
                new Country() { ID = new Guid("{95660D53-8D82-4962-B02A-7F497849C15F}"), Name = "United States", DailingCode = "+1", ISO2 = "us" },
                new Country() { ID = new Guid("{D813492E-CF17-4867-9E48-CBD1250EBFEA}"), Name = "Uruguay", DailingCode = "+598", ISO2 = "uy" },
                new Country() { ID = new Guid("{C902CBA8-056E-44DC-A24D-BF3CCE9C7550}"), Name = "Uzbekistan", DailingCode = "+998", ISO2 = "uz" },
                new Country() { ID = new Guid("{97C7B7AD-177C-41A8-B9DC-7E65DC5DE744}"), Name = "Vanuatu", DailingCode = "+678", ISO2 = "vu" },
                new Country() { ID = new Guid("{FD8FC74F-BC73-4B2C-AE17-3C74612DAF1A}"), Name = "Vatican", DailingCode = "+379", ISO2 = "va" },
                new Country() { ID = new Guid("{C06E0AC4-4400-4D1B-8B2F-9B376986C6F9}"), Name = "Venezuela", DailingCode = "+58", ISO2 = "ve" },
                new Country() { ID = new Guid("{6CC71D31-C112-4234-B2D4-ABBF86AB5AFE}"), Name = "Vietnam", DailingCode = "+84", ISO2 = "vn" },
                new Country() { ID = new Guid("{84ADC9ED-83A5-4FAE-A4A2-58B36B18607E}"), Name = "Wallis and Futuna", DailingCode = "+681", ISO2 = "wf" },
                new Country() { ID = new Guid("{9298B1DC-1E39-4A29-BD69-A7D7303564A8}"), Name = "Western Sahara", DailingCode = "+212", ISO2 = "eh" },
                new Country() { ID = new Guid("{6AC78E17-98EB-4559-8EAD-21B6CEC703E9}"), Name = "Yemen", DailingCode = "+967", ISO2 = "ye" },
                new Country() { ID = new Guid("{C50432CA-F9B1-4FEB-843A-1EE3CEE46A7F}"), Name = "Zambia", DailingCode = "+260", ISO2 = "zm" },
                new Country() { ID = new Guid("{2EA3E44D-BD9F-497B-9BD3-11976AA8FC12}"), Name = "Zimbabwe", DailingCode = "+263", ISO2 = "zw" }
            };
            Countries.AddOrUpdate(countries.ToArray());

            List<PaymentGate> paymentGates = new List<PaymentGate>()
            {
                new PaymentGate()
                {
                     ID = new Guid("{D12C22F4-1A72-4993-97F8-A04E398489FE}"),
                     APIKey = "10011072130",
                     FirmID = null,
                     Supplier = (int)PaymentSupplier.PayGate
                }
            };
            PaymentGates.AddOrUpdate(paymentGates.ToArray());
        }

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<FirmDocument> FirmDocuments { get; set; }
        public DbSet<StyleVariable> StyleVariables { get; set; }
        public DbSet<StyleVariableValue> StyleVariableValues { get; set; }
        public DbSet<FirmEmailSetting> FirmEmailSettings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDocument> CustomerDocuments { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<ScreenField> ScreenFields { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<FirmSubscriptionPlan> FirmSubscriptionPlans { get; set; }
        public DbSet<IntroStep> IntroSteps { get; set; }
        public DbSet<FirmIntroStep> CompanyIntroSteps { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<FirmMeetingSetup> FirmMeetingSetups { get; set; }
        public DbSet<UserAvailability> UserAvailabilities { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingTimeSlot> MeetingTimeSlots { get; set; }
        public DbSet<MeetingParticipant> MeetingParticipants { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }
        public DbSet<NonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ContractTransaction> ContractTransactions { get; set; }
        public DbSet<ContractTransactionDataField> ContractTransactionDataFields { get; set; }
        public DbSet<ContractQuestion> ContractQuestions { get; set; }
        public DbSet<ContractQuestionAnswer> ContractQuestionAnswers { get; set; }
        public DbSet<ContractQuestionAnswerDataField> ContractQuestionAnswerDataFields { get; set; }
        public DbSet<ContractQuestionDataField> ContractQuestionDataFields { get; set; }
        public DbSet<CustomerDataField> CustomerDataFields { get; set; }
        public DbSet<CustomerDataFieldValue> CustomerDataFieldValues { get; set; }
        public DbSet<ContractClause> ContractClauses { get; set; }
        public DbSet<ContractClauseElement> ContractClauseElements { get; set; }
        public DbSet<ContractTransactionTemplate> ContractTransactionTemplates { get; set; }
        public DbSet<ContractTemplateElement> ContractTemplateElements { get; set; }
        public DbSet<ContractHistory> ContractHistories { get; set; }
        public DbSet<FirmStyling> FirmStylings { get; set; }
        public DbSet<StoreCustomer> StoreCustomers { get; set; }
        public DbSet<PaymentGate> PaymentGates { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<ContractQuestionIgnoredContractClause> ContractQuestionIgnoredContractClauses { get; set; }
        public DbSet<ContractTransactionEntity> ContractTransactionEntities { get; set; }
        public DbSet<ContractTransactionEntityDataField> ContractTransactionEntityDataFields { get; set; }
        public DbSet<ContractTransactionEntityClause> ContractTransactionEntityClauses { get; set; }
        public DbSet<ContractQuestionTemplate> ContractQuestionTemplates { get; set; }
        public DbSet<ContractQuestionAnswerIgnoredClause> ContractQuestionAnswerIgnoredClauses { get; set; }

    }
}
