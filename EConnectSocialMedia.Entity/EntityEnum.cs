namespace EConnectSocialMedia.Entity
{
    public static class EntityEnum
    {
        public enum AccessLevelEnum
        {
            FullAccess = 1,
            ControlAccess = 2,
            ViewAccess = 3
        }
        public enum SystemUserEnum
        {
            Developer = 1
        }

        public enum SystemRoleEnum
        {
            Developer = 1,
        }

        public enum SystemViewEnum
        {
            Home = 1,
            SystemUser = 2,
            SystemView = 3,
            SystemRole = 4,
            AppAbout = 5,
            QuestionsAndAnswers = 6,
            TermsAndConditions = 7,
            AppIntro = 8,
            Account = 9,
            AccountState = 10,
            AccountType = 11,
            Gender = 12,
            AccountDevice = 13,
            Message = 14,
            Group = 15,
            GroupType = 16,
            GroupMember = 17,
            PostType = 18,
            PostState = 19,
            ReactionType = 20,
            Post = 21,
            PostComment = 22,
            PostAttachment = 23,
            PostReaction = 24,
            PostStateHistory = 25,
            ChatType = 26,
            Chat = 27,
            MessageState = 28,
            MessageType = 29,
            PostCommentReaction = 30,
            ServiceProviderCategory = 31,
            ServiceProvider = 32,
            TutorialCategory = 33,
            TutorialItem = 34,
            Partner = 35,
            UserFullinfoItem = 36,
            ServiceProviderRequest = 37,
            Governerate = 38,
            ServiceProviderClassification = 39,
            ServiceProviderAuthority = 40,
            BeneficiaryType = 41,
            BeneficiaryRequest = 42
        }

        public enum AccountTypeEnum
        {
            Visitor = 1,
            Employee = 2
        }

        public enum AccountStateEnum
        {
            Active = 1,
            Inactive = 2
        }

        public enum PostStateEnum
        {
            Pending = 1,
            Active = 2
        }

        public enum GenderEnum
        {
            Male = 1,
            Female = 2
        }

        public enum AccountProfileItems
        {
            AccountDevice = 1,
            Post = 2,
            Chat = 3,
            PostReaction = 4,
            PostComment = 5,
            PostCommentReaction = 6,
            Group = 7,
            ServiceProviderRequest = 8,
            BeneficiaryRequest = 9
        }

        public enum GroupProfileItems
        {
            GroupMember = 1,
            Post = 2
        }

        public enum PostProfileItems
        {
            PostAttachment = 1,
            PostComment = 2,
            PostReaction = 3,
            PostStateHistory = 4,
            SharedPost = 5
        }

        public enum ChatTypeEnum
        {
            Private = 1,
            Group = 3
        }

        public enum MessageStateEnum
        {
            Sent = 1,
            Recived = 2,
            Readed = 3
        }

        public enum OpenTypeEnum
        {
            Chat = 1,
            Message = 2,
            Group = 3,
            Post = 4,
            Commnet = 5
        }
    }
}
