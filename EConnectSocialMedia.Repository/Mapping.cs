using GangstersAPP.ServiceEntity.LocationEntity;
using GangstersAPP.ServiceEntity.ServiceProviderRequestEntity;

namespace GangstersAPP.Repository
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });

            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());

            #region ServiceModel

            #region AccountEntity
            CreateMap<Account, AccountModel>()
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.AccountState, opt => opt.Ignore())
                .ForMember(dest => dest.AccountType, opt => opt.Ignore());

            CreateMap<AccountDevice, AccountDeviceModel>()
                .ForMember(dest => dest.Account, opt => opt.Ignore());

            CreateMap<AccountState, AccountStateModel>();

            CreateMap<AccountType, AccountTypeModel>();

            CreateMap<Gender, GenderModel>();

            CreateMap<RegisterModel, Account>();

            CreateMap<AccountEditModel, Account>();

            CreateMap<AccountDeviceCreateModel, AccountDevice>();


            #endregion

            #region ChatEntity
            CreateMap<Chat, ChatModel>()
                .ForMember(dest => dest.ChatType, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .ForMember(dest => dest.ChatMembers, opt => opt.Ignore());

            CreateMap<ChatMember, ChatMemberModel>()
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.Chat, opt => opt.Ignore());

            CreateMap<ChatType, ChatTypeModel>();

            CreateMap<Message, MessageModel>()
                .ForMember(dest => dest.Chat, opt => opt.Ignore())
                .ForMember(dest => dest.MessageState, opt => opt.Ignore())
                .ForMember(dest => dest.MessageType, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore());

            CreateMap<MessageState, MessageStateModel>();

            CreateMap<MessageType, MessageTypeModel>();

            CreateMap<ChatCreateModel, Chat>()
                .ForMember(dest => dest.ChatMembers, opt => opt.Ignore());

            CreateMap<ChatEditModel, Chat>();

            CreateMap<MessageCreateModel, Message>()
                .ForMember(dest => dest.FileURL, opt => opt.Ignore());

            CreateMap<MessageEditModel, Message>();

            #endregion

            #region GroupEntity
            CreateMap<Group, GroupModel>()
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.GroupType, opt => opt.Ignore());

            CreateMap<GroupMember, GroupMemberModel>()
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore());

            CreateMap<GroupType, GroupTypeModel>();

            CreateMap<GroupCreateModel, Group>()
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore());

            CreateMap<GroupEditModel, Group>()
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore());
            #endregion

            #region MainDataEntity
            CreateMap<AppAbout, AppAboutModel>();

            CreateMap<AppIntro, AppIntroModel>()
                .ForMember(dest => dest.AccountType, opt => opt.Ignore());

            CreateMap<QuestionsAndAnswers, QuestionsAndAnswersModel>();

            CreateMap<TermsAndConditions, TermsAndConditionsModel>();

            #endregion

            #region PostEntity

            CreateMap<PostCreateModel, Post>()
                .ForMember(dest => dest.PostAttachments, opt => opt.Ignore());
            CreateMap<PostEditModel, Post>();

            CreateMap<Post, PostModel>()
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.PostAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.PostType, opt => opt.Ignore())
                .ForMember(dest => dest.OldPost, opt => opt.Ignore());

            CreateMap<PostAttachment, PostAttachmentModel>()
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<PostCommentCreateModel, PostComment>();
            CreateMap<PostCommentEditModel, PostComment>();

            CreateMap<PostComment, PostCommentModel>()
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.OldPostComment, opt => opt.Ignore());

            CreateMap<PostCommentReactionCreateModel, PostCommentReaction>();

            CreateMap<PostCommentReaction, PostCommentReactionModel>()
                .ForMember(dest => dest.PostComment, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.ReactionType, opt => opt.Ignore());

            CreateMap<PostReactionCreateModel, PostReaction>();

            CreateMap<PostReaction, PostReactionModel>()
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.ReactionType, opt => opt.Ignore());

            CreateMap<PostState, PostStateModel>();

            CreateMap<PostStateHistory, PostStateHistoryModel>()
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.PostState, opt => opt.Ignore());

            CreateMap<PostType, PostTypeModel>();

            CreateMap<ReactionType, ReactionTypeModel>();

            #endregion

            #region NotificationEntity

            CreateMap<Notification, NotificationModel>();

            #endregion

            #region CHIAEntity

            CreateMap<UserFullinfoItem, UserFullinfoItemModel>();

            CreateMap<ServiceProvider, ServiceProviderModel>()
                .ForMember(dest => dest.ServiceProviderCategory, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceProviderAuthority, opt => opt.Ignore());

            CreateMap<ServiceProviderCategory, ServiceProviderCategoryModel>();

            CreateMap<TutorialCategory, TutorialCategoryModel>();

            CreateMap<TutorialItem, TutorialItemModel>()
                .ForMember(dest => dest.TutorialCategory, opt => opt.Ignore());

            CreateMap<Partner, PartnerModel>();

            CreateMap<ServiceProviderAuthority, ServiceProviderAuthorityModel>();


            #endregion

            #region LocationEntity

            CreateMap<Governerate, GovernerateModel>();

            #endregion

            #region ServiceProviderRequestEntity

            CreateMap<ServiceProviderClassification, ServiceProviderClassificationModel>();

            CreateMap<ServiceProviderRequestCreateModel, ServiceProviderRequest>();
            CreateMap<ServiceProviderRequest, ServiceProviderRequestModel>()
                .ForMember(dest => dest.ServiceProviderRequestAttachments, opt => opt.Ignore());

            CreateMap<ServiceProviderRequestAttachment, ServiceProviderRequestAttachmentModel>();


            #endregion

            #region BeneficiaryRequestEntity
            CreateMap<BeneficiaryType, BeneficiaryTypeModel>();

            CreateMap<BeneficiaryRequestCreateModel, BeneficiaryRequest>();
            CreateMap<BeneficiaryRequest, BeneficiaryRequestModel>()
                .ForMember(dest => dest.BeneficiaryRequestAttachments, opt => opt.Ignore());

            CreateMap<BeneficiaryRequestAttachment, BeneficiaryRequestAttachmentModel>();
            #endregion

            #endregion

            #region DashboardModel

            #region MainDataEntity
            CreateMap<AppAbout, AppAbout>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());



            CreateMap<AppIntroLang, AppIntro>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AppIntroLang, AppIntroLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<AppIntro, AppIntro>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.AccountType, opt => opt.Ignore())
               .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<TermsAndConditions, TermsAndConditions>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<TermsAndConditionsLang, TermsAndConditions>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TermsAndConditionsLang, TermsAndConditionsLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<QuestionsAndAnswers, QuestionsAndAnswers>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<QuestionsAndAnswersLang, QuestionsAndAnswers>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<QuestionsAndAnswersLang, QuestionsAndAnswersLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            #endregion

            #region AccountEntity
            CreateMap<AccountDevice, AccountDevice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<AccountState, AccountState>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Accounts, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AccountStateLang, AccountState>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AccountStateLang, AccountStateLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<Gender, Gender>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Accounts, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<GenderLang, Gender>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<GenderLang, GenderLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<AccountType, AccountType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Accounts, opt => opt.Ignore())
                .ForMember(dest => dest.AppIntros, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AccountTypeLang, AccountType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AccountTypeLang, AccountTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());



            CreateMap<Account, Account>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.AccountDevices, opt => opt.Ignore())
                .ForMember(dest => dest.AccountState, opt => opt.Ignore())
                .ForMember(dest => dest.AccountType, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokens, opt => opt.Ignore())
                .ForMember(dest => dest.ChatMembers, opt => opt.Ignore())
                .ForMember(dest => dest.PostCommentReactions, opt => opt.Ignore())
                .ForMember(dest => dest.PostComments, opt => opt.Ignore())
                .ForMember(dest => dest.PostReactions, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region PostEntity
            CreateMap<Post, Post>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.PostReactions, opt => opt.Ignore())
                .ForMember(dest => dest.PostState, opt => opt.Ignore())
                .ForMember(dest => dest.PostAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.PostComments, opt => opt.Ignore())
                .ForMember(dest => dest.PostStateHistories, opt => opt.Ignore())
                .ForMember(dest => dest.PostType, opt => opt.Ignore())
                .ForMember(dest => dest.SharedPosts, opt => opt.Ignore())
                .ForMember(dest => dest.OldPost, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<PostState, PostState>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.PostStateHistories, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<PostStateLang, PostState>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PostStateLang, PostStateLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<PostType, PostType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<PostTypeLang, PostType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PostTypeLang, PostTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<ReactionType, ReactionType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PostReactions, opt => opt.Ignore())
                .ForMember(dest => dest.PostCommentReactions, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ReactionTypeLang, ReactionType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ReactionTypeLang, ReactionTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<PostComment, PostComment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.OldPostComment, opt => opt.Ignore())
                .ForMember(dest => dest.SharedPostComments, opt => opt.Ignore())
                .ForMember(dest => dest.PostCommentReactions, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region GroupEntity
            CreateMap<GroupType, GroupType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Groups, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<GroupTypeLang, GroupType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<GroupTypeLang, GroupTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());



            CreateMap<Group, Group>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.GroupType, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region ChatEntity
            CreateMap<MessageState, MessageState>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.Messages, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<MessageStateLang, MessageState>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<MessageStateLang, MessageStateLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<MessageType, MessageType>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.Messages, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<MessageTypeLang, MessageType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<MessageTypeLang, MessageTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<ChatType, ChatType>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.Chats, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ChatTypeLang, ChatType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ChatTypeLang, ChatTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region AuthEntity

            CreateMap<SystemView, SystemView>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SystemRolePremissions, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<SystemRole, SystemRole>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SystemRolePremissions, opt => opt.Ignore())
                .ForMember(dest => dest.SystemUsers, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<SystemUser, SystemUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SystemRole, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            #endregion

            #region CHIAEntity
            CreateMap<UserFullinfoItem, UserFullinfoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Icon, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<UserFullinfoItemLang, UserFullinfoItem>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserFullinfoItemLang, UserFullinfoItemLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<Partner, Partner>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<PartnerLang, Partner>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PartnerLang, PartnerLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProvider, ServiceProvider>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
               .ForMember(dest => dest.ServiceProviderCategory, opt => opt.Ignore())
               .ForMember(dest => dest.ServiceProviderAuthority, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderLang, ServiceProvider>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceProviderLang, ServiceProviderLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderCategory, ServiceProviderCategory>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ServiceProviders, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderCategoryLang, ServiceProviderCategory>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceProviderCategoryLang, ServiceProviderCategoryLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<TutorialCategory, TutorialCategory>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.TutorialItems, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<TutorialCategoryLang, TutorialCategory>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TutorialCategoryLang, TutorialCategoryLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<TutorialItem, TutorialItem>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
               .ForMember(dest => dest.TutorialCategory, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<TutorialItemLang, TutorialItem>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TutorialItemLang, TutorialItemLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderAuthority, ServiceProviderAuthority>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.ServiceProviders, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderAuthorityLang, ServiceProviderAuthority>()
             .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
             .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
             .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceProviderAuthorityLang, ServiceProviderAuthorityLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region LocationEntity
            CreateMap<Governerate, Governerate>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.ServiceProviderRequests, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<GovernerateLang, Governerate>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<GovernerateLang, GovernerateLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #region ServiceProviderRequestEntity
            CreateMap<ServiceProviderClassification, ServiceProviderClassification>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.ServiceProviderRequests, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<ServiceProviderClassificationLang, ServiceProviderClassification>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceProviderClassificationLang, ServiceProviderClassificationLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<ServiceProviderRequest, ServiceProviderRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Governerate, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceProviderClassification, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceProviderRequestAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            #endregion

            #region BeneficiaryRequestEntity

            CreateMap<BeneficiaryType, BeneficiaryType>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.BeneficiaryRequests, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<BeneficiaryTypeLang, BeneficiaryType>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<BeneficiaryTypeLang, BeneficiaryTypeLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
            #endregion

            #endregion
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return DataManipulate.GetDateTimeString(source);
        }
    }

    public class DataManipulate
    {
        public static string DateFormat => "dd/MM/yyyy";

        public static string TimeFormat => "h:mm tt";

        public static string DateTimeFormat => $"{DateFormat} {TimeFormat}";

        public static string GetDateTimeString(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                return dateTime.Value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            }
            return "";
        }

        public static string GetDateString(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                return dateTime.Value.ToString(DateFormat, CultureInfo.InvariantCulture);
            }
            return "";
        }

        public static string GetTimeString(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                return dateTime.Value.ToString(TimeFormat, CultureInfo.InvariantCulture);
            }
            return "";
        }

        public static string GetTimeString(TimeSpan? timeSpan)
        {
            if (timeSpan != null)
            {
                DateTime time = DateTime.Today.Add(timeSpan.Value);

                return GetTimeString(time);
            }
            return "";
        }

        public static string GetImageURL(string ImageURL)
        {
            return GetImageURL(ImageURL, "");
        }

        public static string GetImageURL(string ImageURL, string defaultUrl = "")
        {
            return string.IsNullOrEmpty(ImageURL) ? defaultUrl : ImageURL;
        }

        public static string GetString(string value)
        {
            return string.IsNullOrEmpty(value) ? "" : value;
        }

        public static List<string> StringTolist(string txtOfList)
        {
            return string.IsNullOrEmpty(txtOfList) ? new List<string>() : txtOfList.Split(",").ToList();
        }
    }
}
