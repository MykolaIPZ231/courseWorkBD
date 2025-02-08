using ClassLibrary1.Models;

namespace ClassLibrary1
{
    public class DataService
    {
        private readonly CourseWorkContext _context;

        public DataService(CourseWorkContext context)
        {
            _context = context;
        }

        public List<T> ReloadData<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public List<T> SearchData<T>(string searchText, Func<T, bool> filter) where T : class
        {
            var items = _context.Set<T>().ToList();
            return items.Where(filter).ToList();
        }
    }
}
