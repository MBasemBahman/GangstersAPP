namespace GangstersAPP.Repository.MainDataEntityRepository
{
    public class QuestionsAndAnswersRepository : AppBaseRepository<QuestionsAndAnswers>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public QuestionsAndAnswersRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public QuestionsAndAnswers GetLang(QuestionsAndAnswers entity)
        {
            entity.QuestionsAndAnswersLang = _DBContext.QuestionsAndAnswersLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.QuestionsAndAnswersLang != null)
            {
                _Mapper.Map(entity.QuestionsAndAnswersLang, entity);
            }
            return entity;
        }

        public PagedList<QuestionsAndAnswers> GetLang(PagedList<QuestionsAndAnswers> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
