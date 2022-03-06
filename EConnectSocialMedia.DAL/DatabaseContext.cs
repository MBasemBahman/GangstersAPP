using EConnectSocialMedia.Entity.AccountEntity;
using EConnectSocialMedia.Entity.AuthEntity;
using EConnectSocialMedia.Entity.BeneficiaryRequestEntity;
using EConnectSocialMedia.Entity.ChatEntity;
using EConnectSocialMedia.Entity.CHIAEntity;
using EConnectSocialMedia.Entity.CommonEntity;
using EConnectSocialMedia.Entity.GroupEntity;
using EConnectSocialMedia.Entity.LocationEntity;
using EConnectSocialMedia.Entity.MainDataEntity;
using EConnectSocialMedia.Entity.NotificationEntity;
using EConnectSocialMedia.Entity.PostEntity;
using EConnectSocialMedia.Entity.ServiceProviderRequestEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static EConnectSocialMedia.Entity.EntityEnum;
using BC = BCrypt.Net.BCrypt;


namespace EConnectSocialMedia.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        #region Entities

        #region AccountEntity
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountState> AccountState { get; set; }
        public DbSet<AccountStateLang> AccountStateLang { get; set; }
        public DbSet<AccountTypeLang> AccountTypeLang { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<GenderLang> GenderLang { get; set; }
        public DbSet<AccountDevice> AccountDevice { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        #endregion

        #region AuthEntity

        public DbSet<AccessLevel> AccessLevel { get; set; }
        public DbSet<SystemRole> SystemRole { get; set; }
        public DbSet<SystemRolePremission> SystemRolePremission { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SystemView> SystemView { get; set; }

        #endregion

        #region ChatEntity
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatMember> ChatMember { get; set; }
        public DbSet<ChatType> ChatType { get; set; }
        public DbSet<ChatTypeLang> ChatTypeLang { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageStateLang> MessageStateLang { get; set; }
        public DbSet<MessageTypeLang> MessageTypeLang { get; set; }
        #endregion

        #region GroupEntity
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<GroupType> GroupType { get; set; }
        public DbSet<GroupTypeLang> GroupTypeLang { get; set; }
        #endregion

        #region MainDataEntity
        public DbSet<AppAbout> AppAbout { get; set; }
        public DbSet<AppIntro> AppIntro { get; set; }
        public DbSet<AppIntroLang> AppIntroLang { get; set; }
        public DbSet<QuestionsAndAnswers> QuestionsAndAnswers { get; set; }
        public DbSet<QuestionsAndAnswersLang> QuestionsAndAnswersLang { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<TermsAndConditionsLang> TermsAndConditionsLang { get; set; }
        #endregion

        #region PostEntity
        public DbSet<Post> Post { get; set; }
        public DbSet<PostAttachment> PostAttachment { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<PostCommentReaction> PostCommentReaction { get; set; }
        public DbSet<PostState> PostState { get; set; }
        public DbSet<PostStateLang> PostStateLang { get; set; }
        public DbSet<PostStateHistory> PostStateHistory { get; set; }
        public DbSet<PostType> PostType { get; set; }
        public DbSet<PostTypeLang> PostTypeLang { get; set; }
        public DbSet<PostReaction> PostReaction { get; set; }
        public DbSet<ReactionType> ReactionType { get; set; }
        public DbSet<ReactionTypeLang> ReactionTypeLang { get; set; }
        #endregion

        #region NotificationEntity

        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationAccount> NotificationAccount { get; set; }

        #endregion

        #region CHIA
        public DbSet<Partner> Partner { get; set; }
        public DbSet<ServiceProvider> ServiceProvider { get; set; }
        public DbSet<ServiceProviderCategory> ServiceProviderCategory { get; set; }
        public DbSet<TutorialCategory> TutorialCategory { get; set; }
        public DbSet<TutorialItem> TutorialItem { get; set; }
        public DbSet<UserFullinfoItem> UserFullinfoItem { get; set; }
        public DbSet<PartnerLang> PartnerLang { get; set; }
        public DbSet<ServiceProviderLang> ServiceProviderLang { get; set; }
        public DbSet<ServiceProviderCategoryLang> ServiceProviderCategoryLang { get; set; }
        public DbSet<TutorialCategoryLang> TutorialCategoryLang { get; set; }
        public DbSet<TutorialItemLang> TutorialItemLang { get; set; }
        public DbSet<UserFullinfoItemLang> UserFullinfoItemLang { get; set; }
        public DbSet<ServiceProviderAuthority> ServiceProviderAuthority { get; set; }
        public DbSet<ServiceProviderAuthorityLang> ServiceProviderAuthorityLang { get; set; }
        #endregion

        #region LocationEntity
        public DbSet<Governerate> Governerate { get; set; }
        public DbSet<GovernerateLang> GovernerateLang { get; set; }
        #endregion

        #region ServiceProviderRequestEntity

        public DbSet<ServiceProviderClassification> ServiceProviderClassification { get; set; }
        public DbSet<ServiceProviderClassificationLang> ServiceProviderClassificationLang { get; set; }
        public DbSet<ServiceProviderRequest> ServiceProviderRequest { get; set; }
        public DbSet<ServiceProviderRequestAttachment> ServiceProviderRequestAttachment { get; set; }

        #endregion

        #region BeneficiaryRequestEntity
        public DbSet<BeneficiaryRequest> BeneficiaryRequest { get; set; }
        public DbSet<BeneficiaryType> BeneficiaryType { get; set; }
        public DbSet<BeneficiaryTypeLang> BeneficiaryTypeLang { get; set; }
        public DbSet<BeneficiaryRequestAttachment> BeneficiaryRequestAttachment { get; set; }
        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultValues

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("CreatedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
              .Where(t => t.ClrType.IsSubclassOf(typeof(FullBaseEntity))))
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("LastModifiedAt")
                            .HasDefaultValueSql("getutcdate()");

                        x.Property("IsActive")
                            .HasDefaultValue(true);

                        x.Property("Sort")
                            .HasDefaultValue(0);
                    });
            }

            modelBuilder.Entity<Account>().Property(x => x.UniqueName).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Chat>().Property(x => x.LastActionAt).HasDefaultValueSql("getutcdate()");

            #endregion

            #region Unique Indexs

            modelBuilder.Entity<NotificationAccount>()
                       .HasIndex(a => new { a.Fk_Notification, a.Fk_Account })
                       .IsUnique();

            modelBuilder.Entity<ChatMember>()
                        .HasIndex(a => new { a.Fk_Chat, a.Fk_Account })
                        .IsUnique();

            modelBuilder.Entity<GroupMember>()
                        .HasIndex(a => new { a.Fk_Group, a.Fk_Account })
                        .IsUnique();

            modelBuilder.Entity<PostReaction>()
                        .HasIndex(a => new { a.Fk_Post, a.Fk_Account })
                        .IsUnique();

            modelBuilder.Entity<PostCommentReaction>()
                       .HasIndex(a => new { a.Fk_PostComment, a.Fk_Account })
                       .IsUnique();

            #endregion

            #region SeedData

            foreach (AccessLevelEnum value in Enum.GetValues(typeof(AccessLevelEnum)))
            {
                modelBuilder.Entity<AccessLevel>()
                            .HasData(new AccessLevel
                            {
                                Name = value.ToString(),
                                Id = (int)value
                            });
            }

            foreach (SystemRoleEnum value in Enum.GetValues(typeof(SystemRoleEnum)))
            {
                modelBuilder.Entity<SystemRole>()
                            .HasData(new SystemRole
                            {
                                Name = value.ToString(),
                                Id = (int)value,
                            });
            }

            foreach (SystemViewEnum value in Enum.GetValues(typeof(SystemViewEnum)))
            {

                modelBuilder.Entity<SystemView>()
                      .HasData(new SystemView
                      {
                          Name = value.ToString(),
                          DisplayName = value.ToString(),
                          Id = (int)value
                      });


            }

            foreach (AccountStateEnum value in Enum.GetValues(typeof(AccountStateEnum)))
            {
                modelBuilder.Entity<AccountState>()
                            .HasData(new AccountState
                            {
                                Name = value.ToString(),
                                Id = (int)value
                            });
            }

            foreach (AccountTypeEnum value in Enum.GetValues(typeof(AccountTypeEnum)))
            {
                modelBuilder.Entity<AccountType>()
                            .HasData(new AccountType
                            {
                                Name = value.ToString(),
                                Id = (int)value
                            });
            }

            foreach (PostStateEnum value in Enum.GetValues(typeof(PostStateEnum)))
            {
                modelBuilder.Entity<PostState>()
                            .HasData(new PostState
                            {
                                Name = value.ToString(),
                                Id = (int)value
                            });
            }

            foreach (GenderEnum value in Enum.GetValues(typeof(GenderEnum)))
            {
                modelBuilder.Entity<Gender>()
                            .HasData(new Gender
                            {
                                Name = value.ToString(),
                                Id = (int)value
                            });
            }

            #region AuthEntity

            #region SystemUser
            modelBuilder.Entity<SystemUser>()
           .HasData(
               new SystemUser
               {
                   Id = (int)SystemUserEnum.Developer,
                   Phone = "01069946657",
                   FullName = SystemUserEnum.Developer.ToString(),
                   JobTitle = SystemUserEnum.Developer.ToString(),
                   Email = "Developer@mail.com",
                   PasswordHash = BC.HashPassword("dev123456"),
                   IsActive = true,
                   Fk_SystemRole = (int)SystemRoleEnum.Developer
               }
           );
            #endregion

            #region SystemRolePermission
            modelBuilder.Entity<SystemRolePremission>()
             .HasData(
                 new SystemRolePremission
                 {
                     Id = 1,
                     Fk_SystemRole = (int)SystemRoleEnum.Developer,
                     Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                     Fk_SystemView = (int)SystemViewEnum.Home,
                 },
                 new SystemRolePremission
                 {
                     Id = 2,
                     Fk_SystemRole = (int)SystemRoleEnum.Developer,
                     Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                     Fk_SystemView = (int)SystemViewEnum.SystemUser,
                 },
                  new SystemRolePremission
                  {
                      Id = 3,
                      Fk_SystemRole = (int)SystemRoleEnum.Developer,
                      Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                      Fk_SystemView = (int)SystemViewEnum.SystemView,
                  },
                    new SystemRolePremission
                    {
                        Id = 4,
                        Fk_SystemRole = (int)SystemRoleEnum.Developer,
                        Fk_AccessLevel = (int)AccessLevelEnum.FullAccess,
                        Fk_SystemView = (int)SystemViewEnum.SystemRole,
                    }
             );
            #endregion

            #endregion

            #endregion
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entries = ChangeTracker.Entries();
            DateTime utcNow = DateTime.UtcNow;

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is FullBaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.LastModifiedAt = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedAt = utcNow;
                            trackable.LastModifiedAt = utcNow;
                            break;
                    }
                }
            }
        }
    }
}