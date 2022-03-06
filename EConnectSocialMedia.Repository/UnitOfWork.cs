
namespace EConnectSocialMedia.Repository
{
    public class UnitOfWork
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public UnitOfWork(DatabaseContext BaseDBContext, IMapper Mapper)
        {
            _DBContext = BaseDBContext;
            _Mapper = Mapper;
        }

        public async Task<int> Save()
        {
            return await _DBContext.SaveChangesAsync();
        }

        #region AccountEntity
        public BaseRepository<Account> Account => new(_DBContext);
        public AccountStateRepository AccountState => new(_DBContext, _Mapper);
        public BaseRepository<AccountDevice> AccountDevice => new(_DBContext);
        public AccountTypeRepository AccountType => new(_DBContext, _Mapper);
        public GenderRepository Gender => new(_DBContext, _Mapper);
        #endregion

        #region AuthEntity
        public BaseRepository<AccessLevel> AccessLevel => new(_DBContext);
        public BaseRepository<SystemRole> SystemRole => new(_DBContext);
        public SystemRolePremissionRepository SystemRolePremission => new(_DBContext, _Mapper);
        public SystemUserRepository SystemUser => new(_DBContext, _Mapper);
        public BaseRepository<SystemView> SystemView => new(_DBContext);

        #endregion

        #region ChatEntity
        public ChatRepository Chat => new(_DBContext, _Mapper);
        public ChatMemberRepository ChatMember => new(_DBContext, _Mapper);
        public ChatTypeRepository ChatType => new(_DBContext, _Mapper);
        public MessageRepository Message => new(_DBContext, _Mapper);
        public MessageStateRepository MessageState => new(_DBContext, _Mapper);
        public MessageTypeRepository MessageType => new(_DBContext, _Mapper);
        #endregion

        #region GroupEntity
        public GroupRepository Group => new(_DBContext, _Mapper);
        public GroupMemberRepository GroupMember => new(_DBContext, _Mapper);
        public GroupTypeRepository GroupType => new(_DBContext, _Mapper);
        #endregion

        #region MainDataEntity
        public AppIntroRepository AppIntro => new(_DBContext, _Mapper);
        public BaseRepository<AppAbout> AppAbout => new(_DBContext);
        public QuestionsAndAnswersRepository QuestionsAndAnswers => new(_DBContext, _Mapper);
        public TermsAndConditionsRepository TermsAndConditions => new(_DBContext, _Mapper);

        #endregion

        #region PostEntity
        public PostRepository Post => new(_DBContext, _Mapper);
        public BaseRepository<PostAttachment> PostAttachment => new(_DBContext);
        public PostCommentRepository PostComment => new(_DBContext, _Mapper);
        public PostCommentReactionRepository PostCommentReaction => new(_DBContext, _Mapper);
        public PostStateRepository PostState => new(_DBContext, _Mapper);
        public BaseRepository<PostStateHistory> PostStateHistory => new(_DBContext);
        public PostTypeRepository PostType => new(_DBContext, _Mapper);
        public BaseRepository<PostReaction> PostReaction => new(_DBContext);
        public ReactionTypeRepository ReactionType => new(_DBContext, _Mapper);
        #endregion

        #region NotificationEntity

        public NotificationRepository Notification => new(_DBContext, _Mapper);
        public BaseRepository<NotificationAccount> NotificationAccount => new(_DBContext);

        #endregion

        #region CHIAEntity
        public PartnerRepository Partner => new(_DBContext, _Mapper);
        public ServiceProviderRepository ServiceProvider => new(_DBContext, _Mapper);
        public ServiceProviderCategoryRepository ServiceProviderCategory => new(_DBContext, _Mapper);
        public TutorialCategoryRepository TutorialCategory => new(_DBContext, _Mapper);
        public TutorialItemRepository TutorialItem => new(_DBContext, _Mapper);
        public UserFullinfoItemRepository UserFullinfoItem => new(_DBContext, _Mapper);
        public ServiceProviderAuthorityRepository ServiceProviderAuthority => new(_DBContext, _Mapper);

        #endregion

        #region LocationEntity
        public GovernerateRepository Governerate => new(_DBContext, _Mapper);
        #endregion

        #region ServiceProviderRequestEntity
        public ServiceProviderClassificationRepository ServiceProviderClassification => new(_DBContext, _Mapper);
        public BaseRepository<ServiceProviderRequest> ServiceProviderRequest => new(_DBContext);
        public BaseRepository<ServiceProviderRequestAttachment> ServiceProviderRequestAttachment => new(_DBContext);

        #endregion

        #region BeneficiaryRequestEntity
        public BeneficiaryTypeRepository BeneficiaryType => new(_DBContext, _Mapper);
        public BaseRepository<BeneficiaryRequest> BeneficiaryRequest => new(_DBContext);
        public BaseRepository<BeneficiaryRequestAttachment> BeneficiaryRequestAttachment => new(_DBContext);


        #endregion

    }
}
